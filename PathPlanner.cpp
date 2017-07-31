#include "PathPlanner.h"

/**
@brief		Cube constructor
@details	Inputs face, velocity
@param
_inFace : input face character
_outFace : output face character
_inVelocity : input velocity in m/s (multiples of 10)
_outVelocity : output velocity in m/s (multiples of 10)
@return
*/
PathPlanner::Cube::Cube(char _inFace, char _outFace, int _inVelocity, int _outVelocity)
	: inFace(_inFace), outFace(_outFace), inVelocity(_inVelocity), outVelocity(_outVelocity)
{
}

/**
@brief		Cube constructor
@details	Inputs only face, call 4-input cube constructor
@param
_inFace : input face character
_outFace : output face character
@return
*/
PathPlanner::Cube::Cube(char _inFace, char _outFace)
	: Cube(_inFace, _outFace, 0, 0)
{
}

/**
@brief		Getter of cube type integer
@details
Encode as 8 digits integer to access the cube parameters
inFace(char, 3 digits in ASCII), outFace(char, 3 digits in ASCII)
inVelocity(int, 1 digit divided by 10), outVelocity(int, 1 digit divided by 10)
@param
@return		
*/
int PathPlanner::Cube::getType()
{
	return inFace*100000 + outFace*100 + inVelocity + outVelocity/10;
}

/**
@brief		Getter of required time by cubeType
@details	Calculate direction and velocity from cubeType and access the simulation time map
@param
cubeType : cube type integer that express direction and velocity of the cube
@return		Time duration in sec
*/
double PathPlanner::getRequiredTime(int cubeType)
{
	char inFace = cubeType / 100000;
	char outFace = (cubeType % 100000) / 100;
	int inVelocity = (cubeType % 100) / 10 * 10;
	int outVelocity = (cubeType % 100) % 10 * 10;

	std::pair<char, char> face = std::make_pair(inFace, outFace);
	std::pair<int, int> velocity = std::make_pair(inVelocity, outVelocity);
	
	return cubeTime[face][velocity];
}

/**
@brief		Path planner constructor
@details	Construct and input simulation time from VrepDroneSim.csv before path planning
@param		
@return		
*/
PathPlanner::PathPlanner()
{
	inputSimData();
}

/**
@brief		Input simulation time from file
@details
File input from csv and store in temporary record vector
Typecast parameter as inFace(char), outFace(char), inVelocity(int), outVelocity(out), time(double)
Make a command to store in cubeTime map
@param
@return
*/
void PathPlanner::inputSimData()
{
	std::ifstream infile("VrepDroneSim.csv");

	while(infile)
	{
		std::string s;
		if(!getline(infile, s)) break;

		std::istringstream ss(s);
		std::vector <std::string> record;

		while(ss)
		{
			std::string s;
			if(!getline(ss, s, ',')) break;
			record.push_back(s);
		}
		if(record.size() != 5) break;
		if(record[4] != "-" && record[4] != "time (s)")
		{
			char inFace = record[0].at(0);
			char outFace = record[1].at(0);
			int inVelocity = std::stoi(record[2], nullptr);
			int outVelocity = std::stoi(record[3], nullptr);
			double time = std::stod(record[4], nullptr);
			storeSimData(inFace, outFace, inVelocity, outVelocity, time);
		}
	}
	if(!infile.eof()) std::cerr << "[Error] File reading cannot be done!\n";
}

/**
@brief		Store simulation data
@details
Store cube record(face, velocity, time) in
cubeTime : map <face, map <velocity, time> >
face : pair <char, char>
velocity : pair <int, int>
@param
inFace : input face
outFace : output face
inVelocity : input velocity
outVelocity : output velocity
time : time duration in cube
@return
*/
void PathPlanner::storeSimData(char inFace, char outFace, int inVelocity, int outVelocity, double time)
{
	std::pair<char, char> face = std::make_pair(inFace, outFace);
	std::pair<int, int> velocity = std::make_pair(inVelocity, outVelocity);

	auto it = cubeTime.find(face);
	if(it != cubeTime.end())
	{
		auto it2 = it->second.find(velocity);
		if(it2 != it->second.end()) it2->second = time;
		else it->second.insert(std::make_pair(velocity, time));
	}
	else
	{
		cubeTime.insert(std::make_pair(face, std::map<std::pair<int, int>, double>()));
		cubeTime[face].insert(std::make_pair(velocity, time));
	}
}

double PathPlanner::calcMaxHeight(double srcLat, double srcLng, double dstLat, double dstLng)
{
	if(srcLng > dstLng)
	{
		std::swap(srcLat, dstLat);
		std::swap(srcLng, dstLng);
	}

	convertWGStoKm(srcLat, srcLng, &srcLat, &srcLng);
	convertWGStoKm(dstLat, dstLng, &dstLat, &dstLng);
	double theta = std::atan2(dstLat - srcLat, dstLng - srcLng);
	double distance = std::sqrt((srcLat - dstLat) * (srcLat - dstLat) + (srcLng - dstLng) * (srcLng - dstLng));
	
	double srcX = srcLng + std::min(std::cos(theta + M_PI_4 * 3), std::cos(theta - M_PI_4 * 3)) * CUBE_SIZE / 2 / 1000.0;
	double dstX = dstLng + std::max(std::cos(theta + M_PI_4 * 1), std::cos(theta - M_PI_4 * 1)) * CUBE_SIZE / 2 / 1000.0;

	int srcCol, dstCol;
	convertKmtoRC(0, srcX, nullptr, &srcCol);
	convertKmtoRC(0, dstX, nullptr, &dstCol);

	for(int col = srcCol; col <= dstCol; col++)
	{
		double x;
		convertRCtoKm(0, col, nullptr, &x);

		double y1 = (-CUBE_SIZE / 2000.0 - (x - srcLng) * std::cos(theta)) / std::sin(theta) + srcLat;
		double y2 = ((distance + CUBE_SIZE / 2000.0) - (x - srcLng) * std::cos(theta)) / std::sin(theta) + srcLat;
		double y3 = (-CUBE_SIZE / 2000.0 + (x - srcLng) * std::sin(theta)) / std::cos(theta) + srcLat;
		double y4 = (CUBE_SIZE / 2000.0 + (x - srcLng) * std::sin(theta)) / std::cos(theta) + srcLat;

		if(y1 > y2) std::swap(y1, y2);
		if(y3 > y4) std::swap(y3, y4);

		int srcRow, dstRow;
		convertKmtoRC(std::max(y1, y3), 0, &srcRow, nullptr);
		convertKmtoRC(std::min(y2, y4), 0, &dstRow, nullptr);
		
		/*
		// access WonseokMap from srcRow to dstRow at col
		// calculate maximum height

		std::cout << srcRow << ", " << dstRow << ", " << dstRow-srcRow << std::endl;
		*/
	}
	
	return 100.0;
}

double PathPlanner::calcTravelTime(double srcLat, double srcLng, double dstLat, double dstLng)
{
	std::vector<PathPlanner::Cube> cubes = makeNaivePath(srcLat, srcLng, dstLat, dstLng);
	// Calculate travel time from sequential cubes
	
	double totalTime = 0.0;
	for(auto e : cubes) totalTime += getRequiredTime(e.getType());
	return totalTime;
}

std::vector<PathPlanner::Cube> PathPlanner::makeNaivePath(double srcLat, double srcLng, double dstLat, double dstLng)
{
	/*
	std::cout << ">> From : " << srcLat << ", " << srcLng << std::endl;
	std::cout << ">> To : " << dstLat << ", " << dstLng << std::endl;
	*/

	std::vector<PathPlanner::Cube> cubes;
	double height = calcMaxHeight(srcLat, srcLng, dstLat, dstLng);
	convertWGStoKm(srcLat, srcLng, &srcLat, &srcLng);
	convertWGStoKm(dstLat, dstLng, &dstLat, &dstLng);
	double distance = std::sqrt((srcLat - dstLat) * (srcLat - dstLat) + (srcLng - dstLng) * (srcLng - dstLng)) * 1000;

	/*
	std::cout << ">> Height : " << height << std::endl;
	std::cout << ">> Distance : " << distance << std::endl;
	*/

	cubes.push_back(Cube('d', 'u', 0, 10));

	for(double h = 10.0; h <= height; h += 10.0) cubes.push_back(Cube('d', 'u', 10, 10));
	cubes.push_back(Cube('d', 'r', 10, 10));

	for(double d = 0.0; d <= distance; d += 10.0) cubes.push_back(Cube('l', 'r', 10, 10));
	cubes.push_back(Cube('l', 'd', 10, 10));

	for(double h = 10.0; h <= height; h += 10.0) cubes.push_back(Cube('u', 'd', 10, 10));
	cubes.push_back(Cube('u', 'd', 10, 0));

	return cubes;
}

/* latitude 1 sec = 30.828 m, longitude 1 sec = 24.697 m */
void PathPlanner::convertWGStoKm(double wgsLat, double wgsLng, double *kmLat, double *kmLng) {
	if(kmLat != nullptr) *kmLat = -wgsLat * 0.030828 * 60 * 60;
	if(kmLng != nullptr) *kmLng = wgsLng * 0.024697 * 60 * 60;
}

void PathPlanner::convertKmtoWGS(double kmLat, double kmLng, double *wgsLat, double *wgsLng) {
	if(wgsLat != nullptr) *wgsLat = -kmLat / 0.030828 / 60 / 60;
	if(wgsLng != nullptr) *wgsLng = kmLng / 0.024697 / 60 / 60;
}

void PathPlanner::convertWGStoRC(double wgsLat, double wgsLng, int *row, int *col) {
	if(row != nullptr) *row = int((UL_LAT - wgsLat) * 20000 / DIST_LAT);
	if(col != nullptr) *col = int((wgsLng - UL_LNG) * 20000 / DIST_LNG);	
}

void PathPlanner::convertRCtoWGS(int row, int col, double *wgsLat, double *wgsLng) {
	if(wgsLat != nullptr) *wgsLat = UL_LAT - row * DIST_LAT / 20000;
	if(wgsLng != nullptr) *wgsLng = UL_LNG + col * DIST_LNG / 20000;
}

void PathPlanner::convertRCtoKm(int row, int col, double *kmLat, double *kmLng) {
	convertRCtoWGS(row, col, kmLat, kmLng);
	double wgsLat = kmLat != nullptr ? *kmLat : 0;
	double wgsLng = kmLng != nullptr ? *kmLng : 0;
	convertWGStoKm(wgsLat, wgsLng, kmLat, kmLng);
}

void PathPlanner::convertKmtoRC(double kmLat, double kmLng, int *row, int *col) {
	convertKmtoWGS(kmLat, kmLng, &kmLat, &kmLng);
	convertWGStoRC(kmLat, kmLng, row, col);
}
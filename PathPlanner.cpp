#include "PathPlanner.h"

PathPlanner::Cube::Cube(char _inFace, char _outFace, int _inVelocity, int _outVelocity)
	: inFace(_inFace), outFace(_outFace), inVelocity(_inVelocity), outVelocity(_outVelocity)
{
}

PathPlanner::Cube::Cube(char _inFace, char _outFace)
	: Cube(_inFace, _outFace, 0, 0)
{
}

int PathPlanner::Cube::getType()
{
	return inFace*100000 + outFace*100 + inVelocity + outVelocity/10;
}

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

PathPlanner::PathPlanner()
{
	inputSimData();
}

void PathPlanner::inputSimData()
{
	std::ifstream infile("VrepDroneSim.csv");

	while (infile)
	{
		std::string s;
		if (!getline(infile, s)) break;

		std::istringstream ss(s);
		std::vector <std::string> record;

		while (ss)
		{
			std::string s;
			if (!getline(ss, s, ',')) break;
			record.push_back(s);
		}
		if (record.size() != 5) break;
		if (record[4] != "-" && record[4] != "time (s)")
		{
			char inFace = record[0].at(0);
			char outFace = record[1].at(0);
			int inVelocity = std::stoi(record[2], nullptr);
			int outVelocity = std::stoi(record[3], nullptr);
			double time = std::stod(record[4], nullptr);
			storeSimData(inFace, outFace, inVelocity, outVelocity, time);
		}
	}
	if (!infile.eof()) std::cerr << "[Error] File reading cannot be done!\n";
}

void PathPlanner::storeSimData(char inFace, char outFace, int inVelocity, int outVelocity, double time)
{
	std::pair<char, char> face = std::make_pair(inFace, outFace);
	std::pair<int, int> velocity = std::make_pair(inVelocity, outVelocity);

	auto it = cubeTime.find(face);
	if (it != cubeTime.end())
	{
		auto it2 = it->second.find(velocity);
		if (it2 != it->second.end()) it2->second = time;
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
	std::vector<PathPlanner::Cube> cubes;
	double height = calcMaxHeight(srcLat, srcLng, dstLat, dstLng);
	convertWGStoKm(srcLat, srcLng, srcLat, srcLng);
	convertWGStoKm(dstLat, dstLng, dstLat, dstLng);
	double distance = std::sqrt((srcLat - dstLat) * (srcLat - dstLat) + (srcLng - dstLng) * (srcLng - dstLng)) * 1000;

	cubes.push_back(Cube('d', 'u', 0, 10));

	for (double h = 10.0; h <= height; h += 10.0) cubes.push_back(Cube('d', 'u', 10, 10));
	cubes.push_back(Cube('d', 'r', 10, 10));

	for (double d = 0.0; d <= distance; d += 10.0) cubes.push_back(Cube('l', 'r', 10, 10));
	cubes.push_back(Cube('l', 'd', 10, 10));

	for (double h = 10.0; h <= height; h += 10.0) cubes.push_back(Cube('u', 'd', 10, 10));
	cubes.push_back(Cube('u', 'd', 10, 0));

	return cubes;
}

/* latitude 1 sec = 30.828 m, longitude 1 sec = 24.697 m */
void PathPlanner::convertWGStoKm(double wgsLat, double wgsLng, double &kmLat, double &kmLng) {
	kmLat = -wgsLat * 0.030828 * 60 * 60;
	kmLng = wgsLng * 0.024697 * 60 * 60;
}

void PathPlanner::convertWGStoRC(double wgsLat, double wgsLng, int &row, int &col) {
	row = int((UL_LAT - wgsLat) / D_LAT);
	col = int((wgsLng - UL_LNG) / D_LNG);	
}

void PathPlanner::convertRCtoWGS(int row, int col, double &wgsLat, double &wgsLng) {
	wgsLat = UL_LAT - row * D_LAT;
	wgsLng = UL_LNG + col * D_LNG;
}
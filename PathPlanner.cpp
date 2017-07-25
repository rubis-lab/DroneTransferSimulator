#include "PathPlanner.h"

PathPlanner::Cube::Cube(char _inFace, char _outFace)
	: inFace(_inFace), outFace(_outFace)
{
}

int PathPlanner::Cube::getType()
{
	// Example
	return inFace*1000 + outFace*100 + inVelocity*10 + outVelocity;
}

double PathPlanner::Cube::getRequiredTime()
{
	return 0.0;
}

PathPlanner::PathPlanner()
{
	std::vector <std::vector <std::string> > data;
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
		if (record[4] != "-" && record[4] != "time (s)") {
			char inFace = record[0].at(0);
			char outFace = record[1].at(0);
			int inVelocity = std::stoi(record[2], nullptr);
			int outVelocity = std::stoi(record[3], nullptr);
			double time = std::stod(record[4], nullptr);

			auto it = cubeTime.find(std::make_pair(inFace, outFace));
			if (it != cubeTime.end()) {
				std::map<std::pair<int, int>, double> key = it->second;
				auto it2 = key.find(std::make_pair(inVelocity, outVelocity));
				if (it2 != key.end()) {
					it2->second = time;
				}
				else {
					key.insert(std::make_pair(std::make_pair(inVelocity, outVelocity), time));
				}

			}
			else {
				std::map<std::pair<int, int>, double> key;
				key.insert(std::make_pair(std::make_pair(inVelocity, outVelocity), time));
				cubeTime.insert(std::make_pair(std::make_pair(inFace, outFace), key));
			}
			std::cout << inFace << outFace << inVelocity << outVelocity << time << std::endl;
			data.push_back(record);
		}
	}
	if (!infile.eof())
	{
		std::cerr << " >> Fooey!\n";
	}
}

double PathPlanner::calcMaxHeight(double srcLat, double srcLng, double dstLat, double dstLng) {
	return 100.0;
}

double PathPlanner::calcTravelTime(double srcLat, double srcLng, double dstLat, double dstLng)
{
	std::vector<PathPlanner::Cube> cubes = makeNaivePath(srcLat, srcLng, dstLat, dstLng);
	// Calculate travel time from sequential cubes

	for (auto e : cubes)
		std::cout << "<" << e.inFace << "," << e.outFace << "> ";
	std::cout << std::endl;


	return 0.0;
}

std::vector<PathPlanner::Cube> PathPlanner::makeNaivePath(double srcLat, double srcLng, double dstLat, double dstLng)
{
	std::cout << ">> From : " << srcLat << ", " << srcLng << std::endl;
	std::cout << ">> To : " << dstLat << ", " << dstLng << std::endl;

	std::vector<PathPlanner::Cube> cubes;
	double height = calcMaxHeight(srcLat, srcLng, dstLat, dstLng);
	convertWGStoKm(srcLat, srcLng, srcLat, srcLng);
	convertWGStoKm(dstLat, dstLng, dstLat, dstLng);
	double distance = std::sqrt((srcLat - dstLat) * (srcLat - dstLat) + (srcLng - dstLng) * (srcLng - dstLng)) * 1000;

	std::cout.precision(15);
	std::cout << ">> Height : " << height << std::endl;
	std::cout << ">> Distance : " << distance << std::endl;

	for (double h = 0.0; h <= height; h += 10.0)
		cubes.push_back(Cube('d', 'u'));
	cubes.push_back(Cube('d', 'r'));

	for (double d = 0.0; d <= distance; d += 10.0)
		cubes.push_back(Cube('l', 'r'));
	cubes.push_back(Cube('l', 'd'));

	for (double h = 0; h <= height; h += 10.0)
		cubes.push_back(Cube('u', 'd'));

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
	std::cout << wgsLat << ", " << wgsLng << std::endl;
}
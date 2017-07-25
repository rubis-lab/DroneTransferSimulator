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

double PathPlanner::calcTravelTime(double srcLat, double srcLng, double dstLat, double dstLng)
{
	std::vector<PathPlanner::Cube> cubes = makeNaivePath(srcLat, srcLng, dstLat, dstLng);
	// Calculate travel time from sequential cubes
	return 0.0;
}

std::vector<PathPlanner::Cube> PathPlanner::makeNaivePath(double srcLat, double srcLng, double dstLat, double dstLng)
{
	std::vector<PathPlanner::Cube> cubes;
	return cubes;
}

void PathPlanner::convertWGStoKm(double wgsLat, double wgsLng, double &kmLat, double &kmLng) {
	kmLat = -wgsLat * 0.031 * 60 * 60;
	kmLng = wgsLng * 0.025 * 60 * 60;
}

void PathPlanner::convertWGStoRC(double wgsLat, double wgsLng, int &row, int &col) {
	
}
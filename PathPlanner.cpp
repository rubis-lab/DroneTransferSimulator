#include "PathPlanner.h"

PathPlanner::Cube::Cube(char _inFace, char _outFace) : inFace(_inFace), outFace(_outFace)
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
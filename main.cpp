#include <iostream>
#include "DroneMap.h"
#include "PathPlanner.h"

int main()
{
	DroneMap *droneMap = DroneMap::getInstance();
	PathPlanner pathPlanner;
	double x, y;
	pathPlanner.convertWGStoKm(37.578908, 126.997501, x, y);
	std::cout.precision(15);
	std::cout << x << ", " << y << std::endl;

	return 0;
}
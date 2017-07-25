#include <iostream>
#include "DroneMap.h"
#include "PathPlanner.h"

int main()
{
	DroneMap *droneMap = DroneMap::getInstance();
	PathPlanner pathPlanner;
	pathPlanner.calcTravelTime(37.578908, 126.997501, 37.579017, 126.994870);
	return 0;
}
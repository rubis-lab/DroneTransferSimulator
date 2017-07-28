#pragma once

#include <vector>
#include <utility>
#include "DroneStation.h"
#include "PathPlanner.h"

class DroneStationFinder
{
private:
	double distanceFromEvent(double wgsLat, double wgsLng);
	double eventLng, eventLat;
	bool distanceComparator(DroneStation x, DroneStation y);
	std::vector <DroneStation> stations;

public:
	DroneStationFinder(std::pair<double, double>);
	int stationFinder();
};
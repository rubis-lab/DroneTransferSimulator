#pragma once

#include <vector>
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
	DroneStationFinder(double _lat, double _lng);
	DroneStation StationFinder();
};
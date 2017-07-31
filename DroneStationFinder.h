#pragma once

#include <vector>
#include <utility>
#include "DroneStation.h"
#include "StationManager.h"

class DroneStationFinder
{
private:
	double getDistanceFromRecentEvent(double wgsLat, double wgsLng);
	double eventLng, eventLat;
	bool distanceComparator(DroneStation x, DroneStation y);
	std::vector <DroneStation> stations;

public:
	DroneStationFinder(std::pair<double, double>);
	int findCloestStation();
};
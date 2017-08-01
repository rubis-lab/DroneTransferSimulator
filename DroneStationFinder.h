#pragma once

#include <vector>
#include <utility>
#include "DroneStation.h"
#include "StationManager.h"

class DroneStationFinder
{
private:
	double eventLng, eventLat;
	bool distanceComparator(DroneStation x, DroneStation y);
	std::vector <DroneStation> stations;

public:
	double getDistanceFromRecentEvent(double wgsLat, double wgsLng);
	DroneStationFinder(std::pair<double, double>);
	int findCloestStation();
	int findAvailableDrone(int stationIndex);
};
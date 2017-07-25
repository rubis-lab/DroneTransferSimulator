#pragma once

#include <vector>
#include "DroneStation.h"
#include "PathPlanner.h"

class StationFinding
{
private:
	double distanceBtwPnts(double wgsLat1, double wgsLng1, double wgsLat2, double wgsLng2);
	double eventLng, eventLat;
	bool distanceCompare(DroneStation x, DroneStation y);
	std::vector <DroneStation> stations;


public:
	void FindStation(double _lng, double _lat, std::vector <DroneStation> stations, std :: vector <DroneStation> *StationList);
	

};
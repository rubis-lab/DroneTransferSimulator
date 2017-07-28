#include "DroneStationFinder.h"
#include <algorithm>
#include <vector>
#include <iostream>

/**
@brief return distance between two points
@details
@param latitude, longitude of two points
@return distance (km)
*/
double DroneStationFinder::distanceFromEvent(double wgsLng, double wgsLat)
{
	double kmLat, kmLng;
	kmLat = -(eventLat-wgsLat) * 0.030828 * 60 * 60;
	kmLng = (eventLng-wgsLng) * 0.024697 * 60 * 60;
	return sqrt(kmLat*kmLat+ kmLng*kmLng);
}

/**
@brief comparing distance from event
@details
@param
@return
*/
bool DroneStationFinder::distanceComparator(DroneStation x, DroneStation y)
{
	return (distanceFromEvent(x.stationLng, x.stationLat)>distanceFromEvent(y.stationLng, y.stationLat));
}

/**
@brief finding drone station
@details 
@param 
@return
*/
int DroneStationFinder::stationFinder()
{
	std::vector<DroneStation> stations;
	double minValue = -1;
	int minIndex;
	for (auto it= stations.begin(); it!=stations.end(); ++it) 
	{
		double distance = distanceFromEvent(it->stationLng, it->stationLat);
		if (it->coverRange > distance) 
		{
			if (distance < minValue || minValue == -1)
			{
				minValue = distance;
				minIndex = std::distance(stations.begin(), it);
			}
		}
		
	}
	if (minValue==-1) std::cout << "rescue failed" << std::endl;
	return minIndex;
}

DroneStationFinder::DroneStationFinder(std::pair<double, double> coordinate)
{
	eventLat = coordinate.first;
	eventLng = coordinate.second;
}
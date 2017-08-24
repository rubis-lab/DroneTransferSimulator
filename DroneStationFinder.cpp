#include "DroneStationFinder.h"
#include <algorithm>
#include <vector>
#include <iostream>
#include <queue>

/**
@brief return distance between event and drone station
@details
@param latitude, longitude of drone station
@return distance (km)
*/
double DroneStationFinder::getDistanceFromRecentEvent(double wgsLng, double wgsLat)
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
	return (getDistanceFromRecentEvent(x.stationLng, x.stationLat)<getDistanceFromRecentEvent(y.stationLng, y.stationLat));
}

/**
@brief finding drone station
@details finding cloest drone station of which coverage is bigger than distance
@param 
@return vector of drone stations
*/
void DroneStationFinder::findAvailableStations()
{
	std::vector<DroneStation> stations = StationManager::getStations();
	for(int i=0; i!=std::distance(stations.begin(),stations.end()); ++i)
	{
		double distance = getDistanceFromRecentEvent(stations[i].stationLng, stations[i].stationLat);
		if(stations[i].coverRange > distance)
		{
			availableStations.push_back(stations[i]);
		}		
	}
	std::sort(availableStations.begin(), availableStations.end());
}

DroneStationFinder::DroneStationFinder(std::pair<double, double> coordinate)
{
	eventLng = coordinate.first;
	eventLat = coordinate.second;
}

/**
@brief find if there is available drone
@details
@param
@return index of available drone station and drone
*/
std::pair<int,int> DroneStationFinder::findAvailableDrone(Time currentTime)
{
	for(auto it = availableStations.begin(); it != availableStations.end(); it++)
	{
		it->updateChargingDrones(currentTime);
		if(it->drones.empty()) continue;
		else
		{
			for(auto itt = it->drones.begin(); itt != it->drones.end(); itt++)
			{
				double distance = getDistanceFromRecentEvent(it->stationLng, it->stationLat);
				if(itt->returnStatus()!=1 && itt->returnAvailDist() > distance) return std::make_pair(int(std::distance(availableStations.begin(), it)), int(std::distance(it->drones.begin(), itt)));
			}
		}
	}
}

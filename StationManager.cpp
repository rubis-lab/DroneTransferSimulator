#include "StationManager.h"
#include <iostream>

std::vector<DroneStation> StationManager::stations;

void StationManager::getStationLocation(int stationNum, double &lat, double &lng)
{
	lng = stations[stationNum].stationLng;
	lat = stations[stationNum].stationLat;
}

void StationManager::setStationLocation(int stationNum, double lat, double lng)
{
	stations[stationNum].stationLat = lat;
	stations[stationNum].stationLng = lng;
}

void StationManager::setStationVector()
{
	DroneStation droneStation(1, 2.0, 3.0, 4.0);
	stations.push_back(droneStation);
}

std::vector<DroneStation> StationManager::getStations()
{
	return stations;
}
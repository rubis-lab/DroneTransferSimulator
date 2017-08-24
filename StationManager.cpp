#include "StationManager.h"
#include <iostream>

std::vector<DroneStation> StationManager::stations;

void StationManager::getStationLocation(int stationNum, double &lng, double &lat)
{
	lng = stations[stationNum].stationLng;
	lat = stations[stationNum].stationLat;
}

void StationManager::setStationLocation(int stationNum, double lng, double lat)
{
	stations[stationNum].stationLat = lat;
	stations[stationNum].stationLng = lng;
}

void StationManager::setStationVector(int maxDrone, double coverRange, double stnLng, double stnLat)
{
	DroneStation droneStation(maxDrone, coverRange, stnLng, stnLat);
	stations.push_back(droneStation);
}

std::vector<DroneStation> StationManager::getStations()
{
	return stations;
}
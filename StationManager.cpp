#include "StationManager.h"

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
#include "StationFinding.h"
#include <algorithm>

/**
@brief return distance between two points
@details
@param latitude, longitude of two points
@return distance (km)
*/
double StationFinding :: distanceBtwPnts(double wgsLng1, double wgsLat1, double wgsLng2, double wgsLat2)
{
	double kmLat, kmLng;
	kmLat = -(wgsLat2-wgsLat1) * 0.030828 * 60 * 60;
	kmLng = (wgsLng2-wgsLng1) * 0.024697 * 60 * 60;
	return sqrt(kmLat*kmLat+ kmLng*kmLng);
}

/**
@brief comparing distance from event
@details
@param
@return
*/
bool StationFinding::distanceCompare(DroneStation x, DroneStation y)
{
	return(distanceBtwPnts(x.stationLng, x.stationLat, eventLng, eventLat)>distanceBtwPnts(y.stationLng, y.stationLat, eventLng, eventLat));
}

/**
@brief finding drone station
@details 
@param 
@return
*/
void StationFinding::FindStation(double _lng, double _lat, std::vector<DroneStation> stations, std::vector<DroneStation> *stationList)
{
	/*
	int i = 0;
	for (std::vector<DroneStation>::iterator it=_stationList.begin(); it!=_stationList.end();++it) {
		if (stations[i].coverRange > distanceBtwPnts(stations[i].stationLng, stations[i].stationLat, _lng, _lat) ) {
			_stationList.push_back(stations[i]);
		}
	}
	std :: sort(_stationList.begin(), _stationList.end(), distanceCompare);
	*/
	std::vector <double> stationDistance;
	for (int i = 0; i<=stations.size(); i++) {
		stationDistance.push_back(distanceBtwPnts(_lng, _lat, stations[i].stationLng, stations[i].stationLat));
	}
	std::min_element(stationDistance.begin(), stationDistance.end());
	

}

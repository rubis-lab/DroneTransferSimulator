/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
 
#include "DroneStation.h"
#include <tuple>

DroneStation::DroneStation(int _nMaxDrone, double _coverRange, double _stationLng, double _stationLat)
{
	nMaxDrone = _nMaxDrone;
	coverRange = _coverRange;
	stationLng = _stationLng;
	stationLat = _stationLat;
}

/**
@brief upgrade the number of drone in the drone station
@details upgrade the change of the number of drone because of event right before
@param
@return
*/
void DroneStation::setDroneNum(int n)
{
	if(n < 0 || n > nMaxDrone) return;

	nDrone = n;
}

void DroneStation::droneFly(int droneIndex, double distance, Time dispatchTime, int time)
{
	std::tuple<int, double, Time> flyingDroneInfo = std::make_tuple(droneIndex, distance, dispatchTime);
	flyingDrone.push_back(flyingDroneInfo);
	drones[droneIndex].fly(distance);
}

void DroneStation::updateFlyingDrones(Time currentTime, int calculatedTime)
{
	for(int i=0; i!=flyingDrone.size(); i++)
	{
		std::tuple<int, double, Time> flyingDroneInfo = flyingDrone[i];
		if (Time::getTimeGap(std::get<2>(flyingDroneInfo), currentTime), calculatedTime)
		{
			flyingDrone.erase(flyingDrone.begin()+i);
		}
	}
}
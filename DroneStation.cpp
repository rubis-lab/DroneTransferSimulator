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

void DroneStation::setDroneNum(int n)
{
	if(n < 0 || n > nMaxDrone) return;
	nDrone = n;
}

/**
@brief drone transfered from station
@details add the transfered drone to FlyingDrone vector
@param
@return
*/
void DroneStation::transfer(int droneIndex, double distance, Time occuredTime, double calculatedTime)
{
	if(drones.begin() + droneIndex >= drones.end() || droneIndex < 0) return;
	drones[droneIndex].fly(distance);
	std::tuple<int, double, Time, bool> flyingDroneInfo = std::make_tuple(droneIndex, distance, occuredTime, false);
	flyingDrone.push_back(flyingDroneInfo);
}


/**
@brief upgrade the number of drone in the drone station
@details upgrade the change of the number of drone because of event right before
@param
@return
*/
void DroneStation::updateFlyingDrones(Time currentTime, int calculatedTime)
{
	for(int i=0; i!=distance(flyingDrone.begin(), flyingDrone.end()); i++)
	{
		std::tuple<int, double, Time, bool> flyingDroneInfo = flyingDrone[i];
		if((Time::getTimeGap(std::get<2>(flyingDroneInfo), currentTime))*60 > calculatedTime) //check if drone arrived
		{
			flyingDrone.erase(flyingDrone.begin()+i);
		}
	}
}
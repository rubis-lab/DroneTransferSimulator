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
@brief upgrade the number of drone in the drone station
@details upgrade the change of the number of drone because of event right before
@param
@return
*/
void DroneStation::updateChargingDrones(Time currentTime)
{
	for(auto it =drones.begin() ; it != drones.end() ;it++)
	{
		if(it->returnStatus()== 2) 
		{
			it->charge(it->getChargeStartTime(), currentTime); //battery charged from centerArrivalTime

			if(it->returnBattery() >= 100)
			{
				it->setBattery(100);
				it->setStatus(0);
			}
		}
	}
}

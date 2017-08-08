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
	for(int i = 0; i != distance(chargingDrones.begin(), chargingDrones.end());)
	{
		chargingDrone returnedDrone = chargingDrones[i];
		
		drones[returnedDrone.droneIndex].charge(returnedDrone.centerArrivalTime, currentTime);	//battery charged from centerArrivalTime

		if (drones[returnedDrone.droneIndex].returnBattery() >= 100)
		{
			drones[returnedDrone.droneIndex].setBattery(100); //if full charged, battery=100
			chargingDrones.erase(chargingDrones.begin() + i);
		}
		else i++;
	}
}

void DroneStation::addChargingDrone(Time arrivalTime, std::pair<int,int> stationDroneIdx)
{
	chargingDrone d;
	d.centerArrivalTime = arrivalTime;
	d.droneIndex = stationDroneIdx.second;
	chargingDrones.push_back(d);

	drones[stationDroneIdx.second].setInStation(true);
}

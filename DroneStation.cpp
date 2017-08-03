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
void DroneStation::transfer(int _droneIndex, double _distance, Time _occuredTime, double calculatedTime)
{
	if (drones.begin() + _droneIndex >= drones.end() || _droneIndex < 0) return;
	drones[_droneIndex].fly(_distance);

	flyingDrone newFlyingDrone;
	newFlyingDrone.droneIndex = _droneIndex;
	newFlyingDrone.distance = _distance;
	newFlyingDrone.occuredTime = _occuredTime;
	newFlyingDrone.eventArrivalTime = Time::timeAdding(_occuredTime, calculatedTime);
	newFlyingDrone.centerArrivalTime = Time::timeAdding(newFlyingDrone.eventArrivalTime, calculatedTime);
	flyingDrones.push_back(newFlyingDrone);
}


/**
@brief upgrade the number of drone in the drone station
@details upgrade the change of the number of drone because of event right before
@param
@return
*/
void DroneStation::updateFlyingDrones(Time currentTime)
{
	for (int i = 0; i != distance(flyingDrones.begin(), flyingDrones.end());)
	{
		flyingDrone returnedDrone = flyingDrones[i];
		if (Time::timeComparator(returnedDrone.centerArrivalTime, currentTime))						//if drone arrived
		{
			flyingDrones.erase(flyingDrones.begin() + i);											//erase from 
			drones[returnedDrone.droneIndex].fly(returnedDrone.distance);							//battery consumed
			drones[returnedDrone.droneIndex].charge(returnedDrone.centerArrivalTime, currentTime);	//battery charged from centerArrivalTime

			double _battery = drones[returnedDrone.droneIndex].returnBattery();

			if (drones[returnedDrone.droneIndex].returnBattery() >= 100) drones[returnedDrone.droneIndex].setBattery(100);	//if full charged, battery=100
			else																					//if battery <100, push back to charging drone vector
			{
				chargingDrone newChargingDrone;
				newChargingDrone.droneIndex = returnedDrone.droneIndex;
				newChargingDrone.centerArrivalTime = returnedDrone.centerArrivalTime;

				chargingDrones.push_back(newChargingDrone);
			}
		}
		else i++;
	}
}

void DroneStation::updateDroneBattery(Time currentTime)
{ //pair <index, battery>
	for (int i = 0; i != distance(chargingDrones.begin(), chargingDrones.end());)
	{
		chargingDrone newChargingDrone = chargingDrones[i];
		drones[newChargingDrone.droneIndex].charge(newChargingDrone.centerArrivalTime, currentTime);
		if (drones[newChargingDrone.droneIndex].returnBattery() >100)
		{
			chargingDrones.erase(chargingDrones.begin() + i);
		}
		else i++;
	}
}
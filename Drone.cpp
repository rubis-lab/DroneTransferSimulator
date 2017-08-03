/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
#include <iostream>
#include "Drone.h"


/**
@brief drone starts to fly and battery consumed
@details battery consumption is proportinal to distance
@param
@return
*/
void Drone::fly(double distance)
{
	if(distance < 0) return;

	double consumedBattery = distance / maxAvailDist * 100;
	if(consumedBattery < 0 || consumedBattery > 100) return;
	else if(consumedBattery > battery) return;

	battery -= consumedBattery;
}


/**
@brief upgrade the battery of each drone
@details
@param
@return
*/
void Drone::charge(Time startTime, Time endTime)
{
	battery += chargingRate*(Time::getTimeGap(startTime, endTime));
}


/**
@brief upgrade the battery of each drone
@details
@param
@return
*/
double Drone::returnBattery()
{
	return battery;
}


void Drone::setBattery(double _battery)
{
	battery = _battery;
}


Drone::Drone(double _maxAvailDist)
{
	maxAvailDist = _maxAvailDist;
	battery = 100;
}


/**
@brief return available distance of drone
@details
@param
@return
*/
double Drone::returnAvailDist()
{
	return availDist;
}
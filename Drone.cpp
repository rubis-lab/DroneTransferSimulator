/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
#include <iostream>
#include "Drone.h"

void Drone::fly(double distance)
{
	if(distance < 0) return;

	double consumedBattery = distance / maxAvailDist * 100;
	if(consumedBattery < 0 || consumedBattery > 100) return;
	else if(consumedBattery > battery) return;

	battery -= consumedBattery;
}

Drone::Drone(double _maxAvailDist)
{
	maxAvailDist = _maxAvailDist;
	battery = 100;
}
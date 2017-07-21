/**
@file
@date 2017/07/19
@author Minji and hexoul
@brief
*/
 
#include <vector>
#include <algorithm>
 
#include "DroneStation.h"

DroneStation::DroneStation(int _nMaxDrone)
{
	nMaxDrone = _nMaxDrone;
}

/**
@brief upgrade the number of drone in the drone station
@details upgrade the change of the number of drone because of event right before
@param
@return
*/
void DroneStation::upgradeDroneNum(int n)
{
	nDrone = n;
}




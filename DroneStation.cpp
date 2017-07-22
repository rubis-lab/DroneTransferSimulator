/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
 
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
void DroneStation::setDroneNum(int n)
{
	if(n < 0 || n > nMaxDrone) return;

	nDrone = n;
}




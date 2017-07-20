/**
@file
@date 2017/07/19
@author Minji
@brief
*/

#include <vector>
#include <algorithm>

using namespace std;

include "Event.h"

/**
@brief operator to compare time between events
*/

/**
@brief find the coordinate of the event
@details with the text file of DB from Medical Department, find the coordinate of the event
@param eventNum
@return array of altitude and longitude
*/
Event::findCoordinate(int eventNum)
{
	fr = fopen("C:\Users\이민지\Desktop\인턴\의대데이터\data", "r");
	while (fscanf(fr, "%s", str) == 1)
	{
		fscanf(fr, "%d %d %d %d", &altitude, &longitude, &date, &time, &ambulDate, &ambulTime);
	}
}

Event :: operator >()
{


}

/**
@brief find the center
@details find the center that coverage is bigger than distane from event.
@param center, latitude, longitude
@return array of center numbers sorted by distance from event
*/
Event::findCenter()
{


}

/**
@brief fine the drone
@details find the drone to transfer AED by considering drivable distnace
@param output of findCenter(), center vector
@return array of center number, drone number
*/
Event :: findDrone()
{ 


}



/**
@brief calculating time to destination
@details
@param location of center, location of event
@return time
*/
Event ::timeToDest()
{

};
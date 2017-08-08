/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
#include "Event.h"

Event::Event(double _lat, double _lng, Time _oDate, Time _ambulDate, eventType _type)
	: lat(_lat), lng(_lng), occuredDate(_oDate), ambulDate(_ambulDate), type(_type)
{
}


/**
@brief compare occured time of two events
@details
@param
@return
*/
Time Event::getOccuredDate()
{
	return occuredDate;
}

/**
@brief return type of event
@details
@param
@return eventType
*/
Event::eventType Event::getEventType()
{
	return type;
}

/**
@brief return coordinates
@details
@param
@return pair of latitude, longitude
*/
std::pair<double, double> Event::getCoordinates()
{
	return std::make_pair(lat, lng);
}

/**
@brief set station index and drone index
@details
@param
@return 
*/
void Event::setStationDroneIdx(int _stationIndex, int _droneIndex)
{
	stationIndex = _stationIndex;
	droneIndex = _droneIndex;
}

/**
@brief return pair of station and drone index
@details
@param
@return pair of station index and drone index
*/
std::pair<int, int> Event::getStationDroneIdx()
{
	return std::make_pair(stationIndex, droneIndex);
}

/**
@brief overload operator
@details
@param
@return 
*/
bool Event::operator<(const Event& event)
{
	return (Time::timeComparator(occuredDate, event.occuredDate));
}
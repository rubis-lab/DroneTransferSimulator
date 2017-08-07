/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
#include "Event.h"

Event::Event(double _lat, double _lng, Time _oDate, Time _ambulDate)
	: lat(_lat), lng(_lng), occuredDate(_oDate), ambulDate(_ambulDate)
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

char Event::getEventType()
{
	return type;
}


std::pair<double, double> Event::getCoordinates()
{
	return std::make_pair(lat, lng);
}

void Event::setStationDroneIdx(int _stationIndex, int _droneIndex)
{
	stationIndex = _stationIndex;
	droneIndex = _droneIndex;
}

std::pair<int, int> Event::getStationDroneIdx()
{
	return std::make_pair(stationIndex, droneIndex);
}

bool Event::operator<(const Event& event)
{
	return (Time::timeComparator(occuredDate, event.occuredDate));
}



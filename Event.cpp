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


std::pair<double, double> Event::getCoordinates()
{
	return std::make_pair(lat, lng);
}


bool Event::operator<(const Event& event)
{
	return (Time::timeComparator(occuredDate, event.occuredDate));
}

void Event::timeConsumed()
{
}


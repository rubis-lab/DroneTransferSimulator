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


bool Event::occuredDateComparator(Event &x, Event &y)
{
	return(Time::timeComparator(x.occuredDate, y.occuredDate));
} 

/*
bool Event:: operator> (const Event& event2)
{
	return (Time::timeComparator(occuredDate, event2.occuredDate));
}
*/



void Event::timeConsumed()
{
}
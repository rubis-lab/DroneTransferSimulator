/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
#include "Event.h"

Event::Event(double _lat, double _lng, time_t _oDate, time_t _ambulDate)
	: lat(_lat), lng(_lng), occuredDate(_oDate), ambulDate(_ambulDate)
{
}
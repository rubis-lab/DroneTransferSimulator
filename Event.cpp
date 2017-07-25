/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
#include "Event.h"

Event::Event(double _lat, double _lng, int _oDate, int ambulDate)
{
}

/**
@brief compare occured time of two events
@details
@param
@return
*/
bool Event:: myCompare(Event &x, Event &y)
{
	return (x.occuredDate > y.occuredDate);

}
#include "Time.h"

/**
@brief compare time order between two events
@details
@param t1, t2
@return true if t1 happened earlier than t2
*/
bool Time::timeComparator(Time t1, Time t2)
{
	if (t1.year != t2.year) return (t1.year > t2.year);
	else if (t1.month != t2.month) return (t1.month > t2.month);
	else if (t1.hour != t2.hour) return (t1.hour > t2.hour);
	else if (t1.min != t2.min) return (t1.min > t2.min);
	else return true;
}
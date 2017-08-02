#include "Time.h"

/**
@brief compare time order between two events
@details
@param t1, t2
@return true if t1 happened earlier than t2
*/
bool Time::timeComparator(Time t1, Time t2)
{
	if(t1.year != t2.year) return (t1.year < t2.year);
	else if(t1.month != t2.month) return (t1.month < t2.month);
	else if(t1.date != t2.date) return(t1.date < t2.date);
	else if(t1.hour != t2.hour) return (t1.hour < t2.hour);
	else if(t1.min != t2.min) return (t1.min < t2.min);
	else return true;
}

/**
@brief return time gap between two times
@details naive (1 month = 30 days)
@param t1, t2
@return true minutes between two times
*/
int Time::getTimeGap(Time t1, Time t2)
{
	return (t2.min - t1.min) + 60 * (t2.hour - t1.hour + 24 * (t2.date - t1.date + 30 * (t2.month - t1.month + 12 * (t2.year - t1.year))));
}
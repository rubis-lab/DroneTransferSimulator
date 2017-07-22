#include <ctime>

#ifndef _H_EVENT_
#define _H_EVENT_

class Event
{
private:
	double lat, lng;
	time_t occuredDate, ambulDate;

public:
	Event(double _lat, double _lng, time_t _oDate, time_t ambulDate);
};

#endif
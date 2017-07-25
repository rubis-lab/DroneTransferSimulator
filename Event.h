#include <ctime>

#ifndef _H_EVENT_
#define _H_EVENT_

class Event
{
private:
	double lat, lng;
	int occuredDate, ambulDate;

public:
	Event(double _lat, double _lng, int _oDate, int ambulDate);
	bool myCompare(Event &x, Event &y);
};

#endif
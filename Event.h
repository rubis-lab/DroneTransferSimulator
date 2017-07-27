#include <ctime>
#include "Time.h"

#ifndef _H_EVENT_
#define _H_EVENT_

class Event
{
private:
	double lat, lng;
	Time occuredDate, ambulDate;

public:
	Event(double _lat, double _lng, Time _oDate, Time ambulDate);
	Time getOccuredDate();
	bool occuredDateComparator(Event &x, Event &y);
	//bool operator> (const Event& event2) ;
	void timeConsumed();
};

#endif
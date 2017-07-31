#include <ctime>
#include <utility>
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
	std::pair<double, double> getCoordinates();
	bool operator<(const Event& event);
};

#endif
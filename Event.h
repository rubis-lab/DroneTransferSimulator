#include <ctime>
#include <utility>
#include "Time.h"
#include "DroneStationFinder.h"
#include "PathPlanner.h"

#ifndef _H_EVENT_
#define _H_EVENT_

class Event
{
private:
	double lat, lng;
	Time occuredDate, ambulDate;
	int stationIndex, droneIndex;
	char type;

public:
	Event(double _lat, double _lng, Time _oDate, Time _ambulDate);
	Time getOccuredDate();
	char getEventType();
	std::pair<double, double> getCoordinates();
	std::pair<double, double> getDestCoord();
	void setStationDroneIdx(int _stationIndex, int _droneIndex);
	std::pair<int, int> getStationDroneIdx();
	bool operator<(const Event& event);
	
};

#endif
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
	
public:
	enum eventType { E_EVENT_OCCURED, E_EVENT_ARRIVAL, E_STATION_ARRIVAL };
	eventType e = E_EVENT_OCCURED;
	enum eventType type;
	Event(double _lat, double _lng, Time _oDate, Time _ambulDate, eventType _type);
	Time getOccuredDate();
	enum eventType getEventType();
	std::pair<double, double> getCoordinates();
	void setStationDroneIdx(int _stationIndex, int _droneIndex);
	std::pair<int, int> getStationDroneIdx();
	bool operator<(const Event& event);
};

#endif
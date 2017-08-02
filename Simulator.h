#include <vector>
#include <ctime>
#include "Event.h"
#include "Time.h"
#include "PathPlanner.h"
#include "DroneStation.h"
#include "DroneStationFinder.h"

#ifndef _H_SIMULATOR_
#define _H_SIMULATOR_

class Simulator
{
private:
	std::vector<Event> events;
	std::vector<Event> sortedEvents;
	std::vector<DroneStation> stations;

public:
	void getEventsFromCSV(char* fname);
	std::vector<Event> getEvents();
	void updateEventsBtwRange(Time start, Time end);
	void start(Time start, Time end);
};

#endif
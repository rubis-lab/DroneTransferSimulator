#include <vector>
#include <ctime>
#include "Event.h"
#include "Time.h"
#include "DroneStationFinder.h"

#ifndef _H_SIMULATOR_
#define _H_SIMULATOR_

class Simulator
{
private:
	std::vector<Event> events;

public:
	void getEventsFromCSV(char* fname);
	std::vector<Event> getEvents();
	void updateEventsBtwRange(Time start, Time end, std::vector <Event> &_events);
	void simulation(Time start, Time end);
};

#endif
#include <vector>
#include <ctime>
#include "Event.h"

#ifndef _H_SIMULATOR_
#define _H_SIMULATOR_

class Simulator
{
private:
	std::vector<Event> events;

public:
	std::vector<Event> getEvents();
	void updateEventsBtwRange(time_t start, time_t end);
	void simulation();
};

#endif
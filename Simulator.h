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
	void getEventsFromCSV(char* fname, std :: vector < std:: vector <double> > *data);
	std::vector<Event> getEvents();
	void updateEventsBtwRange(int start, int end, std::vector < std::vector <double> > data);
	void simulation(int start, int end);
};

#endif
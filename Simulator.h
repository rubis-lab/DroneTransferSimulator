#include <vector>
#include <ctime>
#include <utility>
#include "Event.h"
#include "Time.h"
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
	std::vector<int> occuredTimeVec;
	std::vector<std::pair<int, Time> > eventArrivalTimeVec;
	std::vector<std::pair<int, Time> > stationArrivalTimeVec;
	void getEventsFromCSV(char* fname);
	void getStations(std::vector<DroneStation> &_stations);

	std::vector<Event> getEvents();
	void updateEventsBtwRange(Time start, Time end);
	void start(Time start, Time end);
	void eventOccured(std::pair<double, double> coordinates, Time occuredTime);
	void eventArrived(std::pair<double, double> occuredCoord, Time occuredTime, std::pair<int, int>stationDroneIdx);
	void stationArrival(Time arrivalTime, std::pair<int, int>stationDroneIdx);
	struct comparator
	{
		bool operator()(Event& lhs, Event& rhs)
		{
			return (Time::timeComparator(lhs.getOccuredDate(), rhs.getOccuredDate()));
		}
	};

};
#endif
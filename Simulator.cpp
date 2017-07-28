/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
#include "Simulator.h"
#include <algorithm>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

/**
@brief get events from CSV file
@details
@param fname
@return 2-D vector of longitude, latitude, time of events
*/
void Simulator::getEventsFromCSV(char* fname)
{
	FILE *fr;

	ifstream file(fname);
	vector< vector<double> > _data;
	string line;
	fopen_s(&fr, fname, "r");

	while (getline(file,line))
	{
		double lng, lat, oDate, oTime, aDate, aTime;
		vector <double> newline;
		fscanf_s(fr, "%lf %lf %lf %lf %lf %lf\n", &lng, &lat, &oDate, &oTime, &aDate, &aTime);
		
		Time occuredDate, ambulDate;
		occuredDate.year = int(oDate / 100);
		occuredDate.month = int(oDate) % 100;
		occuredDate.hour = int(oTime / 100);
		occuredDate.min = int(oTime) % 100;
		ambulDate.year = int(aDate / 100);
		ambulDate.month = int(aDate) % 100;
		ambulDate.hour = int(aTime / 100);
		ambulDate.min = int(aTime) % 100;
		Event(lat, lng, occuredDate, ambulDate);

	}
	fclose(fr);
}

std::vector<Event> Simulator::getEvents()
{
	return events;
}


/**
@brief find the range of event from start time to end time
@details
@param starttime, endtime, event vector
@return
*/
void Simulator::updateEventsBtwRange(Time start, Time end, std::vector <Event> &_events)
{
	std::vector <Event> events;
	events = getEvents();
	//std::sort(events.begin(), events.end(), Event :: occuredDateComparator);
	std::sort(events.begin(), events.end());
	int i = 0, start_index = 0, end_index = 0;
	for (std :: vector <Event> ::iterator it = events.begin(); it!= events.end(); ++it)
	{
		if (Time :: timeComparator(it->getOccuredDate(), start)) 
		{
			start_index++;
			end_index++;
		}
		else if (Time :: timeComparator(it->getOccuredDate(), end)) end_index++;
	}
	events.erase(events.begin(), events.begin() + start_index);
	events.erase(events.begin() + end_index, events.end());
	_events = events;
}

/**
@brief simulating
@details simulate each events
@param event
@return
*/
void Simulator::simulation(Time start, Time end)
{
	getEventsFromCSV("data.csv");
	std::vector <DroneStation> stations;
	std::vector <Event> eventsInRange;
	updateEventsBtwRange(start, end, eventsInRange);
	for (auto it = eventsInRange.begin(); it != eventsInRange.end(); ++it)
	{
		std::pair<double, double> p = it->getCoordinates();
		DroneStationFinder finder(p);
		int stationNum = finder.stationFinder();
		PathPlanner pathPlanner;
		pathPlanner.calcTravelTime(stations[stationNum].stationLat, stations[stationNum].stationLng, p.first, p.second);

	}
}
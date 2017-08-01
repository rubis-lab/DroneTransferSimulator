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
	string line;
	fopen_s(&fr, fname, "r");

	while(getline(file,line))
	{
		double lng, lat, oDate, oTime, aDate, aTime;
		vector <double> newline;
		fscanf_s(fr, "%lf %lf %lf %lf %lf %lf\n", &lng, &lat, &oDate, &oTime, &aDate, &aTime);
		
		Time occuredDate, ambulDate;
		occuredDate.year = int(oDate / 10000);
		occuredDate.month = int(oDate / 100000) /100;
		occuredDate.date = int(oDate) % 100;
		occuredDate.hour = int(oTime / 100);
		occuredDate.min = int(oTime) % 100;
		ambulDate.year = int(aDate / 10000);
		ambulDate.month = int(aDate/ 10000) / 100;
		ambulDate.date = int(aDate) % 100; 
		ambulDate.hour = int(aTime / 100);
		ambulDate.min = int(aTime) % 100;

		events.push_back(new Event(lat, lng, occuredDate, ambulDate));
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
void Simulator::updateEventsBtwRange(Time start, Time end)
{
	if(Time::timeComparator(end, start)) return;

	std::sort(events.begin(), events.end());
	int i = 0, startIndex = 0, endIndex = 0;
	for(auto it = events.begin(); it!= events.end(); ++it)
	{
		if(Time::timeComparator(start, it->getOccuredDate()))
		{
			startIndex++;
			endIndex++;
		}
		else if(Time::timeComparator(it->getOccuredDate(), end)) endIndex++;
	}

	if(endIndex <= startIndex) return;
	if(endIndex == startIndex + 1) std::cout << "No events" << std::endl;

	events.erase(events.begin(), events.begin() + startIndex);
	events.erase(events.begin() + endIndex, events.end());
	sortedEvents = events;
}

/**
@brief simulating
@details simulate each events
@param event
@return
*/
void Simulator::start(Time start, Time end)
{
	getEventsFromCSV("data.csv");
	updateEventsBtwRange(start, end);
	for(auto it = sortedEvents.begin(); it != sortedEvents.end(); ++it)
	{
		std::pair<double, double> occuredCoordinates = it->getCoordinates();
		DroneStationFinder finder(occuredCoordinates);
		int stationIndex = finder.findCloestStation();
		int droneIndex = finder.findAvailableDrone(stationIndex);
		double distance = finder.getDistanceFromRecentEvent(stations[stationIndex].stationLng,stations[stationIndex].stationLat);
		PathPlanner pathPlanner;
		double calculatedTime;
		pathPlanner.calcTravelTime(stations[stationIndex].stationLat, stations[stationIndex].stationLng, occuredCoordinates.second, occuredCoordinates.first, calculatedTime);

		stations[stationIndex].transfer(droneIndex,distance, it->getOccuredDate(), calculatedTime);
	}
}
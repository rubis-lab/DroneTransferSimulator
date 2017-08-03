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

		events.push_back(Event(lat, lng, occuredDate, ambulDate));
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
	sortedEvents = std::vector<Event>(events.begin() + startIndex, events.begin() + endIndex);
	for(i = 0; i != std::distance(sortedEvents.begin(), sortedEvents.end());) 
	{
		occuredTimeVec.push_back(i);
	}
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


	Time currentTime = start;
	while (true)
	{
		if (Time::isSame(currentTime, end)) return;

		for(int i = 0; i != std::distance(occuredTimeVec.begin(), occuredTimeVec.end());)
		{
			if(Time::isSame(currentTime, sortedEvents[i].getOccuredDate()))
			{
				eventOccured(sortedEvents[i].getCoordinates(),sortedEvents[i].getOccuredDate());
				return;
			}
		}

		for (int i = 0; i != std::distance(eventArrivalTimeVec.begin(), eventArrivalTimeVec.end());)
		{
			if (Time::isSame(currentTime, eventArrivalTimeVec[i].second))
			{
				comingBack();
				return;
			}
		}

		for (int i = 0; i != std::distance(stationArrivalTimeVec.begin(), stationArrivalTimeVec.end());)
		{
			if (Time::isSame(currentTime, stationArrivalTimeVec[i].second))
			{
				return;
			}
		}

		currentTime = Time::timeAdding(currentTime, 60);
	}
}


void Simulator::eventOccured(std::pair<double, double> coordinates, Time occuredTime)
{
	DroneStationFinder finder(coordinates);

	int stationIndex = finder.findCloestStation();
	int droneIndex = finder.findAvailableDrone(stationIndex);

	double distance = finder.getDistanceFromRecentEvent(stations[stationIndex].stationLng, stations[stationIndex].stationLat);
	
	PathPlanner pathPlanner;
	double calculatedTime;
	calculatedTime = pathPlanner.calcTravelTime(stations[stationIndex].stationLat, stations[stationIndex].stationLng, coordinates.second, coordinates.first);

	stations[stationIndex].transfer(droneIndex, distance, occuredTime, calculatedTime);

	Time eventArrivalTime = Time::timeAdding(occuredTime, calculatedTime);

	return;
}

void Simulator::comingBack()
{

	return;
}
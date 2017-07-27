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
@return data
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
		double _lng, _lat, _oDate, _oTime, _aDate, _aTime;
		vector <double> newline;
		fscanf_s(fr, "%lf %lf %lf %lf %lf %lf\n", &_lng, &_lat, &_oDate, &_oTime, &_aDate, &_aTime);
		
		Time oDate, aDate;
		oDate.year = int(_oDate / 100);
		oDate.month = int(_oDate) % 100;
		oDate.hour = int(_oTime / 100);
		oDate.min = int(_oTime) % 100;
		aDate.year = int(_aDate / 100);
		aDate.month = int(_aDate) % 100;
		aDate.hour = int(_aTime / 100);
		aDate.min = int(_aTime) % 100;
		Event(_lat, _lng, oDate, aDate);

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
	std::sort(events.begin(), events.end(), Event :: occuredDateComparator);
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
	std::vector <Event> eventsInRange;
	updateEventsBtwRange(start, end, eventsInRange);
	for (std::vector <Event> ::iterator it = eventsInRange.begin(); it != eventsInRange.end(); ++it)
	{
	}
}
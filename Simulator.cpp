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
void Simulator::getEventsFromCSV(char* fname, std ::vector < std::vector <double> > *data)
{
	FILE *fr;

	ifstream file(fname);
	vector< vector<double> > _data;
	string line;
	fopen_s(&fr, fname, "r");

	while (getline(file,line))
	{
		double _lng, _lat, _oDate, _oTime, ambulDate, ambulTime;
		vector <double> newline;
		fscanf_s(fr, "%lf %lf %lf %lf %lf %lf\n", &_lng, &_lat, &_oDate, &_oTime, &ambulDate, &ambulTime);

		newline.push_back(_lng);
		newline.push_back(_lat);
		newline.push_back(_oDate);
		newline.push_back(_oTime);
		newline.push_back(ambulDate);
		newline.push_back(ambulTime);
		_data.push_back(newline);

	}
	fclose(fr);
	*data = _data;
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
void Simulator::updateEventsBtwRange(int start, int end, std::vector < std::vector <double> > data)
{
	std::vector < std::vector <double> > newdata;
	std::sort(events.begin(), events.end(), Event :: myCompare);
	int i = 0, start_index = 0, end_index = 0;
	int date;
	while (true) {
		date = int(data[i][2]) * 10000 + int(data[i][3]);
		if (date < start) {
			start_index++;
			end_index++;
			i++;
		}
		else if (date < end) {
			end_index++;
			i++;
		}
	}
	data.erase(data.begin(), data.begin() + start_index);
	data.erase(data.begin() + end_index, data.end());
}

/**
@brief simulating
@details simulate each events
@param event
@return
*/
void Simulator::simulation(int start, int end)
{
	std::vector < std::vector <double> > data;
	getEventsFromCSV("data.csv", &data);
	updateEventsBtwRange(start, end, data);
	int i;
	for (i = 0; data.size(); i++) {
		events.push_back(Event(data[i][0], data[i][1], int(data[i][2])*10000 +int(data[i][3]), int(data[i][4])*10000 +int(data[i][5])));
	}
}
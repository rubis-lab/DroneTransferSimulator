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
#include <queue>
#include <utility>

void Simulator::getStations(std::vector<DroneStation> &_stations)
{
	_stations = stations;
}

/**
@brief get events from CSV file
@details
@param fname
@return 2-D vector of longitude, latitude, time of events
*/
void Simulator::getEventsFromCSV(char* fname)
{
	FILE *fr;

	std::ifstream file(fname);
	std::string line;
	fopen_s(&fr, fname, "r");

	while(getline(file,line))
	{
		double lng, lat, oDate, oTime, aDate, aTime;
		std::vector <double> newline;
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

		Event::eventType e = Event::E_EVENT_OCCURED;
		events.push_back(Event(lat, lng, occuredDate, ambulDate, e)); //E_EVENT_OCCURED
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
}

/**
@brief simulating
@details simulate each events
@param start and end time
@return
*/
void Simulator::start(Time start, Time end)
{
	getEventsFromCSV("data.csv");
	updateEventsBtwRange(start, end);

	Time currentTime = start;

	std::priority_queue<int, std::vector<Event>, comparator> events;

	while (!events.empty())
	{
		Event e = events.top();
		events.pop();

		switch (e.getEventType())
		{
		case Event::E_EVENT_OCCURED:
			eventOccured(e.getCoordinates(), e.getOccuredDate());
			break;

		case Event::E_EVENT_ARRIVAL:
			eventArrived(e.getCoordinates(), e.getOccuredDate(), e.getStationDroneIdx());
			break;
		case Event::E_STATION_ARRIVAL:
			stationArrival(e.getOccuredDate(),e.getStationDroneIdx());
			break;
		}
	}
}

/**
@brief simulation from drone departure to drone arrival
@details
@param event occured coordinates and time
@return
*/
void Simulator::eventOccured(std::pair<double, double> coordinates, Time occuredTime)
{
	//find stations and drone
	DroneStationFinder finder(coordinates);
	finder.findAvailableStations();
	std::pair<int,int> stationDroneIdx = finder.findAvailableDrone(occuredTime);

	DroneStation s = stations[stationDroneIdx.first];
	Drone d = s.drones[stationDroneIdx.second];

	double distance = finder.getDistanceFromRecentEvent(s.stationLng, s.stationLat);

	//calculate time
	PathPlanner pathPlanner;
	double calculatedTime;
	calculatedTime = pathPlanner.calcTravelTime(s.stationLat, s.stationLng, coordinates.second, coordinates.first);

	Time droneArrivalTime = Time::timeAdding(occuredTime, calculatedTime);

	//battery consumption
	d.fly(distance);
	d.setStatus(1);

	//declare coming event
	Event::eventType type = Event::E_EVENT_ARRIVAL;
	Event e(coordinates.first, coordinates.second, droneArrivalTime, droneArrivalTime, type);
	e.setStationDroneIdx(stationDroneIdx.first, stationDroneIdx.second);
	events.push_back(e);
	return;
}


/**
@brief simulation from drone arrival to drome coming back
@details
@param event occured coordinates, drone arrival time, index of station and drone
@return
*/
void Simulator::eventArrived(std::pair<double, double> occuredCoord, Time occuredTime, std::pair<int, int> stationDroneIdx)
{
	//time to return to the Drone Station
	PathPlanner pathPlanner;
	double calculatedTime;
	calculatedTime = pathPlanner.calcTravelTime(occuredCoord.second, occuredCoord.first, stations[stationDroneIdx.first].stationLat, stations[stationDroneIdx.first].stationLng);
	
	//time when drone reach the station
	Time droneArrivalTime = Time::timeAdding(occuredTime, calculatedTime);


	//battery consumption
	DroneStationFinder f(std::make_pair(occuredCoord.first, occuredCoord.second));
	double distance = f.getDistanceFromRecentEvent(stations[stationDroneIdx.first].stationLng, stations[stationDroneIdx.first].stationLat);
	stations[stationDroneIdx.first].drones[stationDroneIdx.second].fly(distance);

	//event of arriving
	Event::eventType type = Event::E_STATION_ARRIVAL;
	Event e(occuredCoord.first, occuredCoord.second, droneArrivalTime, droneArrivalTime, type);
	e.setStationDroneIdx(stationDroneIdx.first, stationDroneIdx.second);
	events.push_back(e);
	return;
}

void Simulator::stationArrival(Time arrivalTime, std::pair<int, int>stationDroneIdx)
{
	Drone d = stations[stationDroneIdx.first].drones[stationDroneIdx.second];
	d.setStatus(2);
	d.setChargeStartTime(arrivalTime);
}
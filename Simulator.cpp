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
#include <utility>
#include <sstream>

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
	std::ifstream file(fname);

	while(file)
	{
		std::string line;
		if(!std::getline(file, line)) break;

		std::istringstream ss(line);
		std::vector <std::string> record;

		while(ss)
		{
			std::string s;
			if(!std::getline(ss, s, ',')) break;
			record.push_back(s);
		}
		if (record.size() != 6) break;

		Time occuredDate, ambulDate;
		double lng = stod(record[0], nullptr);
		double lat = stod(record[1], nullptr);
		occuredDate.year = stoi(record[2], nullptr) / 10000;
		occuredDate.month = (stoi(record[2], nullptr) % 10000) / 100;
		occuredDate.date = stoi(record[2], nullptr) % 100;
		occuredDate.hour = stoi(record[3], nullptr) / 100;
		occuredDate.min = stoi(record[3], nullptr) % 100;
		ambulDate.year = stoi(record[4], nullptr) / 10000;
		ambulDate.month = (stoi(record[4], nullptr) % 10000) / 100;
		ambulDate.date = stoi(record[4], nullptr) % 100;
		ambulDate.hour = stoi(record[5], nullptr) / 100;
		ambulDate.min = stoi(record[5], nullptr) % 100;

		Event::eventType e = Event::E_EVENT_OCCURED;
		events.push_back(Event(lat, lng, occuredDate, ambulDate, e)); //E_EVENT_OCCURED
	
	}
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
	for (auto it = events.begin(); it != events.end(); ++it)
	{
		if (Time::timeComparator(it->getOccuredDate(), start))
		{
			startIndex++;
			endIndex++;
		}
		else if (Time::timeComparator(it->getOccuredDate(), end)) endIndex++;
		else break;
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

	for (int i = 0; i != std::distance(sortedEvents.begin(), sortedEvents.end()); i++)
	{
		eventsQueue.push(sortedEvents[i]);
	}

	while (!eventsQueue.empty())
	{
		Event e = eventsQueue.top();
		eventsQueue.pop();

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
	if(stationDroneIdx.first == -1) return;

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
	eventsQueue.push(e);
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
	eventsQueue.push(e);
	return;
}


void Simulator::stationArrival(Time arrivalTime, std::pair<int, int>stationDroneIdx)
{
	Drone d = stations[stationDroneIdx.first].drones[stationDroneIdx.second];
	d.setStatus(2);
	d.setChargeStartTime(arrivalTime);
}

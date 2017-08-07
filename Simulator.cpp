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

		events.push_back(Event(lat, lng, occuredDate, ambulDate)); //E_EVENT_OCCURED
		
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

	std::priority_queue<int, std::vector<Event>, comparator> events;

	while (!events.empty())
	{
		Event e = events.top();
		events.pop();

		switch (e.getEventType())
		{
		case "E_EVENT_OCCURED":
			eventOccured(e.getCoordinates(), e.getOccuredDate());
			break;

		case "E_EVENT_ARRIVAL":
			eventArrived(e.getCoordinates(), e.getOccuredDate(), e.getStationDroneIdx());
			break;
		case "E_STATION_ARRIVAL":
			stationArrival(e.getOccuredDate(),e.getStationDroneIdx());
			break;
		}
	}
}

void Simulator::eventOccured(std::pair<double, double> coordinates, Time occuredTime)
{

	//find stations and drone
	DroneStationFinder finder(coordinates);
	int stationIndex = finder.findCloestStation();
	int droneIndex = finder.findAvailableDrone(stationIndex, occuredTime);

	double distance = finder.getDistanceFromRecentEvent(stations[stationIndex].stationLng, stations[stationIndex].stationLat);

	//calculate time
	PathPlanner pathPlanner;
	double calculatedTime;
	calculatedTime = pathPlanner.calcTravelTime(stations[stationIndex].stationLat, stations[stationIndex].stationLng, coordinates.second, coordinates.first);

	Time droneArrivalTime = Time::timeAdding(occuredTime, calculatedTime);

	//battery consumption, inStation=false
	stations[stationIndex].drones[droneIndex].fly(distance, false);

	//declare coming event
	std::pair<double, double> startCoord = std::make_pair(stations[stationIndex].stationLat, stations[stationIndex].stationLng);
	Event e(coordinates.first, coordinates.second, droneArrivalTime, droneArrivalTime); //E_EVENT_ARRIVAL
	e.setStationDroneIdx(stationIndex, droneIndex);
	events.push_back(e);
	return;
}

void Simulator::eventArrived(std::pair<double, double> occuredCoord, Time occuredTime, std::pair<int, int> stationDroneIdx)
{
	//time to return to the Drone Station
	PathPlanner pathPlanner;
	double calculatedTime;
	calculatedTime = pathPlanner.calcTravelTime(occuredCoord.first, occuredCoord.second, stations[stationDroneIdx.first].stationLat, stations[stationDroneIdx.first].stationLng);
	
	//time when drone reach the station
	Time droneArrivalTime = Time::timeAdding(occuredTime, calculatedTime);

	double distance; //have to write

	//battery consumption, inStation=false
	stations[stationDroneIdx.first].drones[stationDroneIdx.second].fly(distance, false);

	//event of arriving
	Event e(occuredCoord.first, occuredCoord.second, droneArrivalTime, droneArrivalTime);
	e.setStationDroneIdx( stationDroneIdx.first, stationDroneIdx.second);
	events.push_back(Event(occuredCoord.first, occuredCoord.second, droneArrivalTime, droneArrivalTime)); //E_STATION_ARRIVAL
	return;
}

void Simulator::stationArrival(Time arrivalTime, std::pair<int, int>stationDroneIdx)
{
	//add to charging drone, inStation=true
	stations[stationDroneIdx.first].addChargingDrone(arrivalTime, stationDroneIdx);
}
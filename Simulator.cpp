/**
@file
@date 2017/07/21
@author Minji and hexoul
@brief
*/
#include "Simulator.h"
#include <algorithm>

/**
@brief get events from CSV file
@details
@param fname
@return
*/
void Simulator::getEventsFromCSV(char* fname)
{
	
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
void Simulator::updateEventsBtwRange(time_t start, time_t end)
{
	std::sort(events.begin(), events.end());
}

/**
@brief simulating
@details simulate each events
@param event
@return
*/
void Simulator::simulation()
{

}
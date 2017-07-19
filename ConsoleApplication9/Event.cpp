/**
@file
@date 2017/07/19
@author Minji
@brief
*/

#include <vector>
#include <algorithm>

using namespace std;

/**
@brief event class
@details
@author Minji
@date 2017-07-19
@version
*/
class Event {
private:
	int num;
	int latitude, longitude;
	int time[5];

public:
	vector<Center> center;
	/**
	@brief operator to compare time between events
	*/
	bool operator > {
	};

	/**
	@brief find the center
	@details find the center that coverage is bigger than distane from event.
	@param center, latitude, longitude
	@return array of center numbers sorted by distance from event
	*/
	int findCenter();
	/**
	@brief fine the drone
	@details find the drone to transfer AED by considering drivable distnace
	@param output of findCenter(), center vector
	@return array of center number, drone number

	*/
	int findDrone();

	/**
	@brief calculating time to destination
	@details
	@param location of center, location of event
	@return time

	*/
	int timeToDest();

};
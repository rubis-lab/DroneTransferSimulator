#ifndef _H_DRONE_
#define _H_DRONE_
#include <utility>
#include <vector>
#include "Time.h"

class Drone
{
private:
	double battery, chargingRate;	/* unit: percent */
	double availDist, maxAvailDist; /* available distance of Drone */
	std::pair<double, double> destination;
	std::vector<int> chargingDrone;

public:
	Drone(double _maxAvilDist);
	void fly(double distance);
	void charge(Time startTime, Time endTime);
	double returnBattery();
	void setBattery(double _battery);
	double returnAvailDist();
};

#endif
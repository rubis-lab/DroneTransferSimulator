#ifndef _H_DRONE_
#define _H_DRONE_
#include <utility>
#include "Time.h"

class Drone
{
private:
	double battery, chargingRate;	/* unit: percent */
	double availDist, maxAvailDist; /* available distance of Drone */
	std::pair<double, double> destination;

public:
	Drone(double _maxAvilDist);
	void fly(double distance);
	void updateBattery(Time startTime, Time endTime);
	double returnAvailDist();
};

#endif
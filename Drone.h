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
	bool inStation;
	std::pair<double, double> destination;
	std::vector<int> chargingDrone;

public:
	Drone(double _maxAvilDist);
	void fly(double distance, bool inStation);
	void charge(Time startTime, Time endTime);
	double returnBattery();
	void setBattery(double _battery);
	double returnAvailDist();
	bool isInStation();
	void setInStation(bool _inStation);
};

#endif
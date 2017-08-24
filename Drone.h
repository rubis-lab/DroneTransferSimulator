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
	int status;						/* 0: in station, 1: flying, 2: charging*/
	std::pair<double, double> destination;
	Time chargeStartTime;

public:
	Drone(double _maxAvilDist);
	void fly(double distance);
	void charge(Time startTime, Time endTime);
	double returnBattery();
	void setBattery(double _battery);
	double returnAvailDist();
	int returnStatus();
	void setStatus(int _status);
	void setChargeStartTime(Time _chargeStartTime);
	Time getChargeStartTime();
};

#endif
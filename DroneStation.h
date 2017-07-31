#include <vector>
#include "Drone.h"
#include "Time.h"

#ifndef _H_DRONE_STATION_
#define _H_DRONE_STATION_

class DroneStation
{
private:
	int nDrone, nMaxDrone;
	void setDroneNum(int n);
	std::vector<Drone> drones;
	std::vector<std::tuple<int, double, Time>> flyingDrone;

public:
	double coverRange;
	double stationLng, stationLat;
	DroneStation(int _nMaxDrone, double _coverRange, double _stationLng, double _stationLat);
	void droneFly(int droneIndex, double distance, Time dispatchTime, int timeCalculated);
	void updateFlyingDrones(Time currentTime, int calculatedTime);
};

#endif
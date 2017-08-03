#include <vector>
#include <tuple>
#include "Drone.h"
#include "Time.h"

#ifndef _H_DRONE_STATION_
#define _H_DRONE_STATION_

class DroneStation
{
private:
	int nDrone, nMaxDrone;
	void setDroneNum(int n);
	std::vector<std::tuple<int , double, Time, bool> > flyingDrone;

public:
	std::vector<Drone> drones;
	double coverRange;
	double stationLng, stationLat;
	DroneStation(int _nMaxDrone, double _coverRange, double _stationLng, double _stationLat);
	void transfer(int droneIndex, double distance, Time occuredTime, double calculatedTime);
	void updateFlyingDrones(Time currentTime, int calculatedTime);
};

#endif
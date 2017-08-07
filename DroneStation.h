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
	void setDroneNum(int n);\

	struct chargingDrone
	{
		int droneIndex;
		Time centerArrivalTime;
	};
	std::vector<chargingDrone> chargingDrones;

public:
	std::vector<Drone> drones;
	double coverRange;
	double stationLng, stationLat;
	DroneStation(int _nMaxDrone, double _coverRange, double _stationLng, double _stationLat);
	void updateChargingDrones(Time currentTime);
	void addChargingDrone(Time arrivalTime, std::pair<int,int> stationDroneIdx);
};

#endif
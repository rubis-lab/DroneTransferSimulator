#ifndef _H_DRONE_STATION_
#define _H_DRONE_STATION_

class DroneStation
{
private:
	int nDrone, nMaxDrone;

	void setDroneNum(int n);

public:
	DroneStation(int _nMaxDrone);
	
};

#endif
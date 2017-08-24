#include "DroneStation.h"
#include <vector>

class StationManager
{
private:
	static std::vector<DroneStation> stations;
public:
	void getStationLocation(int stationNum, double &lat, double &lng);
	void setStationLocation(int stationNum, double lat, double lng);
	void setStationVector(int maxDrone, double coverRange, double stnLng, double stnLat);
	static std::vector<DroneStation> getStations();
};
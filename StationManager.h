#include "DroneStation.h"
#include <vector>

class StationManager
{
private:
	std::vector<DroneStation> stations;
public:
	void getStationLocation(int stationNum, double &lat, double &lng);
	void setStationLocation(int stationNum, double lat, double lng);

};
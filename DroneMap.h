#include <vector>
#include <map>

#include <my_global.h>
#include <WinSock2.h>
#include <mysql.h>

#ifndef _H_DRONE_MAP_
#define _H_DRONE_MAP_

#define DB_HOST		"prism.snu.ac.kr"
#define DB_USER		"root"
#define DB_PASS		"4542rubis"
#define DB_NAME		"WonseokMap"
#define TBL_NAME	"Seoul_40x40_500x500"

struct DroneMapData
{
	double lat, lng;
	double landElevation, buildingHeight;

	DroneMapData() = default;

	DroneMapData(double _lat, double _lng, double _landElevation, double _buildingHeight)
		: lat(_lat), lng(_lng), landElevation(_landElevation), buildingHeight(_buildingHeight) {}

};

class DroneMap
{
private:
	static DroneMap* instance;

	MYSQL* dbConn;
	std::vector<DroneMapData> resultSet;

	std::map<std::pair<int, int>, DroneMapData> dataMap;

	bool hasConnection;

	bool doQuery(std::string command);
	void connectDB();
	void closeDB();

public:
	static DroneMap* getInstance()
	{
		if(instance == NULL) instance = new DroneMap;
		return instance;
	}

	DroneMap();
	const std::vector<DroneMapData> getData(int srcRowIdx, int srcColIdx, int dstRowIdx, int dstColIdx);
};

#endif
#include <vector>

#include <my_global.h>
#include <WinSock2.h>
#include <mysql.h>

#define DB_HOST	"prism.snu.ac.kr"
#define DB_USER	"root"
#define DB_PASS	"4542rubis"
#define DB_NAME	"WonseokMap"

#ifndef _H_DRONE_MAP_
#define _H_DRONE_MAP_

struct DroneMapData
{
	double lat, lng;
	double landElevation, buildingHeight;

	DroneMapData(double _lat, double _lng, double _landElevation, double _buildingHeight)
		: lat(_lat), lng(_lng), landElevation(_landElevation), buildingHeight(_buildingHeight) {}
};

class DroneMap
{
private:
	static DroneMap* instance;

	MYSQL* dbConn;
	std::vector<DroneMapData> resultSet;
	bool hasConnection;

	bool doQuery(char* command);
	void connectDB();
	void closeDB();

public:
	static DroneMap* getInstance()
	{
		if(instance == NULL) instance = new DroneMap;
		return instance;
	}

	DroneMap();

	std::vector<DroneMapData> getData();
};

#endif
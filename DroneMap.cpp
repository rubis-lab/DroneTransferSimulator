#include <iostream>
#include "DroneMap.h"

#pragma comment(lib, "libmysql.lib")

DroneMap* DroneMap::instance = NULL;

DroneMap::DroneMap()
{
	connectDB();
	if(!hasConnection) return;
	getData("select * from Seoul_40x40_500x500 where ROW >= 1 and ROW <= 10 and COL >= 1 and COL <= 10");
	getData("select * from Seoul_40x40_500x500 where ROW >= 119 and ROW <= 10 and COL >= 1 and COL <= 10");
	getData("select * from Seoul_40x40_500x500 where ROW >= 1 and ROW <= 10 and COL >= 10 and COL <= 10");
	std::cout.precision(15);
	for (auto e : resultSet) {
		std::cout << e.lat << ", " << e.lng << std::endl;
	}
}

void DroneMap::connectDB()
{
	hasConnection = false;
	
	mysql_init(&conn);
 	dbConn = mysql_real_connect(&conn, DB_HOST, DB_USER, DB_PASS, DB_NAME, 3306, (char *)NULL, 0);
	if(dbConn != NULL) hasConnection = true;
}

void DroneMap::closeDB()
{
	if(dbConn != NULL) mysql_close(dbConn);
}

bool DroneMap::doQuery(char* command)
{
	if(!hasConnection) return false;
	
	int queryStat = 0;
	queryStat = mysql_query(dbConn, command);
	if(queryStat != 0) return false;
	
	return true;
}

std::vector<DroneMapData> DroneMap::getData(char* command)
{
	MYSQL_RES   *res;
 	MYSQL_ROW   sqlRow;
	
	resultSet.erase(resultSet.begin(), resultSet.end());
	if(doQuery(command))
	{
		res = mysql_store_result(dbConn);
 
 		while ((sqlRow = mysql_fetch_row(res)) != NULL)
		{
 			DroneMapData data(atof(sqlRow[2]), atof(sqlRow[3]), atof(sqlRow[4]), atof(sqlRow[5]));
 			resultSet.push_back(data);
 		}

		mysql_free_result(res);
	}	

	return resultSet;
}
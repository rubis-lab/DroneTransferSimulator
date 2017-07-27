#include <iostream>
#include <string>
#include "DroneMap.h"

#pragma comment(lib, "libmysql.lib")

#define BUF_SIZE	1024

DroneMap* DroneMap::instance = NULL;

DroneMap::DroneMap()
{
	connectDB();
	if (!hasConnection) return;
}

void DroneMap::connectDB()
{
	hasConnection = false;

	dbConn = mysql_init(NULL);
	if (dbConn == NULL) return;

	mysql_real_connect(dbConn, DB_HOST, DB_USER, DB_PASS, DB_NAME, 3306, (char *)NULL, 0);

	if (dbConn != NULL) hasConnection = true;
}

void DroneMap::closeDB()
{
	if (!hasConnection) return;
	else if (dbConn != NULL) mysql_close(dbConn);
}

bool DroneMap::doQuery(std::string command)
{
	if (!hasConnection) return false;

	int queryStat = 0;
	queryStat = mysql_query(dbConn, command.c_str());
	if (queryStat != 0) return false;

	return true;
}

const std::vector<DroneMapData> DroneMap::getData(int srcRowIdx, int srcColIdx, int dstRowIdx, int dstColIdx)
{
	MYSQL_RES   *res;
	MYSQL_ROW   sqlRow;
	std::string queryStr = "select * from ";
	queryStr += TBL_NAME;

	/* Do ascending order for query */
	if (dstRowIdx < srcRowIdx) std::swap(srcRowIdx, dstRowIdx);
	if (dstColIdx < srcColIdx) std::swap(srcColIdx, dstColIdx);

	/* Add where statement to query */
	char queryWhere[BUF_SIZE] = { 0, };
	sprintf(queryWhere, " where ROW >= %d and ROW <= %d and COL >= %d and COL <= %d", srcRowIdx, dstRowIdx, srcColIdx, dstColIdx);
	queryStr += queryWhere;

	/* Clear the vector for result */
	if (!resultSet.empty()) resultSet.clear();

	if (doQuery(queryStr))
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
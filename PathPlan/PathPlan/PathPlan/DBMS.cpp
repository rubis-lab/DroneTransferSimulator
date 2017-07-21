#include <iostream>
#include <vector>
#include <cstdlib>
#include <my_global.h>
#include <winsock2.h>
#include <mysql.h>
using namespace std;
#pragma comment(lib, "libmysql.lib")
#define DB_HOST "prism.snu.ac.kr"
#define DB_USER "root"
#define DB_PASS "4542rubis"
#define DB_NAME "WonseokMap"

struct Data {
	double lat;
	double lng;
	double landElevation;
	double buildingHeight;
	Data(double _lat, double _lng, double _landElevation, double _buildingHeight)
		: lat(_lat), lng(_lng), landElevation(_landElevation), buildingHeight(_buildingHeight) {};
};

class DBMS {
private:
	vector<Data> resultSet;
public:
	DBMS() = default;
	DBMS(char *command) {
		MYSQL       *connection = NULL, conn;
		MYSQL_RES   *res;
		MYSQL_ROW   sqlRow;
		int       queryStat;
		mysql_init(&conn);
		connection = mysql_real_connect(&conn, DB_HOST, DB_USER, DB_PASS, DB_NAME, 3306, (char *)NULL, 0);

		if (connection == NULL)
			cout << " >> Mysql connection error : " << mysql_error(&conn) << endl;
		cout << " >> Mysql connection success" << endl;

		queryStat = mysql_query(connection, command);
		if (queryStat != 0)
			cout << " >> Mysql query error : " << mysql_error(&conn) << endl;
		cout << " >> Mysql query success" << mysql_error(&conn) << endl;

		res = mysql_store_result(connection);

		while ((sqlRow = mysql_fetch_row(res)) != NULL) {
			Data data(atof(sqlRow[2]), atof(sqlRow[3]), atof(sqlRow[4]), atof(sqlRow[5]));
			resultSet.push_back(data);
		}
		
		cout.precision(15);
		for (auto e : resultSet)
			cout << e.lat << " " << e.lng << " " << e.landElevation << " " << e.buildingHeight << endl;
		cout << "--------------------------------------" << endl;

		mysql_free_result(res);
		mysql_close(connection);
	}


};
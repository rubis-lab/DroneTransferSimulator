#include "Block.cpp"
#include "DBMS.cpp"
#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>
#define BLKSIZE 10
using namespace std;
typedef pair<double, double> COORDS;

class Path {
private:
	COORDS srtWGS, endWGS;
	vector<Block> blkPath;
	double totalTime;

public:
	Path() = default;
	Path(COORDS _srtWGS, COORDS _endWGS) : srtWGS(_srtWGS), endWGS(_endWGS) {
	//	DBMS dbms("select * from Seoul_40x40_500x500 where LAT >= 37.578942 and LAT <= 37.584839 and LNG >= 126.997512 and LNG <= 126.998668");
		COORDS SW = make_pair(min(srtWGS.first, endWGS.first), min(srtWGS.second, endWGS.second));
		COORDS NE = make_pair(max(srtWGS.first, endWGS.first), max(srtWGS.second, endWGS.second));

		cout << SW.first << ", " << SW.second << endl;
		cout << NE.first << ", " << NE.second << endl;
	}

	/*
		COORD srtKM = kmConversion(srtWGS);
		COORD endKM = kmConversion(endWGS);
		double diffX = endKM.first - srtKM.first;
		double diffY = endKM.second - srtKM.second;
		double dist = diffX*diffX + diffY*diffY;
		double theta = atan2(diffX, diffY);

		double srtHei = landElevation(srtKM.first, srtKM.second, theta);
		double endHei = landElevation(endKM.first, endKM.second, theta);

		double maxHeight = 0.0;
		for (int i = 0; i < (int)(dist / BLKSIZE); i++) {
			double x = srtKM.first + i*BLKSIZE*cos(theta);
			double y = srtKM.second + i*BLKSIZE*sin(theta);
			maxHeight = max(maxHeight, buildingHeight(x, y, theta) + landElevation(x, y, theta));
		}
	}


	// Traversal Path from start (Latitude, Longitude) to end (Latitude, Longitude)
	void flightPath(double srtLat, double srtLon, double endLat, double endLon);
	// WGS84 Coordinates into km Coordinates
	COORD kmConversion(COORD wgs);
	// Land elevation(m), Building height(m) along the area (x, y) in range of BLKSIZE in direction theta
	double landElevation(double x, double y, double theta);
	double buildingHeight(double x, double y, double theta);
	*/
};
#ifndef _H_PATH_PLANNER_
#define _H_PATH_PLANNER_

#include <fstream>
#include <sstream>
#include <vector>
#include <string>
#include <cstdlib>
#include <iostream>
#include <map>

#define CUBE_SIZE	10
#define UL_LAT		37.680000
#define UL_LNG		126.783400
#define LR_LAT		37.432499
#define LR_LNG		127.197999
#define D_LAT		((UL_LAT - LR_LAT) / 20000)
#define D_LNG		((LR_LNG - UL_LNG) / 20000)

class PathPlanner
{
private:
	/* Latitude and longitude of Source and Destination */
	double srcLat, srcLng;
	double dstLat, dstLng;

	/* key: in/out direction, value: map(key: in/out velocity, value: cubeTime) */
	std::map<std::pair<char, char>, std::map<std::pair<int, int>, double> > cubeTime;

	class Cube
	{
	private:
		int inVelocity, outVelocity;

	public:
		char inFace, outFace;
		Cube(char _inFace, char _outFace);

		int getType();
		double getRequiredTime();
	};

	// Traversal Path from start (Latitude, Longitude) to end (Latitude, Longitude)
 	std::vector<Cube> makeNaivePath(double srcLat, double srcLng, double dstLat, double dstLng);
	double calcMaxHeight(double srcLat, double srcLng, double dstLat, double dstLng);

public:
	PathPlanner();
	double calcTravelTime(double srcLat, double srcLng, double dstLat, double dstLng);

 	// WGS84 Coordinates into km Coordinates
	void convertWGStoKm(double wgsLat, double wgsLng, double &kmLat, double &kmLng);
	void convertWGStoRC(double wgsLat, double wgsLng, int &row, int &col);
	void convertRCtoWGS(int row, int col, double &wgsLat, double &wgsLng);
};

#endif
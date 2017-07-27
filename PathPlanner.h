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

#define UL_LAT		37.680000	/* Upper Left bound of latitute for Seoul_40x40_500x500 table */
#define UL_LNG		126.783400	/* Upper Left bound of longitude for Seoul_40x40_500x500 table */
#define LR_LAT		37.432499	/* Lower Right bound of latitute for Seoul_40x40_500x500 table */
#define LR_LNG		127.197999	/* Lower Right bound of longitude for Seoul_40x40_500x500 table */
#define D_LAT		((UL_LAT - LR_LAT) / 20000)	/* Delta between latitude */
#define D_LNG		((LR_LNG - UL_LNG) / 20000)	/* Delta between longitude */

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
		char inFace, outFace;
		int inVelocity, outVelocity;

	public:
		Cube(char _inFace, char _outFace);
		Cube(char _inFace, char _outFace, int _inVelocity, int _outVelocity);

		int getType();
	};

	void inputSimData();
	void storeSimData(char inFace, char outFace, int inVelocity, int outVelocity, double time);
	double getRequiredTime(int cubeType);

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
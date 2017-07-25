#include <vector>

#ifndef _H_PATH_PLANNER_
#define _H_PATH_PLANNER_

#define CUBE_SIZE	10

#define UB_LAT		37.680000	/* Upper bound of latitute for Seoul_40x40_500x500 table */
#define UB_LNG		126.783400	/* Upper bound of longitude for Seoul_40x40_500x500 table */
#define LB_LAT		37.432499	/* Lower bound of latitute for Seoul_40x40_500x500 table */
#define LB_LNG		127.197999	/* Lower bound of longitude for Seoul_40x40_500x500 table */
#define D_LAT		((UL_LAT - LR_LAT) / 20000)
#define D_LNG		((LR_LNG - UL_LNG) / 20000)

class PathPlanner
{
private:
	/* Latitude and longitude of Source and Destination */
	double srcLat, srcLng;
	double dstLat, dstLng;

	class Cube
	{
	private:
		char inFace, outFace;
		int inVelocity, outVelocity;

	public:
		Cube(char _inFace, char _outFace);

		int getType();
		double getRequiredTime();
	};

	// Traversal Path from start (Latitude, Longitude) to end (Latitude, Longitude)
 	std::vector<Cube> makeNaivePath(double srcLat, double srcLng, double dstLat, double dstLng);

public:
	double calcTravelTime(double srcLat, double srcLng, double dstLat, double dstLng);

 	// WGS84 Coordinates into km Coordinates
 	void convertWGS84toKm(double wgsLat, double wgsLng, double* kmLat, double* kmLng);
 	// Land elevation(m), Building height(m) along the area (x, y) in range of BLKSIZE in direction theta
 	double getLandElevation(double x, double y, double theta);
 	double getBuildingHeight(double x, double y, double theta);
};

#endif
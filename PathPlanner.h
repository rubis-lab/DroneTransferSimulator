#include <string>
#include <vector>

#define CUBE_SIZE	10

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
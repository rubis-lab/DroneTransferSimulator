#include <iostream>
#include <algorithm>
#include <cmath>
#define BLKSIZE 10
using namespace std;
typedef pair<double,double> COORD;

// Traversal Path from start (Latitude, Longitude) to end (Latitude, Longitude)
void flightPath (double srtLat, double srtLon, double endLat, double endLon);
// WGS84 Coordinates into km Coordinates
COORD kmConversion (COORD wgs);
// Land elevation(m), Building height(m) along the area (x, y) in range of BLKSIZE in direction theta
double landElevation (double x, double y, double theta);
double buildingHeight (double x, double y, double theta);

void flightPath (double srtLat, double srtLng, double endLat, double endLng) {
    COORD srt = kmConversion(make_pair(srtLat, srtLng));
    COORD end = kmConversion(make_pair(endLat, endLng));
    double diffX = end.first - srt.first;
    double diffY = end.second - srt.second;
    double dist = diffX*diffX + diffY*diffY;
    double theta = atan2(diffX, diffY);

    double srtHei = landElevation(srt.first, srt.second, theta);
    double endHei = landElevation(end.first, end.second, theta);

    double maxHeight = 0.0;
    for(int i = 0; i < (int)(dist/BLKSIZE); i++) {
        double x = srt.first + i*BLKSIZE*cos(theta);
        double y = srt.second + i*BLKSIZE*sin(theta);
        maxHeight = max(maxHeight, buildingHeight(x, y, theta) + landElevation(x, y, theta));
    }
}

int main() {
    return 0;
}

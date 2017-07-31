#ifndef _H_DRONE_
#define _H_DRONE_

class Drone
{
private:
	double battery;					/* unit: percent */
	double availDist, maxAvailDist; /* available distance of Drone */

public:
	Drone(double _maxAvilDist);
	void fly(double distance);
};

#endif
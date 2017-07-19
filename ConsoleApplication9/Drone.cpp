/**
@file
@date 2017/07/19
@author Minji
@brief
*/

#include <vector>
#include <algorithm>
using namespace std;

/**
@brief drone class
@details
@author Minji
@date 2017-07-19
@version
*/
class Drone {
private:
	int num;
	int drivable_dist;
	int chargingTime;
	int battery;

public:
	void upgradeDroneBattery();

};
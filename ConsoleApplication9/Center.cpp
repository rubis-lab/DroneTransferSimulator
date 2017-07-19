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
@brief center class
@details
@author Minji
@date 2017-07-19
@version
*/

class Center {
private:
	int num;
	int latitude, longitude;
	int droneNum;

public:
	int coverRange;
	/**
	@brief upgrade the number of drone in the center
	@details upgrade the change of the number of drone because of event right before
	@param
	@return
	*/
	void upgradeDroneNum();
	vector<Drone> drone;

};
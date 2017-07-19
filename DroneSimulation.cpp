#include <vector>
#include <algorithm>
using namespace std;

class Center {
private:
	int num; //중계소 번호
	int latitude, longitude; //중계소의 위도,경도
	vector<Drone> drone;
	int droneNum; //중계소의 드론 개수 (drone.size)
	int coverRange;

public:
	void upgradeDroneNum(); //이전 event부터 현재 시각까지 바뀐 각 Center의 dronenum 업그레이드

};

class CenterManager {


};

class Drone {
private:
	int num; //드론 번호
	int drivable_dist; //완전 충전 시 주행가능거리(드론의 성능)
	int chargingTime; //완전 충전까지 걸리는 시간
	int battery; //드론의 배터리 충전량

public:
	void upgradeDroneBattery(); //각 드론의 배터리 업그레이드

};


vector<Center> center;

class Event {
private:
	int latitude, longitude; //event 발생 위치
	int time[5]; //event 발생 시각

public:
	bool operator > {
		//사건 발생 시각을 비교하는 연산자
	};
	
	int findCenter(); // 중계소를 고른다 input: center, latitude, longitude , output: coverange가 거리보다 큰 중계소 번호들을 가까운 순서대로 배열로 출력
	int findDrone(); //출동할 드론을 찾는다(드론갯수, 배터리 고려) input:findCenter()에서 구한 배열, center , return: [중계소 번호, 드론 번호]
	int timeToDest(); //목적지까지 걸리는 시간 input:중계소 위치, event 발생위치, return: 시간(sec)
	
};

vector<Event> event_;

void simulation(int starttime[5], int endtime[5]) {
	// 시뮬레이션 시작, 끝 시간의 배열을 [연, 월, 일, 시각, 분]로 받는다
	range = findEventRange(event_, starttime[5], endtime[5]);
	/* range에 있는 event를 차례로 시행
	[CenterNum, DroneNum] = FindDrone()
	t = Center 위치와 사건 발생 위치를 받아와서 상준이가 만든 모듈로 시간을 받음
	output: [eventNum, t, isSuccessful]

	끝날 때 중계소의 upgradeDroneNum, upgradeDroneBattery
	*/
};

int findEventRange(event_, int starttime[5], endtime[5]) {
	//starttime~endtime 안에 벌어진 event의 범위 return

};

void main() {

	sort(event_);
	startTime = [];
	endTime = [];
	simulation(startTime, endTime);

}
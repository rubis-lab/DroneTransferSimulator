#pragma once
class Time {
public:
	int year, month, date, hour, min;
	
	static bool timeComparator(Time t1, Time t2);
};
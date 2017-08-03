#pragma once
class Time 
{
public:
	int year, month, date, hour, min;
	
	static bool timeComparator(Time t1, Time t2);
	static int getTimeGap(Time t1, Time t2);
	static Time timeAdding(Time t, double sec);
	static bool isSame(Time t1, Time t2);
};
#pragma once
class Time 
{
public:
	int year=0, month=0, date=0, hour=0, min=0;
	
	static bool timeComparator(Time t1, Time t2);
	static int getTimeGap(Time t1, Time t2);
	static Time timeAdding(Time t, double sec);
};
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    public class Time
    {
        public int year = 0, month = 0, date = 0, hour = 0, min = 0;

        public static bool timeComparator(Time t1, Time t2)
        {
            if(t1.year != t2.year) return (t1.year < t2.year);
            else if(t1.month != t2.month) return (t1.month < t2.month);
            else if(t1.date != t2.date) return (t1.date < t2.date);
            else if(t1.hour != t2.hour) return (t1.hour < t2.hour);
            else if(t1.min != t2.min) return (t1.min < t2.min);
            else return false;
        }

        public static int getTimeGap(Time t1, Time t2)
        {
            return (t2.min - t1.min) + 60 * (t2.hour - t1.hour + 24 * (t2.date - t1.date + 30 * (t2.month - t1.month + 12 * (t2.year = t1.year))));
        }

        public static Time timeAdding(Time t, double second)
        {
            Time addedTime = new Time();
            int minute = (int)second / 60 + 1;
            int _min = t.min + minute;
            addedTime.min = _min % 60;
            int _hour = t.hour + _min / 60;
            addedTime.hour = _hour / 24;
            int _date = t.date + _hour / 24;
            addedTime.date = _date % 30;
            int _month = t.month + _date / 30;
            addedTime.month = _month % 12;
            int _year = t.year + _month / 12;
            addedTime.year = _year;

            return addedTime;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    public class Time
    {
        public int yy, MM, dd, hh, mm, ss;

        public Time()
        {
            yy = 0;
            MM = 0;
            dd = 0;
            hh = 0;
            mm = 0;
            ss = 0;
        }

        public Time(int _yy, int _MM, int _dd, int _hh, int _mm, int _ss)
        {
            yy = _yy;
            MM = _MM;
            dd = _dd;
            hh = _hh;
            mm = _mm;
            ss = _ss;
        }


        public static bool operator <(Time t1, Time t2)
        {
            if(t1.yy != t2.yy) return (t1.yy < t2.yy);
            else if(t1.MM != t2.MM) return (t1.MM < t2.MM);
            else if(t1.dd != t2.dd) return (t1.dd < t2.dd);
            else if(t1.hh != t2.hh) return (t1.hh < t2.hh);
            else if(t1.mm != t2.mm) return (t1.mm < t2.mm);
            else return false;
        }

        public static bool operator >(Time t1, Time t2)
        {
            if(t1.yy != t2.yy) return (t1.yy > t2.yy);
            else if(t1.MM != t2.MM) return (t1.MM > t2.MM);
            else if(t1.dd != t2.dd) return (t1.dd > t2.dd);
            else if(t1.hh != t2.hh) return (t1.hh > t2.hh);
            else if(t1.mm != t2.mm) return (t1.mm > t2.mm);
            else return false;
        }

        public static bool timeComparator(Time t1, Time t2)
        {
            if(t1.yy != t2.yy) return (t1.yy < t2.yy);
            else if(t1.MM != t2.MM) return (t1.MM < t2.MM);
            else if(t1.dd != t2.dd) return (t1.dd < t2.dd);
            else if(t1.hh != t2.hh) return (t1.hh < t2.hh);
            else if(t1.mm != t2.mm) return (t1.mm < t2.mm);
            else return false;
        }

        public static int getTimeGap(Time t1, Time t2)
        {
            return (t2.mm - t1.mm) + 60 * (t2.hh - t1.hh + 24 * (t2.dd - t1.dd + 30 * (t2.MM - t1.MM + 12 * (t2.yy - t1.yy))));
        }

        override public string ToString()
        {
            DateTime dateTime = new DateTime(yy, MM, dd, hh, mm, ss);
            return dateTime.ToString("yyyy-MM-dd, HH:mm:ss");
        }

        public static Time timeAdding(Time t, double ss)
        {
            Time addedTime = new Time();
            int _ss = (int)ss;
            addedTime.ss = _ss % 60;
            int _mm = t.mm + _ss / 60;
            addedTime.mm = _mm % 60;
            int _hh = t.hh + _mm / 60;
            addedTime.hh = _hh % 24;

            addedTime.dd = t.dd;
            addedTime.MM = t.MM;
            addedTime.yy = t.yy;

            return addedTime;
        }
    }
}

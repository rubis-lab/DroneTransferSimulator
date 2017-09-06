using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    public class Drone
    {
        private double battery, chargingRate;   /* unit: percent */
        private double maxAvailDist; /* available distance of Drone */
        private int status;                     /* 0: in station, 1: flying, 2: charging*/
        private Time chargeStartTime;

        public Drone(double _maxAvailDist, double _chargingRate)
        {
            maxAvailDist = _maxAvailDist;
            chargingRate = _chargingRate;
            battery = 100;
            status = 0;
        }

        public void fly(double distance)
        {
            if(distance < 0) return;

            double consumedBattery = distance / maxAvailDist * 100;
            if(consumedBattery < 0 || consumedBattery > 100) return;
            else if(consumedBattery > battery) return;

            battery -= consumedBattery;
        }
        public void charge(Time startTime, Time endTime)
        {
            battery += chargingRate * (Time.getTimeGap(startTime, endTime));
        }
        public double returnBattery()
        {
            return battery;
        }
        public void setBattery(double _battery)
        {
            battery = _battery;
        }
        public double returnAvailDist()
        {
            return maxAvailDist / 100 * battery;
        }
        public int returnStatus()
        {
            return status;
        }
        public void setStatus(int _status)
        {
            status = _status;
        }
        public void setChargeStartTime(Time _chargeStartTime)
        {
            chargeStartTime = _chargeStartTime;
        }
        public Time getChargeStartTime()
        {
            return chargeStartTime;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    public class Event :IComparable<Event>
    {
        public enum eventType { E_EVENT_OCCURED, E_EVENT_ARRIVAL, E_STATION_ARRIVAL };
        public enum eventResult { SUCCESS, COVERAGE_PROBLEM, NO_DRONE };

        private double lat, lng;
        private Time occuredDate, ambulDate, droneDate;
        private int droneIndex;
        private eventType type;
        private eventResult result;
        private DroneStation station;

        

        public int CompareTo(Event obj)
        {
            if(this.getOccuredDate() > obj.getOccuredDate()) return 1;
            if(obj.getOccuredDate() > this.getOccuredDate()) return -1;
            return 1;
        }

        public Event(double _lat, double _lng, Time _oDate, Time _ambulDate, eventType _type)
        {
            lat = _lat;
            lng = _lng;
            occuredDate = _oDate;
            ambulDate = _ambulDate;
            droneDate = new Time();
            type = _type;
            result = 0;
            station = null;
        }

        public Time getOccuredDate()
        {
            return occuredDate;
        }

        public Time getAmbulDate()
        {
            return ambulDate;
        }

        public Time getDroneDate()
        {
            return droneDate;
        }

        public eventResult getResult()
        {
            return result;
        }

        public eventType getEventType()
        {
            return type;
        }

        public Tuple<double, double> getCoordinates()
        {
            return new Tuple<double, double>(lat, lng);
        }

        public void setDroneDate(Time _droneDate)
        {
            droneDate = _droneDate;
        }

        public void setResult(eventResult _result)
        {
            result = _result;
        }

        public void setStation(DroneStation _station)
        {
            station = _station;
        }

        public DroneStation getStation()
        {
            return station;
        }

        public int getDroneIndex()
        {
            return droneIndex;
        }
        
        public void setStationDroneIdx(DroneStation _station, int _droneIndex)
        {
            station = _station;
            droneIndex = _droneIndex;
        }

    }
}

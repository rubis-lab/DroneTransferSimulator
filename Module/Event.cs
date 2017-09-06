using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    public class Event :IComparable<Event>
    {
        private double lat, lng;
        private Time occuredDate, ambulDate, droneDate;
        private int stationIndex, droneIndex;
        private eventType type;
        private string result;
        private DroneStation station;

        public enum eventType { E_EVENT_OCCURED, E_EVENT_ARRIVAL, E_STATION_ARRIVAL };

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
            result = "failure";
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

        public string getResult()
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

        public DroneStation getStation()
        {
            return station;
        }

        public void setStationDroneIdx(int _stationIndex, int _droneIndex)
        {
            stationIndex = _stationIndex;
            droneIndex = _droneIndex;
        }

        public Tuple<int, int> getStationDroneIdx()
        {
            return new Tuple<int, int>(stationIndex, droneIndex);
        }

        public void setDroneDate(Time _droneDate)
        {
            droneDate = _droneDate;
        }

        public void setResult(string _result)
        {
            result = _result;
        }

        public void setStation(DroneStation _station)
        {
            station = _station;
        }
    }
}

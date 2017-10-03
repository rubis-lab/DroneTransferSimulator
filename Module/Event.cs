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
        private Address addr;
        private DateTime occuredDate, ambulDate, droneDate;
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

        public Event(double _lat, double _lng, DateTime _oDate, DateTime _ambulDate, eventType _type)
        {
            lat = _lat;
            lng = _lng;

            occuredDate = _oDate;
            ambulDate = _ambulDate;
            droneDate = new DateTime();
            type = _type;
            result = 0;
            station = null;
        }

        public DateTime getOccuredDate()
        {
            return occuredDate;
        }

        public DateTime getAmbulDate()
        {
            return ambulDate;
        }

        public DateTime getDroneDate()
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

        public Address getAddress()
        {
            return addr;
        }

        public void setAddress(Address _addr)
        {
            addr = _addr;
        }

        public Tuple<double, double> getCoordinates()
        {
            return new Tuple<double, double>(lat, lng);
        }

        public void setDroneDate(DateTime _droneDate)
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

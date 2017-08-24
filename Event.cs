﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    class Event :IComparable<Event>
    {
        private double lat, lng;
        private Time occuredDate, ambulDate;
        private int stationIndex, droneIndex;
        private eventType type;

        public enum eventType { E_EVENT_OCCURED, E_EVENT_ARRIVAL, E_STATION_ARRIVAL };

        public int CompareTo(Event obj)
        {
            if (Time.timeComparator(this.getOccuredDate(), obj.getOccuredDate())) return 1;
            if (Time.timeComparator(obj.getOccuredDate(), this.getOccuredDate())) return -1;
            return 0;
        }

        public Event(double _lat, double _lng, Time _oDate, Time _ambulDate, eventType _type)
        {
            lat = _lat;
            lng = _lng;
            occuredDate = _oDate;
            ambulDate = _ambulDate;
            type = _type;
        }

        public Time getOccuredDate()
        {
            return occuredDate;
        }

        public eventType getEventType()
        {
            return type;
        }

        public Tuple<double, double> getCoordinates()
        {
            return new Tuple<double, double>(lat, lng);
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
    }
}

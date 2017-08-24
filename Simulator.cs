using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    class Simulator
    {
        private List<Event> events= new List<Event>();
        private SortedList<int, Event> eventsQueue;
        private List<DroneStation> stations;

        public void getEventsFromCSV(ref char fname)
        {
            System.IO.StreamReader readFile = new System.IO.StreamReader("..//..//data.csv");
            string line;
            string[] record;
            readFile.ReadLine();
            while ((line = readFile.ReadLine()) != null)
            {
                record = line.Split(',');
                if (record.Length != 6) break;

                Time occuredDate = new Time();
                Time ambulDate = new Time();
                double lng = System.Convert.ToDouble(record[0]);
                double lat = System.Convert.ToDouble(record[1]);
                occuredDate.year = System.Convert.ToInt32(record[2]) / 10000;
                occuredDate.month = (System.Convert.ToInt32(record[2]) % 10000) / 100;
                occuredDate.date = System.Convert.ToInt32(record[2]) % 100;
                occuredDate.hour = System.Convert.ToInt32(record[3]) / 100;
                occuredDate.min = System.Convert.ToInt32(record[3]) % 100;

                ambulDate.year = System.Convert.ToInt32(record[4]) / 10000;
                ambulDate.month = (System.Convert.ToInt32(record[4]) % 10000) / 100;
                ambulDate.date = System.Convert.ToInt32(record[4]) % 100;
                ambulDate.hour = System.Convert.ToInt32(record[5]) / 100;
                ambulDate.min = System.Convert.ToInt32(record[5]) % 100;

                Event.eventType e = new Event.eventType();
                e = Event.eventType.E_EVENT_OCCURED;
                events.Add(new Event(lat, lng, occuredDate, ambulDate, e));
            }
            readFile.Close();
        }
        public void updateEventsBtwRange(Time start, Time end, ref char fname)
        {
            if (Time.timeComparator(end, start)) return;
            events.Sort();

            int startIndex = 0, endIndex = 0;
            foreach (Event eventElement in events)
            {
                if (Time.timeComparator(eventElement.getOccuredDate(), start))
                {
                    startIndex++;
                    endIndex++;
                }
                else if (Time.timeComparator(eventElement.getOccuredDate(), end)) endIndex++;
                else break;
            }

            if (endIndex == startIndex + 1) return; // no events

            events.RemoveRange(endIndex, events.Count);
            events.RemoveRange(0, startIndex);

        }
        public void start(Time start, Time end)
        {
            foreach (Event eventElement in events)
            {
                int date = eventElement.getOccuredDate().min + 100 * (eventElement.getOccuredDate().hour + 100 * (eventElement.getOccuredDate().date + 100 * (eventElement.getOccuredDate().month + 100 * eventElement.getOccuredDate().year)));
                eventsQueue.Add(date, eventElement);
            }

            while (eventsQueue.Count != 0)
            {
                Event e = eventsQueue.Values[0];
                eventsQueue.RemoveAt(0);

                switch (e.getEventType())
                {
                    case Event.eventType.E_EVENT_OCCURED:
                        eventOccured(e.getCoordinates(), e.getOccuredDate());
                        break;

                    case Event.eventType.E_EVENT_ARRIVAL:
                        eventArrived(e.getCoordinates(), e.getOccuredDate(), e.getStationDroneIdx());
                        break;
                    case Event.eventType.E_STATION_ARRIVAL:
                        stationArrival(e.getOccuredDate(), e.getStationDroneIdx());
                        break;
                }
            }
        }
        public void eventOccured(Tuple<double, double> coordinates, Time occuredTime)
        {
            //find stations and drone
            DroneStationFinder finder = new DroneStationFinder(coordinates);
            finder.findAvailableStations();
            Tuple<int, int> stationDroneIdx = finder.findAvailableDrone(occuredTime);
            if (stationDroneIdx.Item1 == -1) return;

            DroneStation s = stations[stationDroneIdx.Item1];
            Drone d = s.drones[stationDroneIdx.Item2];

            double distance = finder.getDistanceFromRecentEvent(s.stationLng, s.stationLat);

            //calculate time
            PathPlanner pathPlanner = PathPlanner.getInstance();
            double calculatedTime;
            calculatedTime = pathPlanner.calcTravelTime(s.stationLat, s.stationLng, coordinates.Item2, coordinates.Item1);

            Time droneArrivalTime = Time.timeAdding(occuredTime, calculatedTime);

            //battery consumption
            d.fly(distance);
            d.setStatus(1);

            //declare coming event
            Event.eventType type = Event.eventType.E_EVENT_ARRIVAL;
            Event e = new Event(coordinates.Item1, coordinates.Item2, droneArrivalTime, droneArrivalTime, type);
            e.setStationDroneIdx(stationDroneIdx.Item1, stationDroneIdx.Item2);
            
            int date = e.getOccuredDate().min + 100 * (e.getOccuredDate().hour + 100 * (e.getOccuredDate().date + 100 * (e.getOccuredDate().month + 100 * e.getOccuredDate().year)));
            eventsQueue.Add(date, e);
        }
        public void eventArrived(Tuple<double, double> occuredCoord, Time occuredTime, Tuple<int, int> stationDroneIdx)
        {
            //time to return to the Drone Station
            PathPlanner pathPlanner = PathPlanner.getInstance();
            double calculatedTime;
            calculatedTime = pathPlanner.calcTravelTime(occuredCoord.Item2, occuredCoord.Item1, stations[stationDroneIdx.Item1].stationLat, stations[stationDroneIdx.Item1].stationLng);

            //time when drone reach the station
            Time droneArrivalTime = Time.timeAdding(occuredTime, calculatedTime);


            //battery consumption
            DroneStationFinder f = new DroneStationFinder(new Tuple<double, double>(occuredCoord.Item1, occuredCoord.Item2));
            double distance = f.getDistanceFromRecentEvent(stations[stationDroneIdx.Item1].stationLng, stations[stationDroneIdx.Item1].stationLat);
            stations[stationDroneIdx.Item1].drones[stationDroneIdx.Item2].fly(distance);

            //event of arriving
            Event.eventType type = Event.eventType.E_STATION_ARRIVAL;
            Event e = new Event(occuredCoord.Item1, occuredCoord.Item2, droneArrivalTime, droneArrivalTime, type);
            e.setStationDroneIdx(stationDroneIdx.Item1, stationDroneIdx.Item2);

            int date = e.getOccuredDate().min + 100 * (e.getOccuredDate().hour + 100 * (e.getOccuredDate().date + 100 * (e.getOccuredDate().month + 100 * e.getOccuredDate().year)));
            eventsQueue.Add(date, e);
        }
        public void stationArrival(Time arrivalTime, Tuple<int, int> stationDroneIdx)
        {
            Drone d = stations[stationDroneIdx.Item1].drones[stationDroneIdx.Item2];
            d.setStatus(2);
            d.setChargeStartTime(arrivalTime);
        }

    }
}

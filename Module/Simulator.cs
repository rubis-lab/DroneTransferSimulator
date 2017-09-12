using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    public class Simulator
    {
        /* singleton instance for Simulator */
        private static Simulator instance;
        public bool isDone = false;

        private List<Event> events = new List<Event>();
        private SortedList<Event, Event> eventSet = new SortedList<Event, Event>();
        private Dictionary<string, DroneStation> stationDict = new Dictionary<string, DroneStation>();
        private int successEventNum=0;

        public double getSuccessRate()
        {
            return successEventNum / events.Count;
        }
        
        public List<Event> getEventList()
        {
            return events;
        }

        public SortedList<Event, Event> getEventSet()
        {
            return eventSet;
        }

        public void getStationDict(ref Dictionary<string, DroneStation> _stationDict)
        {
            _stationDict = stationDict;
        }

        public Dictionary<string, DroneStation> getStationDict()
        {
            return stationDict;
        }

        public string getEventsFromCSV(string fpath)
        {
            try
            {
                if(events.Count != 0) events.Clear();

                System.IO.StreamReader readFile = new System.IO.StreamReader(fpath);
                while(!readFile.EndOfStream)
                {
                    var line = readFile.ReadLine();
                    var record = line.Split(',');
                    if(record.Length != 6) throw new Exception("Inappropriate CSV format\nCannot be read");

                    Time occuredDate = new Time();
                    Time ambulDate = new Time();
                    double longitude = System.Convert.ToDouble(record[0]);
                    double latitude = System.Convert.ToDouble(record[1]);
                    occuredDate.yy = System.Convert.ToInt32(record[2]) / 10000;
                    occuredDate.MM = (System.Convert.ToInt32(record[2]) % 10000) / 100;
                    occuredDate.dd = System.Convert.ToInt32(record[2]) % 100;
                    occuredDate.hh = System.Convert.ToInt32(record[3]) / 100;
                    occuredDate.mm = System.Convert.ToInt32(record[3]) % 100;

                    ambulDate.yy = System.Convert.ToInt32(record[4]) / 10000;
                    ambulDate.MM = (System.Convert.ToInt32(record[4]) % 10000) / 100;
                    ambulDate.dd = System.Convert.ToInt32(record[4]) % 100;
                    ambulDate.hh = System.Convert.ToInt32(record[5]) / 100;
                    ambulDate.mm = System.Convert.ToInt32(record[5]) % 100;

                    Event.eventType e = new Event.eventType();
                    e = Event.eventType.E_EVENT_OCCURED;
                    events.Add(new Event(latitude, longitude, occuredDate, ambulDate, e));
                }
                readFile.Close();
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return null;
        }
        
        public string getStationsFromCSV(string fpath)
        {
            try
            {
                if(stationDict.Count != 0) stationDict.Clear();

                System.IO.StreamReader readFile = new System.IO.StreamReader(fpath);
                while(!readFile.EndOfStream)
                {
                    var line = readFile.ReadLine();
                    var record = line.Split(',');
                    if(record.Length != 4) throw new Exception("Inappropriate CSV format\nCannot be read");

                    string name = record[0];
                    double latitude = System.Convert.ToDouble(record[1]);
                    double longitude = System.Convert.ToDouble(record[2]);
                    double coverRange = System.Convert.ToDouble(record[3]);
                    
                    stationDict.Add(name, new DroneStation(name, latitude, longitude, coverRange));
                }
                readFile.Close();
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return null;
        }

        public string getDronesFromCSV(string fpath)
        {
            try
            {
                System.IO.StreamReader readFile = new System.IO.StreamReader(fpath);
                while(!readFile.EndOfStream)
                {
                    var line = readFile.ReadLine();
                    var record = line.Split(',');
                    if(record.Length != 3) throw new Exception("Inappropriate CSV format\nCannot be read");
                    Drone d = new Drone(System.Convert.ToDouble(record[1]), System.Convert.ToDouble(record[2]));
                    stationDict[record[0]].drones.Add(d);
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return null;
        }

        public void updateEventsBtwRange(Time start, Time end)
        {
            foreach(Event eventElement in events)
            {
                if(start < eventElement.getOccuredDate() && eventElement.getOccuredDate() < end)
                {
                    eventSet.Add(eventElement, eventElement);
                }
            }
        }

        public void start()
        {
            Console.WriteLine("Start");

            //       StationManager.getStations(ref stations);

            if(events.Count != 0) events.Clear();

            while(eventSet.Count != 0)
            {
                Event e = eventSet.ElementAt(0).Value;
                eventSet.RemoveAt(0);
                switch(e.getEventType())
                {
                    case Event.eventType.E_EVENT_OCCURED:
                        Console.WriteLine("E_EVENT_OCCURED >> " + e.getCoordinates().Item1 + ", " + e.getCoordinates().Item2);
                        eventOccured(e);
                        //events.Add(e);
                        break;

                    case Event.eventType.E_EVENT_ARRIVAL:
                        Console.WriteLine("E_EVENT_ARRIVAL >> " + e.getCoordinates().Item1 + ", " + e.getCoordinates().Item2);
                        //eventArrived(e);
                        break;

                    case Event.eventType.E_STATION_ARRIVAL:
                        Console.WriteLine("E_STATION_ARRIVAL >> " + e.getCoordinates().Item1 + ", " + e.getCoordinates().Item2);

                        //stationArrival(e.getOccuredDate(), e.getStationDroneIdx());
                        break;
                }
                isDone = true;
            }
        }

        public void eventOccured(Event ee)
        {
            Event e = ee;
            Tuple<double, double> coordinates = e.getCoordinates();

            //find stations and drone
            DroneStationFinder finder = new DroneStationFinder(e);
            Tuple<string, int> stationDroneIdx = finder.findAvailableDrone();
            e.setStationDroneIdx(stationDroneIdx.Item1, stationDroneIdx.Item2);
            if(stationDroneIdx.Item1.Length == 0) return;

            successEventNum += 1;
            Console.WriteLine(stationDroneIdx.Item1 + ", " + stationDroneIdx.Item2);
            
            DroneStation s = stationDict[stationDroneIdx.Item1];
            Drone d = s.drones[stationDroneIdx.Item2];

            double distance = finder.getDistanceFromRecentEvent(s.stationLng, s.stationLat);

            //calculate time
            PathPlanner pathPlanner = PathPlanner.getInstance();
            double calculatedTime;
            calculatedTime = pathPlanner.calcTravelTime(s.stationLat, s.stationLng, coordinates.Item1, coordinates.Item2);
            
            Time droneArrivalTime = Time.timeAdding(e.getOccuredDate(), calculatedTime);

            e.setDroneDate(droneArrivalTime);
            e.setStation(s);

            Console.WriteLine(e.getOccuredDate().ToString() + ", " + droneArrivalTime.ToString());
            
            //battery consumption
            d.fly(distance);
            d.setStatus(Drone.droneStatus.FLYING);

            //declare coming event
            Event.eventType type = Event.eventType.E_EVENT_ARRIVAL;
            Event comingE = new Event(coordinates.Item1, coordinates.Item2, droneArrivalTime, droneArrivalTime, type);
            comingE.setStationDroneIdx(stationDroneIdx.Item1, stationDroneIdx.Item2);
            eventSet.Add(comingE, comingE);
        }

        public void eventArrived(Event ee)
        {
            Event e = ee;
            Tuple<double, double> occuredCoord = e.getCoordinates();
            Time occuredTime = e.getOccuredDate();
            Tuple<string, int> stationDroneIdx = e.getStationDroneIdx();

            //time to return to the Drone Station
            PathPlanner pathPlanner = PathPlanner.getInstance();
            double calculatedTime;
            calculatedTime = pathPlanner.calcTravelTime(occuredCoord.Item2, occuredCoord.Item1, stationDict[stationDroneIdx.Item1].stationLat, stationDict[stationDroneIdx.Item1].stationLng);

            //time when drone reach the station
            Time droneArrivalTime = Time.timeAdding(occuredTime, calculatedTime);
            Console.WriteLine(occuredTime.ToString() + ", " + droneArrivalTime.ToString());

            //battery consumption
            DroneStationFinder f = new DroneStationFinder(e);
            double distance = f.getDistanceFromRecentEvent(stationDict[stationDroneIdx.Item1].stationLng, stationDict[stationDroneIdx.Item1].stationLat);
            stationDict[stationDroneIdx.Item1].drones[stationDroneIdx.Item2].fly(distance);

            //event of arriving
            Event.eventType type = Event.eventType.E_STATION_ARRIVAL;
            Event comingE = new Event(occuredCoord.Item1, occuredCoord.Item2, droneArrivalTime, droneArrivalTime, type);
            comingE.setStationDroneIdx(stationDroneIdx.Item1, stationDroneIdx.Item2);

            int date = comingE.getOccuredDate().mm + 100 * (comingE.getOccuredDate().hh + 100 * (comingE.getOccuredDate().dd + 100 * (comingE.getOccuredDate().MM + 100 * comingE.getOccuredDate().yy)));
            eventSet.Add(comingE, comingE);
        }

        public void stationArrival(Time arrivalTime, Tuple<string, int> stationDroneIdx)
        {
            Drone d = stationDict[stationDroneIdx.Item1].drones[stationDroneIdx.Item2];
            d.setStatus(Drone.droneStatus.CHARGING);
            d.setChargeStartTime(arrivalTime);
        }
        
        public static Simulator getInstance()
        {
            if(instance == null) instance = new Simulator();
            return instance;
        }
    }
}

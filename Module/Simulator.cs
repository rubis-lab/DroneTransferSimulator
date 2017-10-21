using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
        private double goldenTime = 480;
        
        public List<Event> getEventList()
        {
            return events;
        }

        public SortedList<Event, Event> getEventSet()
        {
            return eventSet;
        }

        public Dictionary<string, DroneStation> getStationDict()
        {
            return stationDict;
        }

        public string getEventsFromCSV(string fpath)
        {
            try
            {
                if (events.Count != 0) events.Clear();

                System.IO.StreamReader readEventFile = new System.IO.StreamReader(fpath);
                while(!readEventFile.EndOfStream)
                {
                    var line = readEventFile.ReadLine();
                    var record = line.Split(',');
                    if(record.Length != 6) throw new Exception("Inappropriate CSV format\nCannot be read");
              
                    double longitude = System.Convert.ToDouble(record[0]);
                    double latitude = System.Convert.ToDouble(record[1]);

                    int yy = System.Convert.ToInt32(record[2]) / 10000;
                    int MM = (System.Convert.ToInt32(record[2]) % 10000) / 100;
                    int dd = System.Convert.ToInt32(record[2]) % 100;
                    int hh = System.Convert.ToInt32(record[3]) / 100;
                    int mm = System.Convert.ToInt32(record[3]) % 100;
                    DateTime occuredDate = new DateTime(yy, MM, dd, hh, mm, 0);

                    yy = System.Convert.ToInt32(record[4]) / 10000;
                    MM = (System.Convert.ToInt32(record[4]) % 10000) / 100;
                    dd = System.Convert.ToInt32(record[4]) % 100;
                    hh = System.Convert.ToInt32(record[5]) / 100;
                    mm = System.Convert.ToInt32(record[5]) % 100;
                    DateTime ambulDate = new DateTime(yy, MM, dd, hh, mm, 0);

                    Event.eventType e = new Event.eventType();
                    e = Event.eventType.E_EVENT_OCCURED;
                    events.Add(new Event(latitude, longitude, occuredDate, ambulDate, e));
                }
                readEventFile.Close();
                
                String path = "../../EventAddress.csv";
                System.IO.StreamReader readAddressFile = new System.IO.StreamReader(path);

                foreach(Event e in events)
                {
                    var line = readAddressFile.ReadLine();
                    var record = line.Split(',');
                    if(record.Length < 4) throw new Exception("Too Short Address");

                    string premise = "";
                    for(int i = 4; i < record.Length; i++) premise += record[i] + " ";
                    
                    Address addr = new Address(record[0], record[1], record[2], record[3], premise);
                    e.setAddress(addr);
                }
                readAddressFile.Close();
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
                /*
                string filePath = @"../../StationAddress.csv";
                StringBuilder sb = new StringBuilder();
                */
                while (!readFile.EndOfStream)
                {
                    var line = readFile.ReadLine();
                    var record = line.Split(',');
                    if(record.Length != 4) throw new Exception("Inappropriate CSV format\nCannot be read");

                    string name = record[0];
                    double latitude = System.Convert.ToDouble(record[1]);
                    double longitude = System.Convert.ToDouble(record[2]);
                    double coverRange = System.Convert.ToDouble(record[3]);
                    stationDict.Add(name, new DroneStation(name, latitude, longitude, coverRange));
                    /*
                    Address addr = new Address(latitude, longitude);
                    string[] rec = addr.ToString().Split(new string[] { " " }, StringSplitOptions.None);
                    Console.WriteLine(addr.ToString());
                    stationDict.Add(name, new DroneStation(name, latitude, longitude, coverRange, addr));
                    
                    sb.AppendLine(string.Join(",", rec));
                    */
                }

                //File.WriteAllText(filePath, sb.ToString(), Encoding.Default);
                readFile.Close();

                String path = "../../StationAddress.csv";
                System.IO.StreamReader readStationAddressFile = new System.IO.StreamReader(path);

                foreach (DroneStation s in stationDict.Values)
                {
                    var line = readStationAddressFile.ReadLine();
                    var record = line.Split(',');
                    if (record.Length < 4) throw new Exception("Too Short Address");

                    string premise = "";
                    for (int i = 4; i < record.Length; i++) premise += record[i] + " ";

                    Address addr = new Address(record[0], record[1], record[2], record[3], premise);
                    s.setStationAddress(addr);
                }
                readStationAddressFile.Close();
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

        public void updateEventsBtwRange(DateTime start, DateTime end)
        {
            foreach(Event eventElement in events)
            {
                if( DateTime.Compare(start , eventElement.getOccuredDate())<=0 && DateTime.Compare(eventElement.getOccuredDate() , end)<=0)
                {
                    eventSet.Add(eventElement, eventElement);
                }
            }
        }

        public void start()
        {
            if(events.Count != 0) events.Clear();

            while(eventSet.Count != 0)
            {
                Event e = eventSet.ElementAt(0).Value;
                eventSet.RemoveAt(0);
                switch(e.getEventType())
                {
                    case Event.eventType.E_EVENT_OCCURED:
                        Console.WriteLine("\n" + e.getOccuredDate().ToString() + " OCCURED >> " + e.getCoordinates().Item1 + ", " + e.getCoordinates().Item2);
                        eventOccured(e);
                        events.Add(e);
                        isDone = true;
                        break;

                    case Event.eventType.E_EVENT_ARRIVAL:
                        Console.WriteLine("\n" + e.getOccuredDate().ToString() + " EVENT_ARRIVAL >> " + e.getCoordinates().Item1 + ", " + e.getCoordinates().Item2);
                        eventArrived(e);
                        break;

                    case Event.eventType.E_STATION_ARRIVAL:
                        Console.WriteLine("\n" + e.getOccuredDate().ToString() + " STATION_ARRIVAL >> " + e.getCoordinates().Item1 + ", " + e.getCoordinates().Item2);
                        stationArrival(e);
                        break;
                }
                isDone = true;
            }
        }

        public void eventOccured(Event ev)
        {
            Tuple<double, double> coordinates = ev.getCoordinates();
            DateTime occuredTime = ev.getOccuredDate();

            //find stations and drone
            DroneStationFinder finder = new DroneStationFinder(ev);
            Tuple<string, int> stationDroneIdx = finder.findAvailableDrone();

            if(stationDroneIdx.Item1.Length == 0) return;

            DroneStation s = stationDict[stationDroneIdx.Item1];
            Drone drone = s.drones[stationDroneIdx.Item2];

            ev.setStationDroneIdx(s, stationDroneIdx.Item2);

            double distance = finder.getDistanceFromRecentEvent(s.stationLat, s.stationLng);

            //calculate time
            PathPlanner pathPlanner = PathPlanner.getInstance();
            double calculatedTime;
            calculatedTime = pathPlanner.calcTravelTime(s.stationLat, s.stationLng, coordinates.Item1, coordinates.Item2);

            DateTime droneArrivalTime = ev.getOccuredDate().AddSeconds(calculatedTime);

            ev.setDroneDate(droneArrivalTime);
            ev.setResult(Event.eventResult.SUCCESS);
            ev.setStationDroneIdx(s, stationDroneIdx.Item2);

            //battery consumption
            drone.fly(distance);
            drone.setStatus(Drone.droneType.D_FLYING);

            //declare coming event
            Event.eventType type = Event.eventType.E_EVENT_ARRIVAL;
            Event e = new Event(coordinates.Item1, coordinates.Item2, droneArrivalTime, droneArrivalTime, type);
            e.setStationDroneIdx(s, stationDroneIdx.Item2);

            eventSet.Add(e, e);
        }

        public void eventArrived(Event ev)
        {
            //time to return to the Drone Station
            PathPlanner pathPlanner = PathPlanner.getInstance();
            double calculatedTime;
            double eventLat = ev.getCoordinates().Item1;
            double eventLng = ev.getCoordinates().Item2;

            DroneStation station = ev.getStation();
            int droneIndex = ev.getDroneIndex();
            Drone drone = station.drones[droneIndex];
            double stationLat = station.stationLat;
            double stationLng = station.stationLng;
            calculatedTime = pathPlanner.calcTravelTime(eventLat, eventLng, stationLat, stationLng);

            //time when drone reach the station
            DateTime droneArrivalTime = ev.getOccuredDate().AddSeconds(calculatedTime);
            
            //battery consumption
            DroneStationFinder f = new DroneStationFinder(ev);
            double distance = f.getDistanceFromRecentEvent(stationLat, stationLng);
            drone.fly(distance);
            
            //event of arriving
            Event.eventType type = Event.eventType.E_STATION_ARRIVAL;
            Event e = new Event(eventLat, eventLng, droneArrivalTime, droneArrivalTime, type);
            e.setStationDroneIdx(station, droneIndex);

            eventSet.Add(e, e);
        }

        public void stationArrival(Event ev)
        {
            DroneStation station = ev.getStation();
            int droneIndex = ev.getDroneIndex();
            Drone drone = station.drones[droneIndex];
            
            drone.setStatus(Drone.droneType.D_CHARGING);
            drone.setChargeStartTime(ev.getOccuredDate());
        }
        
        public static Simulator getInstance()
        {
            if(instance == null) instance = new Simulator();
            return instance;
        }

        public void setGoldenTime(double _goldenTime)
        {
            goldenTime = _goldenTime;
        }
    }
}

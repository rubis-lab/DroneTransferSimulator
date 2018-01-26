using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
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

        public double w_temp_low = 0.0;
        public double w_temp_high = 0.0;
        public double w_rain = 0.0;
        public double w_winds = 0.0;
        public double w_snow = 0.0;
        public double w_sight = 0.0;

        public bool p_subzero = true;
        public bool p_rain = true;
        public bool p_light = true;
        public bool p_snow = true;
        public bool p_sight = true;

        public double maxDistance = 10;
        public double maxSpeed = 60.0;

        private List<Event> events = new List<Event>();
        private SortedList<Event, Event> eventSet = new SortedList<Event, Event>();
        private Dictionary<string, DroneStation> stationDict = new Dictionary<string, DroneStation>();
        private Tuple<double,double> goldenTime = new Tuple<double, double>(300,480);
        
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
                if(events.Count != 0) events.Clear();

                //System.IO.StreamReader readEventFile = new System.IO.StreamReader(fpath);
                /*
                while (!readEventFile.EndOfStream)
                {

                    var line = readEventFile.ReadLine();
                    var record = line.Split(',');
                    Console.WriteLine(record.Length);
                    //if (record.Length != 66) throw new Exception("Inappropriate CSV format\nCannot be read");
                    if (record.Length != 66) continue;
                    double rec;
                    if (!Double.TryParse(record[43], out rec) || !Double.TryParse(record[43],out rec)) continue;

                    double longitude = System.Convert.ToDouble(record[43]);
                    double latitude = System.Convert.ToDouble(record[44]);

                    DateTime date = DateTime.Parse(record[17].ToString()); //date
                    DateTime time = DateTime.Parse(record[8].ToString());
                    DateTime occuredDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Month, 0);

                    DateTime a_date = DateTime.Parse(record[18].ToString());
                    DateTime a_time = DateTime.Parse(record[11].ToString());
                    DateTime ambulDate = new DateTime(a_date.Year, a_date.Month, a_date.Day, a_time.Hour, a_time.Month, 0);

                    double w_temp = System.Convert.ToDouble(record[46]);
                    double w_rain = System.Convert.ToDouble(record[47]);
                    double w_winds = System.Convert.ToDouble(record[48]);
                    double w_windd = System.Convert.ToDouble(record[49]);
                    double w_snow = System.Convert.ToDouble(record[50]);
                    double w_sight = System.Convert.ToDouble(record[51]);
                    double w_floor = System.Convert.ToDouble(record[52]);
                    double[] weather = { w_temp, w_rain, w_winds, w_windd, w_snow, w_sight, w_floor };
                    
                    bool p_subzero = System.Convert.ToBoolean(record[62]);
                    bool p_rain = System.Convert.ToBoolean(record[63]);
                    bool p_light = System.Convert.ToBoolean(record[64]);
                    bool p_snow = System.Convert.ToBoolean(record[65]);
                    bool p_sight = System.Convert.ToBoolean(record[66]);
                    bool[] b_weather = { p_subzero, p_rain, p_light, p_snow, p_sight };

                    Event.eventType e = new Event.eventType();
                    e = Event.eventType.E_EVENT_OCCURED;
                    events.Add(new Event(latitude, longitude, occuredDate, ambulDate, e, weather, b_weather));
                }
                */

                Excel.Application excelApp = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                try
                {
                    excelApp = new Excel.Application();
                    wb = excelApp.Workbooks.Open(fpath);
                    ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;
                    Excel.Range rng1 = ws.get_Range("I2","I16799"); //time
                    Excel.Range rng2 = ws.get_Range("L2", "L16799"); //time
                    Excel.Range rng3 = ws.get_Range("R2", "S16799"); //date
                    Excel.Range rng4 = ws.get_Range("AU2", "AZ16799"); //weather
                    Excel.Range rng6 = ws.get_Range("AR2", "AS16799"); //coordinates
                    Excel.Range rng5 = ws.get_Range("BJ2", "BN16799"); //boolean weather
                    Excel.Range rng7 = ws.get_Range("AP2", "AP16799"); //korean address
                    

                    object[,] data1 = rng1.Value;
                    object[,] data2 = rng2.Value;
                    object[,] data3 = rng3.Value;
                    object[,] data4 = rng4.Value;
                    object[,] data5 = rng5.Value;
                    object[,] data6 = rng6.Value;
                    object[,] data7 = rng7.Value;

                    for (int r = 1; r <= data1.GetLength(0); r++)
                    {
                        if (data6[r, 1] == null || data6[r, 2] == null || data3[r, 1] == null
                            || data1[r, 1] == null || data3[r, 2] == null || data2[r, 1] == null || data5[r, 1] == null
                            || data5[r, 2] == null || data5[r, 3] == null || data5[r, 5] == null || data7[r, 1] == null
                            || data4[r, 1] == null || data4[r,3] == null || data4[r,4] == null) continue;
                        double longitude = System.Convert.ToDouble(data6[r, 1]);
                        double latitude = System.Convert.ToDouble(data6[r, 2]);
                        
                        DateTime date = DateTime.Parse(data3[r,1].ToString());
                        DateTime time = DateTime.Parse(data1[r,1].ToString());
                        DateTime occuredDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
                        
                        DateTime a_date = DateTime.Parse(data3[r, 2].ToString());
                        DateTime a_time = DateTime.Parse(data2[r,1].ToString());
                        DateTime ambulDate = new DateTime(a_date.Year, a_date.Month, a_date.Day, a_time.Hour, a_time.Minute, 0);

                        string _addr = data7[r,1].ToString();
                        Address addr = new Address(_addr);
                        
                        double e_temp = System.Convert.ToDouble(data4[r,1]);
                        double e_rain = 0;
                        if(data4[r,2]!=null) e_rain = System.Convert.ToDouble(data4[r,2]);
                        double e_winds = System.Convert.ToDouble(data4[r,3]);
                        double e_windd = System.Convert.ToDouble(data4[r,4]);
                        double e_snow = 0;
                        if(data4[r,5]!=null) e_snow = System.Convert.ToDouble(data4[r,5]);
                        double e_sight = -10;
                        if(data4[r,6]!=null) e_sight = System.Convert.ToDouble(data4[r,6]);
                        double[] e_weather = { e_temp, e_rain, e_winds, e_windd, e_snow, e_sight};
                        
                        bool ep_subzero = System.Convert.ToBoolean(data5[r,1]);
                        bool ep_rain = System.Convert.ToBoolean(data5[r,2]);
                        bool ep_light = System.Convert.ToBoolean(data5[r,3]);
                        bool ep_snow = System.Convert.ToBoolean(data5[r,4]);
                        bool ep_sight = System.Convert.ToBoolean(data5[r,5]);
                        bool[] eb_weather = { ep_subzero, ep_rain, ep_light, ep_snow, ep_sight };
                        
                        Event.eventType e = new Event.eventType();
                        e = Event.eventType.E_EVENT_OCCURED;
                        events.Add(new Event(latitude, longitude, occuredDate, ambulDate, e, addr, eb_weather));
                                            }
                    Console.WriteLine("Done!");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                /*
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
                */
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
                Encoding encode = System.Text.Encoding.GetEncoding("ks_c_5601-1987");
                System.IO.StreamReader readFile = new System.IO.StreamReader(fpath);
                /*
                string filePath = @"../../StationAddress.csv";
                StringBuilder sb = new StringBuilder();
                */
                while(!readFile.EndOfStream)
                {
                    var line = readFile.ReadLine();
                    var record = line.Split(',');
                    if(record.Length != 4) throw new Exception("Inappropriate CSV format\nCannot be read");

                    string name = record[0];
                    double latitude = System.Convert.ToDouble(record[1]);
                    double longitude = System.Convert.ToDouble(record[2]);
                    int droneCnt = System.Convert.ToInt32(record[3]);
                    double coverRange = maxDistance / 2;
                    
                    DroneStation s = new DroneStation(name, latitude, longitude, coverRange, droneCnt);
                    for(int i = 0; i < droneCnt; i++)
                    {
                        s.drones.Add(new Drone(maxDistance, 20));
                    }
                    stationDict.Add(name, s);

                    /*
                    Address addr = new Address(latitude, longitude);
                    string[] rec = addr.ToString().Split(new string[] { " " }, StringSplitOptions.None);
                    Console.WriteLine(addr.ToString());
                    stationDict.Add(name, new DroneStation(name, latitude, longitude, coverRange, addr));
                    
                    sb.AppendLine(string.Join(",", rec));
                    */
                }
                /*
                File.WriteAllText(filePath, sb.ToString(), Encoding.Default);
                */
                readFile.Close();

                String path = "../../StationAddress.csv";
                System.IO.StreamReader readStationAddressFile = new System.IO.StreamReader(path, encode);

                foreach(DroneStation s in stationDict.Values)
                {
                    var line = readStationAddressFile.ReadLine();
                    var record = line.Split(',');
                    if(record.Length < 4) throw new Exception("Too Short Address");

                    string premise = "";
                    for(int i = 4; i < record.Length; i++) premise += record[i] + " ";

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
            double[] weather = ev.getWeather();
            bool[] b_weather = ev.get_b_weather();

            //find stations and drone
            DroneStationFinder finder = new DroneStationFinder(ev);
            Tuple<string, int> stationDroneIdx = finder.findAvailableDrone();

            if(stationDroneIdx.Item1.Length == 0) return;

            DroneStation s = stationDict[stationDroneIdx.Item1];
            Drone drone = s.drones[stationDroneIdx.Item2];

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
            double[] weather = ev.getWeather();
            bool[] b_weather = ev.get_b_weather();

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

        public void setGoldenTime(double _goldenTime1, double _goldenTime2)
        {
            goldenTime = new Tuple<double, double>(_goldenTime1, _goldenTime2);
        }

        public Tuple<double,double> getGoldenTime()
        {
            return goldenTime;
        }
    }
}

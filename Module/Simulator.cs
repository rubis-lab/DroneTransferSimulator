using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DroneTransferSimulator
{
    public class Simulator
    {
        /* singleton instance for Simulator */
        private static Simulator instance;
        public bool isDone = false;

        public double w_temp_low = -10.0;
        public double w_temp_high = 30.0;
        public double w_rain = 1.0;
        public double w_winds = 4.0;
        public double w_snow = 10.0;
        public double w_sight = 500.0;

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
                    Excel.Range rng5 = ws.get_Range("BJ2", "BN16799"); //boolean weather
                    Excel.Range rng6 = ws.get_Range("AR2", "AS16799"); //coordinates
                    Excel.Range rng7 = ws.get_Range("AP2", "AP16799"); //korean address
                    
                    object[,] occrTime = rng1.Value;
                    object[,] ambTime = rng2.Value;
                    object[,] oDate = rng3.Value;
                    object[,] wData = rng4.Value;
                    object[,] bWeather = rng5.Value;
                    object[,] cData= rng6.Value;
                    object[,] kAddr = rng7.Value;

                    for (int r = 1; r <= occrTime.GetLength(0); r++)
                    {
                        if (cData[r, 1] == null || cData[r, 2] == null || oDate[r, 1] == null || oDate[r, 2] == null
                            || occrTime[r, 1] == null  || ambTime[r, 1] == null || bWeather[r, 1] == null
                            || bWeather[r, 2] == null || bWeather[r, 3] == null || bWeather[r, 5] == null 
                            || wData[r, 1] == null || wData[r,3] == null || wData[r,4] == null || kAddr[r, 1] == null) continue;
                        
                        double longitude = System.Convert.ToDouble(cData[r, 1]);
                        double latitude = System.Convert.ToDouble(cData[r, 2]);
                        
                        DateTime date = DateTime.Parse(oDate[r,1].ToString());
                        DateTime time = DateTime.Parse(occrTime[r,1].ToString());
                        DateTime occuredDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
                        
                        DateTime a_date = DateTime.Parse(oDate[r, 2].ToString());
                        DateTime a_time = DateTime.Parse(ambTime[r,1].ToString());
                        DateTime ambulDate = new DateTime(a_date.Year, a_date.Month, a_date.Day, a_time.Hour, a_time.Minute, 0);

                        string _addr = kAddr[r,1].ToString();
                        Address addr = new Address(_addr);
                        
                        double e_temp = System.Convert.ToDouble(wData[r,1]);
                        double e_rain = 0;
                        if(wData[r,2]!=null) e_rain = System.Convert.ToDouble(wData[r,2]);
                        double e_winds = System.Convert.ToDouble(wData[r,3]);
                        double e_windd = System.Convert.ToDouble(wData[r,4]);
                        double e_snow = 0;
                        if(wData[r,5]!=null) e_snow = System.Convert.ToDouble(wData[r,5]);
                        double e_sight = -10;
                        if(wData[r,6]!=null) e_sight = System.Convert.ToDouble(wData[r,6]);
                        double[] e_weather = { e_temp, e_rain, e_winds, e_windd, e_snow, e_sight};
                        
                        bool ep_subzero = System.Convert.ToBoolean(bWeather[r,1]);
                        bool ep_rain = System.Convert.ToBoolean(bWeather[r,2]);
                        bool ep_light = System.Convert.ToBoolean(bWeather[r,3]);
                        bool ep_snow = System.Convert.ToBoolean(bWeather[r,4]);
                        bool ep_sight = System.Convert.ToBoolean(bWeather[r,5]);
                        bool[] eb_weather = { ep_subzero, ep_rain, ep_light, ep_snow, ep_sight };
                        Event.eventType e = new Event.eventType();
                        e = Event.eventType.E_EVENT_OCCURED;
                        events.Add(new Event(latitude, longitude, occuredDate, ambulDate, e, addr, e_weather, eb_weather));
                    }
                    wb.Close(0);
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

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

                String path = Application.StartupPath + @"\StationAddress.csv";
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
                return e.ToString();
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
                double[] weather = e.getWeather();

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

            ev.setResult(Event.eventResult.FAILURE);

            // temp, rain, wind, snow, sight, light
            if (w_temp_high < weather[0] || weather[0] < w_temp_low || (weather[0]<0 && !p_subzero))
            {
                ev.setReason(Event.failReason.WEAHTER);
                ev.setWthFailRsn(0);
            }
            if(b_weather[1] && (!p_rain || w_rain < weather[1]))
            {
                ev.setReason(Event.failReason.WEAHTER);
                ev.setWthFailRsn(1);
            }
            if(w_winds<weather[2])
            {
                ev.setReason(Event.failReason.WEAHTER);
                ev.setWthFailRsn(2);
            }
            if(b_weather[3] && (!p_snow || weather[4]>w_snow))
            {
                ev.setReason(Event.failReason.WEAHTER);
                ev.setWthFailRsn(3);
            }
            if(weather[5]<w_sight && weather[5]>0)
            {
                ev.setReason(Event.failReason.WEAHTER);
                ev.setWthFailRsn(4);
            }
            if(b_weather[2]&& !p_light)
            {
                ev.setReason(Event.failReason.WEAHTER);
                ev.setWthFailRsn(5);
            }

            if (ev.getReason() == Event.failReason.WEAHTER) return;
            
            //find stations and drone
            DroneStationFinder finder = new DroneStationFinder(ev);
            Tuple<string, int> stationDroneIdx = finder.findAvailableDrone();

            if (stationDroneIdx.Item1.Length == 0) return;

            DroneStation s = stationDict[stationDroneIdx.Item1];
            Drone drone = s.drones[stationDroneIdx.Item2];

            double distance = finder.getDistanceFromRecentEvent(s.stationLat, s.stationLng);

            //calculate time
            PathPlanner pathPlanner = PathPlanner.getInstance();
            double calculatedTime;
            calculatedTime = pathPlanner.calcTravelTime(s.stationLat, s.stationLng, coordinates.Item1, coordinates.Item2, maxSpeed, weather);

            DateTime droneArrivalTime = ev.getOccuredDate().AddSeconds(calculatedTime);

            ev.setDroneDate(droneArrivalTime);
            ev.setResult(Event.eventResult.SUCCESS);
            ev.setStationDroneIdx(s, stationDroneIdx.Item2);
            //battery consumption
            drone.fly(distance);
            drone.setStatus(Drone.droneType.D_FLYING);

            //declare coming event
            Event.eventType type = Event.eventType.E_EVENT_ARRIVAL;
            Event e = new Event(coordinates.Item1, coordinates.Item2, droneArrivalTime, droneArrivalTime, type, ev.getAddress(), weather, b_weather);
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
            calculatedTime = pathPlanner.calcTravelTime(eventLat, eventLng, stationLat, stationLng, maxSpeed, weather);

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

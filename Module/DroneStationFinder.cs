using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    class DroneStationFinder
    {
        Dictionary<string, DroneStation> stationDict = Simulator.getInstance().getStationDict();
        private double eventLng, eventLat;
        private struct availableStation
        {
            public int stationIndex;
            public string name;
            public double distance;
        };
        private static bool stationsComparator(ref availableStation lhs, ref availableStation rhs)
        {
            return lhs.distance < rhs.distance;
        }

        private List<availableStation> availableStations = new List<availableStation>();

        public double getDistanceFromRecentEvent(double wgsLat, double wgsLng)
        {
            double kmLat, kmLng;
            kmLat = -(eventLat - wgsLat) * 0.030828 * 60 * 60;
            kmLng = (eventLng - wgsLng) * 0.024697 * 60 * 60;
            return Math.Sqrt(kmLat * kmLat + kmLng * kmLng);
        }

        public DroneStationFinder(Tuple<double, double> coordinates)
        {
            eventLat = coordinates.Item1;
            eventLng = coordinates.Item2;
        }

        public void findAvailableStations()
        {
            List<DroneStation> stations = new List<DroneStation>();
            foreach(KeyValuePair<string, DroneStation> dict in stationDict)
            {
                DroneStation st = dict.Value;
                double distance = getDistanceFromRecentEvent(st.stationLat, st.stationLng);
                
                if(st.coverRange > distance)
                {
                    availableStation a = new availableStation();
                    a.name = dict.Key;
                    a.distance = distance;
                    availableStations.Add(a);
                }
            }
            availableStations = availableStations.OrderBy(n => n.distance).ToList();
        }

        public Tuple<string, int> findAvailableDrone(Time currentTime)
        {
            foreach(availableStation e in availableStations)
            {
                DroneStation s = stationDict[e.name];
                return new Tuple<string, int>(s.name, 0);
             /*   
                s.updateChargingDrones(currentTime);
                if(s.drones.Count != 0) continue;
                else
                {
                    foreach(Drone droneElement in s.drones)
                    {
                        double distance = getDistanceFromRecentEvent(s.stationLat, s.stationLng);
                        if(droneElement.returnStatus() != 1 && droneElement.returnAvailDist() > distance) return new Tuple<int, int>(availableStations.IndexOf(e), s.drones.IndexOf(droneElement));
                    }
                }*/
            }
            return new Tuple<string, int>("", -1);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    class DroneStationFinder
    {
        private double eventLng, eventLat;
        private struct availableStation
        {
            public int stationIndex;
            public double distance;
        };
        private static bool stationsComparator(ref availableStation lhs, ref availableStation rhs)
        {
            return lhs.distance < rhs.distance;
        }

        private List<availableStation> availableStations= new List<availableStation>();

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
            StationManager.getStations(ref stations);
            for(int i = 0; i != stations.Count; ++i)
            {
                double distance = getDistanceFromRecentEvent(stations[i].stationLng, stations[i].stationLat);
                if(stations[i].coverRange > distance)
                {
                    availableStation a = new availableStation();
                    a.stationIndex = i;
                    a.distance = distance;
                    availableStations.Add(a);
                }
            }
            availableStations.OrderBy(n => n.distance).ToList();
        }

        public Tuple<int, int> findAvailableDrone(Time currentTime)
        {
            foreach(availableStation element in availableStations)
            {
                List<DroneStation> stations = new List<DroneStation>();
                StationManager.getStations(ref stations);
                DroneStation s = stations[element.stationIndex];
                s.updateChargingDrones(currentTime);
                if(s.drones.Count != 0) continue;
                else
                {
                    foreach(Drone droneElement in s.drones)
                    {
                        double distance = getDistanceFromRecentEvent(s.stationLat, s.stationLng);
                        if(droneElement.returnStatus() != 1 && droneElement.returnAvailDist() > distance) return new Tuple<int, int>(availableStations.IndexOf(element), s.drones.IndexOf(droneElement));
                    }
                }
            }
            return new Tuple<int, int>(-1, -1);
        }

    }
}

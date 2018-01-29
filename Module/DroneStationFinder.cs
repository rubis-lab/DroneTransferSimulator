﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    public class DroneStationFinder
    {
        Dictionary<string, DroneStation> stationDict = Simulator.getInstance().getStationDict();
        private double eventLng, eventLat;
        private Event e;

        public DroneStationFinder(Event _e)
        {
            e = _e;
            eventLat = e.getCoordinates().Item1;
            eventLng = e.getCoordinates().Item2;
        }
        
        private struct availableStation
        {
            public string name;
            public double distance;
        }

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

        public Tuple<string, int> findAvailableDrone()
        {
            DateTime currentTime = e.getOccuredDate();
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
            if(availableStations.Count == 0)
            {
                Console.WriteLine("No available stations (coverage problem)");
                e.setResult(Event.eventResult.FAILURE);
                e.setReason(Event.failReason.COVERAGE_PROBLEM);
                return new Tuple<string, int>("", -1);
            }
            else
            {   
                availableStations = availableStations.OrderBy(n => n.distance).ToList();
                foreach(availableStation ast in availableStations)
                {
                    DroneStation s = stationDict[ast.name];
                                        
                    s.updateChargingDrones(currentTime);
                    if(s.drones.Count == 0) continue;
                    else
                    {
                        foreach(Drone droneElement in s.drones)
                        {
                            double distance = getDistanceFromRecentEvent(s.stationLat, s.stationLng);

                            if(droneElement.returnStatus() != Drone.droneType.D_FLYING && droneElement.returnAvailDist() > 2 * distance)
                            {
                                return new Tuple<string, int>(s.name, s.drones.IndexOf(droneElement));
                            }
                            
                        }
                    }
                }
                Console.WriteLine("No available drones in available stations");
                e.setResult(Event.eventResult.FAILURE);
                e.setReason(Event.failReason.NO_DRONE);
                return new Tuple<string, int>("", -1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    class StationManager
    {
        private static List<DroneStation> stations;
        public void getStationLocation(int stationNum, ref double lat, ref double lng)
        {
            lng = stations[stationNum].stationLng;
            lat = stations[stationNum].stationLat;
        }
        public void setStationLocation(int stationNum, double lat, double lng)
        {
            stations[stationNum].stationLat = lat;
            stations[stationNum].stationLng = lng;
        }
        public void setStationVector(double coverRange, double stnLat, double stnLng)
        {
            stations.Add(new DroneStation(coverRange, stnLng, stnLat));
        }
        public static void getStations(ref List<DroneStation> droneStation)
        {
            droneStation = stations;
        }
    }
}

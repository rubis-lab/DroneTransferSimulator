using System;
using System.Collections.Generic;

namespace DroneTransferSimulator
{
    class PathPlanner
    {
        private const double CUBE_SIZE = 10;
        private const double UL_LAT = 37.680000;     /* Upper Left bound of latitute for Seoul_40x40_500x500 table */
        private const double UL_LNG = 126.783400;    /* Upper Left bound of longitude for Seoul_40x40_500x500 table */
        private const double LR_LAT = 37.432499;     /* Lower Right bound of latitute for Seoul_40x40_500x500 table */
        private const double LR_LNG = 127.197999;    /* Lower Right bound of longitude for Seoul_40x40_500x500 table */
        private const double DIST_LAT = (UL_LAT - LR_LAT);   /* Distance between UB_LAT and LB_LAT */
        private const double DIST_LNG = (LR_LNG - UL_LNG);   /* Distance between UB_LNG and LB_LNG */

        /* singleton instance for PathPlanner */
        //private static PathPlanner instance;

        /* key: in/out direction, value: map(key: in/out velocity, value: cubeTime) */
        private Dictionary<Tuple<char, char>, Dictionary<Tuple<int, int>, double>> cubeTime;

        class Cube
        {
            private char inFace, outFace;
            private int inVelocity, outVelocity;

            public Cube(char _inFace, char _outFace)
            {
                inFace = _inFace;
                outFace = _outFace;
            }

            public Cube(char _inFace, char _outFace, int _inVelocity, int _outVelocity)
            {
                inFace = _inFace;
                outFace = _outFace;
                inVelocity = _inVelocity;
                outVelocity = _outVelocity;
            }

            public void setCubeVelocity(int _inVelocity, int _outVelocity)
            {
                inVelocity = _inVelocity;
                outVelocity = _outVelocity;
            }

            public int getType()
            {
                return inFace * 100000 + outFace * 100 + inVelocity + outVelocity / 10;
            }
        }

        private PathPlanner()
        {
            getDroneDynamicDBFromVREP();
        }

        private void getDroneDynamicDBFromVREP()
        {
            System.IO.StreamReader readFile = new System.IO.StreamReader("..//..//VrepDroneSim.csv");
            string line;
            string[] row;
            readFile.ReadLine();
            while((line = readFile.ReadLine()) != null)
            {
                row = line.Split(',');
                if(row.Length < 5 || row[4] == "-") continue;

                char inFace = row[0][0];
                char outFace = row[1][0];
                int inVelocity = System.Convert.ToInt32(row[2]);
                int outVelocity = System.Convert.ToInt32(row[3]);
                double time = System.Convert.ToDouble(row[4]);
                storeSimData(inFace, outFace, inVelocity, outVelocity, time);
            }
            readFile.Close();
        }

        private void storeSimData(char inFace, char outFace, int inVelocity, int outVelocity, double time)
        {
            Tuple<char, char> face = new Tuple<char, char>(inFace, outFace);
            Tuple<int, int> velocity = new Tuple<int, int>(inVelocity, outVelocity);

            if(cubeTime == null) cubeTime = new Dictionary<Tuple<char, char>, Dictionary<Tuple<int, int>, double>>();
            if(cubeTime.ContainsKey(face))
            {
                if(cubeTime[face].ContainsKey(velocity)) cubeTime[face][velocity] = time;
                else cubeTime[face].Add(velocity, time);
            }
            else
            {
                cubeTime.Add(face, new Dictionary<Tuple<int, int>, double>());
                cubeTime[face].Add(velocity, time);
            }
        }

        public double calcTravelTime(double srcLat, double srcLng, double dstLat, double dstLng)
        {
            List<Cube> cubes = makeNaivePath(srcLat, srcLng, dstLat, dstLng);

            // Calculate travel time from sequential cubes
            List<Dictionary<int, int>> minPath = new List<Dictionary<int, int>>();
            for(int i = 0; i <= cubes.Count; i++) minPath.Add(new Dictionary<int, int>());

            List<Dictionary<int, double>> minTime = new List<Dictionary<int, double>>();
            for(int i = 0; i <= cubes.Count; i++) minTime.Add(new Dictionary<int, double>());

            minTime[0].Add(0, 0.0);

            for(int i = 0; i < cubes.Count; i++)
            {
                int cubeType = cubes[i].getType();
                char inFace = Convert.ToChar(cubeType / 100000);
                char outFace = Convert.ToChar((cubeType % 100000) / 100);
                Tuple<char, char> face = new Tuple<char, char>(inFace, outFace);
                
                Dictionary<Tuple<int, int>, double> velMap = cubeTime[face];

                foreach(KeyValuePair<int, double> e in minTime[i])
                {
                    int inVelocity = e.Key;
                    for(int outVelocity = 0; outVelocity <= 60; outVelocity += 10)
                    {
                        Tuple<int, int> velocity = new Tuple<int, int>(inVelocity, outVelocity);
                        if(velMap.ContainsKey(velocity))
                        {
                            double time = e.Value + velMap[velocity];
                            if(minTime[i + 1].ContainsKey(outVelocity))
                            {
                                if(minTime[i + 1][outVelocity] > time)
                                {
                                    minTime[i + 1][outVelocity] = time;
                                    minPath[i + 1][outVelocity] = inVelocity;
                                }
                            }
                            else
                            {
                                minTime[i + 1].Add(outVelocity, time);
                                minPath[i + 1].Add(outVelocity, inVelocity);
                            }
                        }
                    }
                }
            }
            
            int inVel = 0;
            for(int i = cubes.Count; i > 0; i--)
            {
                int outVel = inVel;
                inVel = minPath[i][outVel];
                cubes[i - 1].setCubeVelocity(inVel, outVel);
            }

            double totalTime = 0;
            foreach(Cube e in cubes) totalTime += getRequiredTime(e.getType());
            
            return totalTime;
        }

        // Traversal Path from start (Latitude, Longitude) to end (Latitude, Longitude)
        private List<Cube> makeNaivePath(double srcLat, double srcLng, double dstLat, double dstLng)
        {
            List<Cube> cubes = new List<Cube>();

            convertWGStoKm(srcLat, srcLng, ref srcLat, ref srcLng);
            convertWGStoKm(dstLat, dstLng, ref dstLat, ref dstLng);
            double distance = System.Math.Sqrt((srcLat - dstLat) * (srcLat - dstLat) + (srcLng - dstLng) * (srcLng - dstLng)) * 1000;
            
            int srcRow = 0, srcCol = 0, dstRow = 0, dstCol = 0;
            convertKmtoRC(srcLat, srcLng, ref srcRow, ref srcCol);
            convertKmtoRC(dstLat, dstLng, ref dstRow, ref dstCol);

            double height = calcMaxHeight(srcLat, srcLng, dstLat, dstLng);
            
            DroneMap droneMap = DroneMap.getInstance();

            List<DroneMapData> srcSet = droneMap.getData(srcRow, srcCol, srcRow, srcCol);
            double srcHeight = srcSet[0].landElevation;

            List<DroneMapData> dstSet = droneMap.getData(dstRow, dstCol, dstRow, dstCol);
            double dstHeight = dstSet[0].landElevation;

            for(double h = srcHeight; h <= height; h += 10.0) cubes.Add(new Cube('d', 'u'));
            cubes.Add(new Cube('d', 'r'));
            for(double d = 0.0; d <= distance; d += 10.0) cubes.Add(new Cube('l', 'r'));
            cubes.Add(new Cube('l', 'd'));
            for(double h = dstHeight; h <= height; h += 10.0) cubes.Add(new Cube('u', 'd'));

            return cubes;
        }
        
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private double calcMaxHeight(double srcLat, double srcLng, double dstLat, double dstLng)
        {/*
            double maxHeight = 0.0;
            DroneMap droneMap = DroneMap.getInstance();
            
            if(srcLng > dstLng)
            {
                Swap<double>(ref srcLat, ref dstLat);
                Swap<double>(ref srcLng, ref dstLng);
            }
            convertWGStoKm(srcLat, srcLng, ref srcLat, ref srcLng);
            convertWGStoKm(dstLat, dstLng, ref dstLat, ref dstLng);

            double theta = System.Math.Atan2(dstLat - srcLat, dstLng - srcLng);
            double distance = System.Math.Sqrt((srcLat - dstLat) * (srcLat - dstLat) + (srcLng - dstLng) * (srcLng - dstLng));

            double srcX = srcLng + System.Math.Min(System.Math.Cos(theta + System.Math.PI / 4 * 3), System.Math.Cos(theta - System.Math.PI / 4 * 3)) * CUBE_SIZE / 2 / 1000.0;
            double dstX = dstLng + System.Math.Max(System.Math.Cos(theta + System.Math.PI / 4 * 1), System.Math.Cos(theta - System.Math.PI / 4 * 1)) * CUBE_SIZE / 2 / 1000.0;

            int srcRow = 0, srcCol = 0, dstRow = 0, dstCol = 0;
            convertKmtoRC(0, srcX, ref srcRow, ref srcCol);
            convertKmtoRC(0, dstX, ref dstRow, ref dstCol);

            for(int col = srcCol; col <= dstCol; col++)
            {
                double x = 0, y = 0;
                convertRCtoKm(0, col, ref y, ref x);

                double y1 = (-CUBE_SIZE / 2000.0 - (x - srcLng) * System.Math.Cos(theta)) / System.Math.Sin(theta) + srcLat;
                double y2 = ((distance + CUBE_SIZE / 2000.0) - (x - srcLng) * System.Math.Cos(theta)) / System.Math.Sin(theta) + srcLat;
                double y3 = (-CUBE_SIZE / 2000.0 + (x - srcLng) * System.Math.Sin(theta)) / System.Math.Cos(theta) + srcLat;
                double y4 = (CUBE_SIZE / 2000.0 + (x - srcLng) * System.Math.Sin(theta)) / System.Math.Cos(theta) + srcLat;

                if(y1 > y2) Swap<double>(ref y1, ref y2);
                if(y3 > y4) Swap<double>(ref y3, ref y4);

                int r1 = 0, r2 = 0, c = 0;
                convertKmtoRC(System.Math.Max(y1, y3), 0, ref r1, ref c);
                convertKmtoRC(System.Math.Min(y2, y4), 0, ref r2, ref c);

                List<DroneMapData> resultSet = droneMap.getData(r1, col, r2, col);
                foreach(DroneMapData e in resultSet) maxHeight = System.Math.Max(maxHeight, e.buildingHeight + e.landElevation);
            }

            return maxHeight;*/
            return 100.0;
        }

        private double getRequiredTime(int cubeType)
        {
            char inFace = Convert.ToChar(cubeType / 100000);
            char outFace = Convert.ToChar((cubeType % 100000) / 100);
            int inVelocity = (cubeType % 100) / 10 * 10;
            int outVelocity = (cubeType % 100) % 10 * 10;

            Tuple<char, char> face = new Tuple<char, char>(inFace, outFace);
            Tuple<int, int> velocity = new Tuple<int, int>(inVelocity, outVelocity);

            return cubeTime[face][velocity];
        }

        /* latitude 1 sec = 30.828 m, longitude 1 sec = 24.697 m */
        public void convertKmtoWGS(double kmLat, double kmLng, ref double wgsLat, ref double wgsLng)
        {
            wgsLat = -kmLat / 0.030828 / 60 / 60;
            wgsLng = kmLng / 0.024697 / 60 / 60;
        }

        public void convertKmtoRC(double kmLat, double kmLng, ref int row, ref int col)
        {
            convertKmtoWGS(kmLat, kmLng, ref kmLat, ref kmLng);
            convertWGStoRC(kmLat, kmLng, ref row, ref col);
        }

        public void convertWGStoKm(double wgsLat, double wgsLng, ref double kmLat, ref double kmLng)
        {
            kmLat = -wgsLat * 0.030828 * 60 * 60;
            kmLng = wgsLng * 0.024697 * 60 * 60;
        }

        public void convertWGStoRC(double wgsLat, double wgsLng, ref int row, ref int col)
        {
            row = Convert.ToInt32((UL_LAT - wgsLat) * 20000 / DIST_LAT);
            col = Convert.ToInt32((wgsLng - UL_LNG) * 20000 / DIST_LNG);
        }

        public void convertRCtoKm(int row, int col, ref double kmLat, ref double kmLng)
        {
            convertRCtoWGS(row, col, ref kmLat, ref kmLng);
            convertWGStoKm(kmLat, kmLng, ref kmLat, ref kmLng);
        }

        public void convertRCtoWGS(int row, int col, ref double wgsLat, ref double wgsLng)
        {
            wgsLat = UL_LAT - row * DIST_LAT / 20000;
            wgsLng = UL_LNG + col * DIST_LNG / 20000;
        }
        
        public static PathPlanner getInstance()
        {
            PathPlanner instance = new PathPlanner();
            if (instance == null) instance = new PathPlanner();
            return instance;
        }
    }
}

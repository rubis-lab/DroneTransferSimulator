using MySql.Data.Common;
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;

namespace DroneTransferSimulator
{
    class DroneMapData
    {
        public double lat, lng;
        public double landElevation, buildingHeight;

	    public DroneMapData(double _lat, double _lng, double _landElevation, double _buildingHeight)
        {
            lat = _lat;
            lng = _lng;
            landElevation = _landElevation;
            buildingHeight = _buildingHeight;
        }
    }

    class DroneMap
    {
        private const string DB_HOST = "prism.snu.ac.kr";
        private const string DB_USER = "root";
        private const string DB_PASS = "4542rubis";
        private const string DB_NAME = "WonseokMap";
        private const string TBL_NAME = "Seoul_40x40_500x500";

        /* singleton instance for DroneMap */
        private static DroneMap instance;

        private bool hasConnection;
        private MySqlConnection conn;

        private List<DroneMapData> resultSet;
        private Dictionary<Tuple<int, int>, DroneMapData> dataMap;

        private DroneMap()
        {
            resultSet = new List<DroneMapData>();
            dataMap = new Dictionary<Tuple<int, int>, DroneMapData>();

            connectDB();
            if(!hasConnection) return;
        }

        ~DroneMap()
        {
            if(!hasConnection) return;
            else if(conn != null) conn.Close();
        }

        private void connectDB()
        {
            hasConnection = false;

            string connStr = "server={0};user={1};database={2};port=3306;password={3}";
            connStr = string.Format(connStr, DB_HOST, DB_USER, DB_NAME, DB_PASS);
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                hasConnection = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private bool storeDroneMapData(int row, int col)
        {
            Tuple<int, int> index = new Tuple<int, int>(row, col);
            if(dataMap.ContainsKey(index))
            {
                resultSet.Add(dataMap[index]);
            }
            else
            {
                string queryStr = "select * from " + TBL_NAME;
                string queryWhere = " where ROW = " + row + " and COL = " + col;

                MySqlCommand cmd = new MySqlCommand(queryStr + queryWhere, conn);

                try
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        double lat = Convert.ToDouble(rdr[2]);
                        double lng = Convert.ToDouble(rdr[3]);
                        double landElevation = Convert.ToDouble(rdr[4]);
                        double buildingHeight = Convert.ToDouble(rdr[5]);

                        DroneMapData droneMapData = new DroneMapData(lat, lng, landElevation, buildingHeight);

                        resultSet.Add(droneMapData);
                        dataMap.Add(index, droneMapData);
                    }
                    rdr.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
            return true;
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public List<DroneMapData> getData(int srcRowIdx, int srcColIdx, int dstRowIdx, int dstColIdx)
        {
            if(!hasConnection) return null;
            
            /* Do ascending order for query */
            if(dstRowIdx < srcRowIdx) Swap<int>(ref srcRowIdx, ref dstRowIdx);
            if(dstColIdx < srcColIdx) Swap<int>(ref srcColIdx, ref dstColIdx);

            /* Clear the vector for result */
            if(resultSet.Count != 0) resultSet.Clear();

            /* Add where statement to query */
            for(int row = srcRowIdx; row <= dstRowIdx; row++)
            {
                for(int col = srcColIdx; col <= dstColIdx; col++)
                {
                    if(!storeDroneMapData(row, col)) return null;
		        }
	        }
            return resultSet;
        }

        public static DroneMap getInstance()
        {
            if(instance == null) instance = new DroneMap();
            return instance;
        }
    }
}
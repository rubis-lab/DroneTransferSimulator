using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DroneTransferSimulator
{
    public class Address
    {
        private string address = "";

        private string country = "";
        private string local = "";
        private string subLocal1 = "";
        private string subLocal2 = "";
        private string premise = "";

        private double latitude = 0;
        private double longitude = 0;

        public Address(double _latitude, double _longitude)
        {
            latitude = _latitude;
            longitude = _longitude;

            parseAddress(latitude, longitude);
        }

        public Address(string _country, string _local, string _subLocal1, string _subLocal2, string _premise)
        {
            country = _country;
            local = _local;
            subLocal1 = _subLocal1;
            subLocal2 = _subLocal2;
            premise = _premise;

            address = subLocal1 + " " + subLocal2 + " " + premise;
        }

        private string requestJson(double latitude, double longitude)
        {
            string result = null;
            string url = String.Format("http://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&language=ko", latitude, longitude);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                stream.Close();
                response.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public void parseAddress(double latitude, double longitude)
        {
            try
            {
                JObject obj = JObject.Parse(requestJson(latitude, longitude));
                address = obj["results"][0]["formatted_address"].ToString();
            }
            catch(Exception e)
            {
                address = "NA";
            }
     }
        
        override public string ToString()
        {
            return address;
        }
    }
}

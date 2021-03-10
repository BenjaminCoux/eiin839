using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Device.Location;
//using Newtonsoft.Json;

namespace TD3
{   class Position
    {
        public float lat { get; set; }
        public float lng { get; set; }

        public Position(float lat,float lng)
        {
            this.lat = lat;
            this.lng = lng;
        }
    }
    class Station
    { public int number { get; set;}
      public string name { get; set; }
      public Position position { get; set; }

    public Station()
        {

        }  

    public Station(string name,int number,Position position)
        {
            this.name = name;
            this.number = number;
            this.position = position;
            
        }
      
     
    }
}



namespace TD3
{
    class Program
    {
        static string apiKey = "7950b91f9f984d3301d8c91b486bae24a2fb17ab";
   
       

       

        static async void afficheContrat()
        {
            HttpClient myClient = new HttpClient();
            HttpResponseMessage rep=await myClient.GetAsync("https://api.jcdecaux.com/vls/v3/contracts?apiKey="+apiKey);
            string responce = await rep.Content.ReadAsStringAsync();
            Console.WriteLine(responce);
        }

        static async void afficheFromContract(string contract)
        {
            HttpClient myClient = new HttpClient();
            HttpResponseMessage rep = await myClient.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + apiKey);
            string responce = await rep.Content.ReadAsStringAsync();
            Console.WriteLine(responce);
        }

        static async void afficheNewsFromStation(string contract,int station)
        {
            HttpClient myClient = new HttpClient();
            HttpResponseMessage rep = await myClient.GetAsync("https://api.jcdecaux.com/vls/v1/stations/"+station+"?contract="+contract+"&apiKey=7950b91f9f984d3301d8c91b486bae24a2fb17ab");
            string responce = await rep.Content.ReadAsStringAsync();
            Console.WriteLine(responce);

        }

        static async void getNearestStation(float X,float Y,string contrat)
        {
            HttpClient myClient = new HttpClient();
            HttpResponseMessage rep = await myClient.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + contrat + "&apiKey=" + apiKey);
            string responce = await rep.Content.ReadAsStringAsync();
            List<Station> listStation= JsonSerializer.Deserialize<List<Station>>(responce);
            GeoCoordinate myPos = new GeoCoordinate(X,Y);
            List<GeoCoordinate> statsPos=new List<GeoCoordinate>();
            for(int i = 0; i < listStation.Count; i++)
            {
                statsPos.Add(new GeoCoordinate(listStation[i].position.lat, listStation[i].position.lng));
            }
            double distance = statsPos[0].GetDistanceTo(myPos);
            int indice = 0;
            for(int i = 1; i < statsPos.Count; i++)
            {
                double tmp = statsPos[i].GetDistanceTo(myPos);
                if (tmp < distance)
                {
                    distance = tmp;
                    indice = i;
                }
            }
            Console.WriteLine("la station la plus proche est : "+listStation[indice].name);
           

        }

        static void Main(string[] args)
        {
            // afficheContrat();
            //afficheFromContract("amiens");
            //afficheNewsFromStation("amiens", 25);
            getNearestStation(10, 10, "amiens");
            Console.ReadLine();
        }
    }
}

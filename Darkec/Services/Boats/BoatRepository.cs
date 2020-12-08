using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Helpers;
using Darkec.Models;

namespace Darkec.Services.Boats
{
    public class BoatRepository : IObjectRepository<int, Boat>
    {
        private string JsonFileName = @".\wwwroot\Data\JsonBoats.json";

        private Dictionary<int, Boat> boats;

        public BoatRepository()
        {
            boats = JsonFileReader<int, Boat>.ReadJson(JsonFileName);
            if (boats == null)
            {
                boats = new Dictionary<int, Boat>();
            }
        }

        public Dictionary<int, Boat> GetAllObjects()
        {
            return boats;
        }

        public void AddObject(Boat boat)
        {
            if (!(boats.Keys.Contains(boat.Id)))
            {
                boats.Add(boat.Id, boat);
                JsonFileWriter<int, Boat>.WriteToJson(boats, JsonFileName);
            }
        }

        public Boat GetObject(int id)
        {
            return boats[id];
        }

        public void UpdateObject(Boat boat)
        {
            if (boat != null)
            {
                boats[boat.Id] = boat;
                JsonFileWriter<int, Boat>.WriteToJson(boats, JsonFileName);
            }
        }

        public void DeleteObject(Boat boat)
        {
            if (boat != null)
            {
                boats.Remove(boat.Id);
                JsonFileWriter<int, Boat>.WriteToJson(boats, JsonFileName);
            }
        }

        public Dictionary<int, Boat> FilterObjects(string registrationNumber)
        {

            Dictionary<int, Boat> filteredBoats = new Dictionary<int, Boat>();

            foreach (Boat boat in boats.Values)
            {
                if (boat.RegistrationNumber.StartsWith(registrationNumber))
                {
                    filteredBoats.Add(boat.Id, boat);
                }
            }
            return filteredBoats;
        }
    }
}
﻿using System;
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
            AutoIncrementId(boat);
            boats.Add(boat.Id, boat);
            JsonFileWriter<int, Boat>.WriteToJson(boats, JsonFileName);
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
        public Boat AutoIncrementId(Boat boat)
        {
            List<int> boatId = new List<int>();
            foreach (var Boat in boats.Values)
            {
                boatId.Add(Boat.Id);
            }
            if (boatId.Count != 0)
            {
                int increment = boatId.Max() + 1;
                boat.Id = increment;
            }
            else
            {
                boat.Id = 1;
            }
            return boat;
        }
        public void BookObject(User user, Boat boat)
        {
            boat.Available = false;
            boat.Customer = user;
            JsonFileWriter<int, Boat>.WriteToJson(boats, JsonFileName);
        }
        public void CancelObject(User user, Boat boat)
        {
            if (boat.Customer == user)
            {
                boat.Available = true;
                boat.Customer = null;
                JsonFileWriter<int, Boat>.WriteToJson(boats, JsonFileName);
            }
        }
    }
}
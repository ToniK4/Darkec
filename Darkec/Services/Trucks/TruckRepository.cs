using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Helpers;
using Darkec.Models;

namespace Darkec.Services.Trucks
{
    public class TruckRepository : IObjectRepository<int, Truck>
    {
        private string JsonFileName = @".\wwwroot\Data\JsonTrucks.json";

        private Dictionary<int, Truck> trucks;

        public TruckRepository()
        {
            trucks = JsonFileReader<int, Truck>.ReadJson(JsonFileName);
            if (trucks == null)
            {
                trucks = new Dictionary<int, Truck>();
            }
        }

        public Dictionary<int, Truck> GetAllObjects()
        {
            return trucks;
        }

        public void AddObject(Truck truck)
        {
            AutoIncrementId(truck);
            trucks.Add(truck.Id, truck);
            JsonFileWriter<int, Truck>.WriteToJson(trucks, JsonFileName);
        }

        public Truck GetObject(int id)
        {
            return trucks[id];
        }

        public void UpdateObject(Truck truck)
        {
            if (truck != null)
            {
                trucks[truck.Id] = truck;
                JsonFileWriter<int, Truck>.WriteToJson(trucks, JsonFileName);
            }
        }

        public void DeleteObject(Truck truck)
        {
            if (truck != null)
            {
                trucks.Remove(truck.Id);
                JsonFileWriter<int, Truck>.WriteToJson(trucks, JsonFileName);
            }
        }

        public Dictionary<int, Truck> FilterObjects(string registrationNumber)
        {

            Dictionary<int, Truck> filteredTrucks = new Dictionary<int, Truck>();

            foreach (Truck truck in trucks.Values)
            {
                if (truck.RegistrationNumber.StartsWith(registrationNumber))
                {
                    filteredTrucks.Add(truck.Id, truck);
                }
            }
            return filteredTrucks;
        }
        public Truck AutoIncrementId(Truck truck)
        {
            List<int> truckId = new List<int>();
            foreach (var Truck in trucks.Values)
            {
                truckId.Add(Truck.Id);
            }
            if (truckId.Count != 0)
            {
                int increment = truckId.Max() + 1;
                truck.Id = increment;
            }
            else
            {
                truck.Id = 1;
            }
            return truck;
        }

        //Two methods that don't have implementation but are here since this class inherits the IObjectRepository interface.
        //This could be solved by having the class not implement the interface but that comes with its own complications.
        public void BookObject(User user, Truck truck)
        {
            
        }
        public void CancelObject(User user, Truck truck)
        {

        }
    }
}
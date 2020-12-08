using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Helpers;
using Darkec.Models;

namespace Darkec.Services.Apartments
{
    public class ApartmentRepository : IObjectRepository<int, Apartment>
    {
        private string JsonFileName = @".\wwwroot\Data\JsonApartments.json";
        private Dictionary<int, Apartment> apartments;
        public ApartmentRepository()
        {
            apartments = JsonFileReader<int, Apartment>.ReadJson(JsonFileName);

            //Uncomment this line of code if you want to use mock data
            //apartments = MockData.MockApartments.Instance.GetAllApartments();

            if (apartments == null)
            {
                apartments = new Dictionary<int, Apartment>();
            }
        }

        public Dictionary<int, Apartment> GetAllObjects()
        {
            return apartments;
        }

        public void AddObject(Apartment apartment)
        {
            if (!(apartments.Keys.Contains(apartment.Id)))
            {
                apartments.Add(apartment.Id, apartment);
                JsonFileWriter<int, Apartment>.WriteToJson(apartments, JsonFileName);
            }
        }

        public Apartment GetObject(int id)
        {
            return apartments[id];
        }

        public void UpdateObject(Apartment apartment)
        {
            if (apartment != null)
            {
                apartments[apartment.Id] = apartment;
                JsonFileWriter<int, Apartment>.WriteToJson(apartments, JsonFileName);
            }
        }

        public void DeleteObject(Apartment apartment)
        {
            if (apartment != null)
            {
                apartments.Remove(apartment.Id);
                JsonFileWriter<int, Apartment>.WriteToJson(apartments, JsonFileName);
            }
        }

        public Dictionary<int, Apartment> FilterObjects(string apartmentName)
        {

            Dictionary<int, Apartment> filteredApartments = new Dictionary<int, Apartment>();

            foreach (Apartment apartment in apartments.Values)
            {
                if (apartment.Name.StartsWith(apartmentName))
                {
                    filteredApartments.Add(apartment.Id, apartment);
                }
            }
            return filteredApartments;
        }
    }
}
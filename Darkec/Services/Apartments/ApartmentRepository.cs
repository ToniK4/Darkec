using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;

namespace Darkec.Services.Apartments
{
    public class ApartmentRepository : IObjectRepository<int, Apartment>
    {
        private Dictionary<int, Apartment> apartments;
        private JsonFileApartmentService JsonFileApartmentService { get; set; }
        public ApartmentRepository(JsonFileApartmentService jsonFileItemService)
        {
            JsonFileApartmentService = jsonFileItemService;
            apartments = JsonFileApartmentService.GetJsonApartments();

            //Uncomment this line of code if you want to use mock data
            //apartments = MockData.MockApartments.Instance.GetAllApartments();
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
                JsonFileApartmentService.SaveJsonApartment(apartments);
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
                JsonFileApartmentService.SaveJsonApartment(apartments);
            }
        }

        public void DeleteObject(Apartment apartment)
        {
            if (apartment != null)
            {
                apartments.Remove(apartment.Id, out apartment);
                JsonFileApartmentService.SaveJsonApartment(apartments);
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
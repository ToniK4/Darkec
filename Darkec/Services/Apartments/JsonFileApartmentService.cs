using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Helpers;
using Darkec.Models;

namespace Darkec.Services.Apartments
{
    public class JsonFileApartmentService
    {
        string JsonFileName = @".\wwwroot\Data\JsonApartments.json";
        public Dictionary<int, Apartment> GetJsonApartments()
        {
            return JsonFileReader<int, Apartment>.ReadJson(JsonFileName);
        }
        public void SaveJsonApartment(Dictionary<int, Apartment> apartments)
        {
            JsonFileWriter<int, Apartment>.WriteToJson(apartments, JsonFileName);
        }
    }
}

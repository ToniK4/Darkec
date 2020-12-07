using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;
using Darkec.Services;

namespace Darkec.MockData
{
    public class MockApartments
    {
        private Dictionary<int, Apartment> Apartments;

        private static MockApartments _instance;
        private MockApartments()
        {
            Apartments = new Dictionary<int, Apartment>();
            Apartments.Add(1, new Apartment() { Id = 1, Name = "AP1", Description = "One room, one toilet, kitchen and balcony.", Price = 35, ImageName= "ap1.jpg" });
            Apartments.Add(2, new Apartment() { Id = 2, Name = "AP2", Description = "One room, one toilet, kitchen and balcony.", Price = 40, ImageName = "ap2.jpg" });
            Apartments.Add(3, new Apartment() { Id = 3, Name = "AP3", Description = "Studio apartment.", Price = 30, ImageName = "ap3.jpg" });
        }

        public static MockApartments Instance
        {
            get
            { 
                if (_instance == null)
                {
                    _instance = new MockApartments();
                }
                return _instance;
            }
        }
        public Dictionary<int, Apartment> GetAllApartments()
        {
            return Apartments;
        }

        public void AddStudent(Apartment student)
        {
            Apartments.Add(student.Id, student);
        }
    }
}
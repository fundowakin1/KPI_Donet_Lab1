using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public BodyType BodyType { get; set; }
        public int YearOfIssue { get; set; }
        public string LicencePlate { get; set; }
        public string Condition { get; set; }
        public string VinCode { get; set; }
        public int ModelId { get; set; }
    }

    public enum BodyType
    {
        Sedan,
        Coupe,
        Hatchback,
        Minivan,
        Pickup
    }
}

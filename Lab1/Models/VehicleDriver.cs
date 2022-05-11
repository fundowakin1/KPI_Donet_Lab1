using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class VehicleDriver
    {
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public bool IsOwner { get; set; }
    }
}

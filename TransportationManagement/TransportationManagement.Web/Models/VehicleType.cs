using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
            VehiclesTypesVehiclesExtensions = new HashSet<VehicleTypeVehicleExtension>();
        }

        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<VehicleTypeVehicleExtension> VehiclesTypesVehiclesExtensions { get; set; }
    }
}

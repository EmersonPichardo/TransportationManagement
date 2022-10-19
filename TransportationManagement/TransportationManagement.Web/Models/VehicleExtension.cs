using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class VehicleExtension
    {
        public VehicleExtension()
        {
            TransportationsDetailsVehiclesExtensions = new HashSet<TransportationDetailVehicleExtension>();
            VehiclesTypesVehiclesExtensions = new HashSet<VehicleTypeVehicleExtension>();
        }

        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<TransportationDetailVehicleExtension> TransportationsDetailsVehiclesExtensions { get; set; }
        public virtual ICollection<VehicleTypeVehicleExtension> VehiclesTypesVehiclesExtensions { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class VehicleTypeVehicleExtension
    {
        public string VehiclesTypesDescription { get; set; } = null!;
        public string VehiclesExtensionsDescription { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual VehicleExtension VehiclesExtensionsDescriptionNavigation { get; set; } = null!;
        public virtual VehicleType VehiclesTypesDescriptionNavigation { get; set; } = null!;
    }
}

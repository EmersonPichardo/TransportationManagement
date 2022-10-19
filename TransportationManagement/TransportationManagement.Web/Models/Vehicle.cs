using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            TransportationsDetails = new HashSet<TransportationDetail>();
        }

        public string LicensePlate { get; set; } = null!;
        public string VehiclesTypesDescription { get; set; } = null!;
        public string? ChassisNumber { get; set; }
        public string Status { get; set; } = null!;

        public virtual VehicleType VehiclesTypesDescriptionNavigation { get; set; } = null!;
        public virtual ICollection<TransportationDetail> TransportationsDetails { get; set; }
    }
}

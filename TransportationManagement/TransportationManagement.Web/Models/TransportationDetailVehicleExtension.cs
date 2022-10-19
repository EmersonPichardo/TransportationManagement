using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class TransportationDetailVehicleExtension
    {
        public int TransportationDetailId { get; set; }
        public string VehicleExtensionDescription { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual TransportationDetail TransportationDetail { get; set; } = null!;
        public virtual VehicleExtension VehicleExtensionDescriptionNavigation { get; set; } = null!;
    }
}

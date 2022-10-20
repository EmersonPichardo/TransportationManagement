using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class VehicleExtension
    {
        public VehicleExtension()
        {
            TransportationsDetailsVehiclesExtensions = new HashSet<TransportationDetailVehicleExtension>();
            VehiclesTypesVehiclesExtensions = new HashSet<VehicleTypeVehicleExtension>();
        }

        [Display(Name = "Descripción")]
        public string Description { get; set; } = null!;
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual ICollection<TransportationDetailVehicleExtension> TransportationsDetailsVehiclesExtensions { get; set; }
        public virtual ICollection<VehicleTypeVehicleExtension> VehiclesTypesVehiclesExtensions { get; set; }
    }
}

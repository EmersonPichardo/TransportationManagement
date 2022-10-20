using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class VehicleTypeVehicleExtension
    {
        [Display(Name = "Tipo de vehículo")]
        public string VehiclesTypesDescription { get; set; } = null!;
        [Display(Name = "Extensión")]
        public string VehiclesExtensionsDescription { get; set; } = null!;
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual VehicleExtension VehiclesExtensionsDescriptionNavigation { get; set; } = null!;
        public virtual VehicleType VehiclesTypesDescriptionNavigation { get; set; } = null!;
    }
}

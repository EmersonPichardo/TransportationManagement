using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class TransportationDetailVehicleExtension
    {
        public int TransportationDetailId { get; set; }
        [Display(Name = "Extensión")]
        public string VehicleExtensionDescription { get; set; } = null!;
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual TransportationDetail TransportationDetail { get; set; } = null!;
        public virtual VehicleExtension VehicleExtensionDescriptionNavigation { get; set; } = null!;
    }
}

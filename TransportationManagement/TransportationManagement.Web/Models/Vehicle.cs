using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            TransportationsDetails = new HashSet<TransportationDetail>();
        }

        [Display(Name = "Número de placa")]
        public string LicensePlate { get; set; } = null!;
        [Display(Name = "Tipo de vehículo")]
        public string VehiclesTypesDescription { get; set; } = null!;
        [Display(Name = "Número de chasis")]
        public string? ChassisNumber { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual VehicleType VehiclesTypesDescriptionNavigation { get; set; } = null!;
        public virtual ICollection<TransportationDetail> TransportationsDetails { get; set; }
    }
}

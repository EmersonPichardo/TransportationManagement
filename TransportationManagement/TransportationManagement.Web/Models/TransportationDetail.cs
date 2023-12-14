using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class TransportationDetail
    {
        public TransportationDetail()
        {
            TransportationsDetailsVehiclesExtensions = new HashSet<TransportationDetailVehicleExtension>();
        }

        public int Id { get; set; }
        public int TransportationHeaderId { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; } = null!;
        [Display(Name = "Punto de recogida")]
        public string PickUpLocation { get; set; } = null!;
        [Display(Name = "Punto de entrega")]
        public string DeliveryLocation { get; set; } = null!;
        [Display(Name = "Fecha de recogida")]
        public DateTime PickUpDate { get; set; }
        [Display(Name = "Fecha de entrega")]
        public DateTime DeliverypDate { get; set; }
        [Display(Name = "Monto")]
        public decimal Amount { get; set; }
        [Display(Name = "Conductor")]
        public int DriverId { get; set; }
        [Display(Name = "Número de placa")]
        public string VehicleLicensePlate { get; set; } = null!;
        [Display(Name = "Estado")]
        public string Status { get; set; } = "New"!;

        public virtual TransportationHeader? TransportationHeader { get; set; } = null!;
        public virtual Driver? Driver { get; set; } = null!;
        public virtual Vehicle? VehicleLicensePlateNavigation { get; set; } = null!;
        public virtual ICollection<TransportationDetailVehicleExtension> TransportationsDetailsVehiclesExtensions { get; set; }
    }
}

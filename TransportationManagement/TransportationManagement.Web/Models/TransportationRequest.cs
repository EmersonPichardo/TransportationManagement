using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class TransportationRequest
    {
        public int Id { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; } = null!;
        [Display(Name = "Punto de recogida")]
        public string PickUpLocation { get; set; } = null!;
        [Display(Name = "Punto de entrega")]
        public string DeliveryLocation { get; set; } = null!;
        [Display(Name = "Fecha de recogida")]
        public DateTime PickUpDate { get; set; }
        [Display(Name = "Fecha de entrega")]
        public DateTime? DeliverypDate { get; set; }
        [Display(Name = "Número de contenedor")]
        public string? ContainerNumber { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;
    }
}

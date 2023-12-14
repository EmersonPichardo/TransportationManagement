using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class Client
    {
        public Client()
        {
            TransportationsHeaders = new HashSet<TransportationHeader>();
        }

        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;
        public string? Rnc { get; set; }
        [Display(Name = "Dirección")]
        public string? Address { get; set; }
        [Display(Name = "Correo electrónico")]
        public string? Email { get; set; }
        [Display(Name = "Número de contacto")]
        public string? ContactNumber { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual ICollection<TransportationHeader> TransportationsHeaders { get; set; }
    }
}

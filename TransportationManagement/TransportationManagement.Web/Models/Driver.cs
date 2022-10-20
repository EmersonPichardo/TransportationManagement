using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class Driver
    {
        public Driver()
        {
            TransportationsDetails = new HashSet<TransportationDetail>();
        }

        public string Id { get; set; } = null!;
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;
        [Display(Name = "Número de RNTT")]
        public string? Rnttnumber { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual ICollection<TransportationDetail> TransportationsDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class TransportationHeader
    {
        public TransportationHeader()
        {
            Invioces = null;
            TransportationsDetails = new ();
        }

        public int Id { get; set; }
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Monto total")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; } = "New"!;

        public virtual Client? Client { get; set; } = null!;
        public virtual List<Invioce>? Invioces { get; set; }
        public virtual List<TransportationDetail>? TransportationsDetails { get; set; }
    }
}

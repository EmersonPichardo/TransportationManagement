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
            Invioces = new HashSet<Invioce>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Monto total")]
        public decimal TotalAmount { get; set; }
        public int TransportationRequestId { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;
        public virtual TransportationRequest TransportationRequest { get; set; } = null!;
        public virtual ICollection<Invioce> Invioces { get; set; }
    }
}

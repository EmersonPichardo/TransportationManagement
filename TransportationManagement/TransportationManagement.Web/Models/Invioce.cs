using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class Invioce
    {
        public Invioce()
        {
            Payments = new HashSet<Payment>();
        }

        public string Number { get; set; } = null!;
        public int TransportationHeaderId { get; set; }
        public string? Ncf { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Taxes { get; set; }
        public decimal? Discount { get; set; }
        public decimal NetAmount { get; set; }
        public string Status { get; set; } = null!;

        public virtual TransportationHeader TransportationHeader { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

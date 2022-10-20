using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class Invioce
    {
        public Invioce()
        {
            Payments = new HashSet<Payment>();
        }

        [Display(Name = "Número de factura")]
        public string Number { get; set; } = null!;
        public int TransportationHeaderId { get; set; }
        [Display(Name = "NCF")]
        public string? Ncf { get; set; }
        [Display(Name = "Monto bruto")]
        public decimal GrossAmount { get; set; }
        [Display(Name = "Impuestos")]
        public decimal Taxes { get; set; }
        [Display(Name = "Descuentos")]
        public decimal? Discount { get; set; }
        [Display(Name = "Monto neto")]
        public decimal NetAmount { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual TransportationHeader TransportationHeader { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

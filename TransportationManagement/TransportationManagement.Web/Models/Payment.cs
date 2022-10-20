using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportationManagement.Web.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        [Display(Name = "Número de factura")]
        public string InvioceNumber { get; set; } = null!;
        [Display(Name = "Fecha del pago")]
        public DateTime Date { get; set; }
        [Display(Name = "Monto")]
        public decimal Amount { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual Invioce InvioceNumberNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public string InvioceNumber { get; set; } = null!;
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = null!;

        public virtual Invioce InvioceNumberNavigation { get; set; } = null!;
    }
}

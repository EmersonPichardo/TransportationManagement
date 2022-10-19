using System;
using System.Collections.Generic;

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
        public DateTime CreationDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int TransportationRequestId { get; set; }
        public string Status { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;
        public virtual TransportationRequest TransportationRequest { get; set; } = null!;
        public virtual ICollection<Invioce> Invioces { get; set; }
    }
}

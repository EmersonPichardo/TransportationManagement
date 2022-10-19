using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class Client
    {
        public Client()
        {
            TransportationsDetails = new HashSet<TransportationDetail>();
            TransportationsHeaders = new HashSet<TransportationHeader>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Rnc { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<TransportationDetail> TransportationsDetails { get; set; }
        public virtual ICollection<TransportationHeader> TransportationsHeaders { get; set; }
    }
}

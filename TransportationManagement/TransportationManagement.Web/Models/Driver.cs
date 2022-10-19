using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class Driver
    {
        public Driver()
        {
            TransportationsDetails = new HashSet<TransportationDetail>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Rnttnumber { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<TransportationDetail> TransportationsDetails { get; set; }
    }
}

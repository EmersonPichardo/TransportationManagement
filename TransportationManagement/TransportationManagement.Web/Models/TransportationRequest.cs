using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class TransportationRequest
    {
        public TransportationRequest()
        {
            TransportationsHeaders = new HashSet<TransportationHeader>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string PickUpLocation { get; set; } = null!;
        public string DeliveryLocation { get; set; } = null!;
        public DateTime PickUpDate { get; set; }
        public DateTime? DeliverypDate { get; set; }
        public string? ContainerNumber { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<TransportationHeader> TransportationsHeaders { get; set; }
    }
}

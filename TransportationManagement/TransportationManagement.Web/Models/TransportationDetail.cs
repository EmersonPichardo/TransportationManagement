using System;
using System.Collections.Generic;

namespace TransportationManagement.Web.Models
{
    public partial class TransportationDetail
    {
        public TransportationDetail()
        {
            TransportationsDetailsVehiclesExtensions = new HashSet<TransportationDetailVehicleExtension>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; } = null!;
        public string PickUpLocation { get; set; } = null!;
        public string DeliveryLocation { get; set; } = null!;
        public DateTime PickUpDate { get; set; }
        public DateTime DeliverypDate { get; set; }
        public decimal Amount { get; set; }
        public string DriverId { get; set; } = null!;
        public string VehicleLicensePlate { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;
        public virtual Driver Driver { get; set; } = null!;
        public virtual Vehicle VehicleLicensePlateNavigation { get; set; } = null!;
        public virtual ICollection<TransportationDetailVehicleExtension> TransportationsDetailsVehiclesExtensions { get; set; }
    }
}

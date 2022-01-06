using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gaadi_ghoda_server.Models
{
    public class LorryReceipt
    {
        public Guid OrgId { get; set; }
        public Guid Id { get; set; }
        public int No { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string VehicleNo { get; set; }
        public double Weight { get; set; }
        public double Rate { get; set; }
        public Guid PartyId { get; set; }
        public Guid BrokerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gaadi_ghoda_server.Models
{
    public class Party
    {
        public Guid OrgId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}

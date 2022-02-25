namespace gaadi_ghoda_server.Models
{
    public class Broker
    {
        public Guid Id { get; set; }
        public string FirmName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

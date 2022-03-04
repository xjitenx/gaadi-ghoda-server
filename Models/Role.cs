namespace gaadi_ghoda_server.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool BookieAccess { get; set; }
        public bool BrokerAccess { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

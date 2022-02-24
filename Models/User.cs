namespace gaadi_ghoda_server.Models
{
    public class User
    {
        public Guid OrgId {  get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }
    }
}

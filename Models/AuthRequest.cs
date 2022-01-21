namespace gaadi_ghoda_server.Models
{
    public class AuthRequest
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public bool isValid()
        {
            return LoginId != null && Password != null;
        }
    }
}

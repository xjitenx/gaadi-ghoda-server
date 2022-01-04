namespace gaadi_ghoda_server.Models
{
    public class LoginResponse
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public bool LoginSuccess { get; set; } = false;
    }
}

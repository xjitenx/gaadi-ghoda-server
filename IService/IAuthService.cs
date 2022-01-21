using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IService
{
    public interface IAuthService
    {
        public Task<User> login(AuthRequest authRequest);
        void logout();
    }
}

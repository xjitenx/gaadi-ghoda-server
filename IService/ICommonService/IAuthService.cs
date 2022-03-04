using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IService.ICommonService
{
    public interface IAuthService
    {
        public Task<User> validateUserCredentials(AuthRequest authRequest);
        void logout();
    }
}

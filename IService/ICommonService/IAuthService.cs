using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IService.ICommonService
{
    public interface IAuthService
    {
        public bool isValidCredentials(string loginId, string password);
        public Task<User> isValidUserCredentials(AuthRequest authRequest);
        void logout();
    }
}

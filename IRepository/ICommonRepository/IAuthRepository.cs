using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.ICommonRepository
{
    public interface IAuthRepository
    {
        public Task<User> authenticateUserIdPassword(string loginId, string password);
        void logout();
    }
}

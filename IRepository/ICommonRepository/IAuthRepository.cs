using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.ICommonRepository
{
    public interface IAuthRepository
    {
        public Task<User> authenticateLoginId(string loginId);
        public Task<bool> authenticateLoginPassword(Guid orgId, Guid userId, string password);
        void logout();
    }
}

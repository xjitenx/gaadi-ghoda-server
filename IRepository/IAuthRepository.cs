using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository
{
    public interface IAuthRepository
    {
        Task<User> login(string loginId, string password);
        void logout();
    }
}

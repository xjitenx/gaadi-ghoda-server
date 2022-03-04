using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IService.ICommonService
{
    public interface IAccountService
    {
        Task<Account> Get(Guid orgId, Guid accountId);
        Task<List<Account>> Gets(Guid orgId);
        Task<Account> Save(Guid orgId, Account account);
        Task<Account> Update(Guid orgId, Account account);
        Task<int> Delete(Guid orgId, Guid accountId);
    }
}

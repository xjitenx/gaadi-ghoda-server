using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Service.CommonService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository bookieAccountRepository)
        {
            _accountRepository = bookieAccountRepository;
        }

        public async Task<Account> Get(Guid orgId, Guid accountId)
        {
            return await _accountRepository.Get(orgId, accountId);
        }

        public async Task<List<Account>> Gets(Guid orgId)
        {
            return await _accountRepository.Gets(orgId);
        }

        public async Task<Account> Save(Guid orgId, Account account)
        {
            return await _accountRepository.Save(orgId, account);
        }

        public async Task<Account> Update(Guid orgId, Account account)
        {
            return await _accountRepository.Update(orgId, account);
        }

        public async Task<int> Delete(Guid orgId, Guid accountId)
        {
            return await _accountRepository.Delete(orgId, accountId);
        }
    }
}

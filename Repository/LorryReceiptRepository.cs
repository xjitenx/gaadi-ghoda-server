using gaadi_ghoda_server.IRepository;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Repository
{
    public class LorryReceiptRepository : ILorryReceiptRepository
    {
        public Task<LorryReceipt> Save(LorryReceipt lorryReceipt)
        {
            throw new NotImplementedException();
        }

        public Task<LorryReceipt> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LorryReceipt>> Gets()
        {
            throw new NotImplementedException();
        }

        public Task<LorryReceipt> Update(LorryReceipt lorryReceipt)
        {
            throw new NotImplementedException();
        }

        public Task<LorryReceipt> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

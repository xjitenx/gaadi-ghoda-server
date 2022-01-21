using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository
{
    public interface ILorryReceiptRepository
    {
        Task<LorryReceipt> Save(LorryReceipt lorryReceipt);
        Task<LorryReceipt> Get(Guid id);
        Task<List<LorryReceipt>> Gets();
        Task<LorryReceipt> Update(LorryReceipt lorryReceipt);
        Task<LorryReceipt> Delete(Guid id);
    }
}

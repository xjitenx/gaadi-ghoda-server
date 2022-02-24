using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IService.IBookieService
{
    public interface IBookieLorryReceiptService
    {
        Task<LorryReceipt> Get(Guid orgId, Guid bookieId, Guid lorryReceiptId);
        Task<List<LorryReceipt>> Gets(Guid orgId, Guid bookieId);
        Task<LorryReceipt> Save(Guid orgId, Guid bookieId, LorryReceipt lorryReceipt);
        Task<LorryReceipt> Update(Guid orgId, Guid bookieId, LorryReceipt lorryReceipt);
        Task<int> Delete(Guid orgId, Guid bookieId, Guid lorryReceiptId);
    }
}

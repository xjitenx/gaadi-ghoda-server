﻿using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.IBookieRepository
{
    public interface IBookieLorryReceiptRepository
    {
        Task<LorryReceipt> Save(LorryReceipt lorryReceipt);
        Task<LorryReceipt> Get(Guid id);
        Task<List<LorryReceipt>> Gets();
        Task<LorryReceipt> Update(LorryReceipt lorryReceipt);
        Task<int> Delete(Guid id);
    }
}

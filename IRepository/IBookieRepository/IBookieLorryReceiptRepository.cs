﻿using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.IBookieRepository
{
    public interface IBookieLorryReceiptRepository
    {
        Task<LorryReceipt> Get(Guid id, string bookieId);
        Task<List<LorryReceipt>> Gets(string bookieId);
        Task<LorryReceipt> Save(LorryReceipt lorryReceipt, string bookieId);
        Task<LorryReceipt> Update(LorryReceipt lorryReceipt, string bookieId);
        Task<int> Delete(Guid id, string bookieId);
    }
}

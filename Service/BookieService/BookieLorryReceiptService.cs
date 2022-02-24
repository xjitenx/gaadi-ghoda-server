using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.IService.IBookieService;
using gaadi_ghoda_server.IRepository.IBookieRepository;

namespace gaadi_ghoda_server.Service.BookieService
{
    public class BookieLorryReceiptService : IBookieLorryReceiptService
    {
        private readonly IBookieLorryReceiptRepository _bookieLorryReceiptRepository;

        public BookieLorryReceiptService(IBookieLorryReceiptRepository bookieLorryReceiptRepository)
        {
            _bookieLorryReceiptRepository = bookieLorryReceiptRepository;
        }
        public async Task<LorryReceipt> Get(Guid orgId, Guid bookieId, Guid lorryReceiptId)
        {
            return await _bookieLorryReceiptRepository.Get(orgId, bookieId, lorryReceiptId);
        }

        public async Task<List<LorryReceipt>> Gets(Guid orgId, Guid bookieId)
        {
            return await _bookieLorryReceiptRepository.Gets(orgId, bookieId);
        }

        public async Task<LorryReceipt> Save(Guid orgId, Guid bookieId, LorryReceipt lorryReceipt)
        {
            return await _bookieLorryReceiptRepository.Save(orgId, bookieId, lorryReceipt);
        }

        public async Task<LorryReceipt> Update(Guid orgId, Guid bookieId, LorryReceipt lorryReceipt)
        {
            return await _bookieLorryReceiptRepository.Update(orgId, bookieId, lorryReceipt);
        }

        public async Task<int> Delete(Guid orgId, Guid bookieId, Guid lorryReceiptId)
        {
            return await _bookieLorryReceiptRepository.Delete(orgId, bookieId, lorryReceiptId);
        }
    }
}

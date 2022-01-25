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
        public async Task<LorryReceipt> Get(Guid id, string bookieId)
        {
            return await _bookieLorryReceiptRepository.Get(id, bookieId);
        }

        public async Task<List<LorryReceipt>> Gets(string bookieId)
        {
            return await _bookieLorryReceiptRepository.Gets(bookieId);
        }

        public async Task<LorryReceipt> Save(LorryReceipt lorryReceipt, string bookieId)
        {
            return await _bookieLorryReceiptRepository.Save(lorryReceipt, bookieId);
        }

        public async Task<LorryReceipt> Update(LorryReceipt lorryReceipt, string bookieId)
        {
            return await _bookieLorryReceiptRepository.Update(lorryReceipt, bookieId);
        }

        public async Task<int> Delete(Guid id, string bookieId)
        {
            return await _bookieLorryReceiptRepository.Delete(id, bookieId);
        }
    }
}

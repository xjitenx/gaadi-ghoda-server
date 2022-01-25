using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using gaadi_ghoda_server.IService;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.IRepository.IBookieRepository;
using gaadi_ghoda_server.IService.IBookieService;

namespace gaadi_ghoda_server.Service.BookieService
{
    public class BookiePartyService : IBookiePartyService
    {
        private readonly IBookiePartyRepository _bookiePartyRepository;

        public BookiePartyService(IBookiePartyRepository bookiePartyRepository)
        {
            _bookiePartyRepository = bookiePartyRepository;
        }

        public async Task<Party> Get(Guid id, string accountId)
        {
            return await _bookiePartyRepository.Get(id, accountId);
        }

        public async Task<List<Party>> Gets(string accountId)
        {
            return await _bookiePartyRepository.Gets(accountId);
        }

        public async Task<Party> Save(Party party, string accountId)
        {
            return await _bookiePartyRepository.Save(party, accountId);
        }

        public async Task<Party> Update(Party party, string accountId)
        {
            return await _bookiePartyRepository.Update(party, accountId);
        }

        public async Task<int> Delete(Guid id, string accountId)
        {
            return await _bookiePartyRepository.Delete(id, accountId);
        }
    }
}

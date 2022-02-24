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

        public async Task<Party> Get(Guid orgId, Guid bookieId, Guid partyId)
        {
            return await _bookiePartyRepository.Get(orgId, bookieId, partyId);
        }

        public async Task<List<Party>> Gets(Guid orgId, Guid bookieId)
        {
            return await _bookiePartyRepository.Gets(orgId, bookieId);
        }

        public async Task<Party> Save(Guid orgId, Guid bookieId, Party party)
        {
            return await _bookiePartyRepository.Save(orgId, bookieId, party);
        }

        public async Task<Party> Update(Guid orgId, Guid bookieId, Party party)
        {
            return await _bookiePartyRepository.Update(orgId, bookieId, party);
        }

        public async Task<int> Delete(Guid orgId, Guid bookieId, Guid partyId)
        {
            return await _bookiePartyRepository.Delete(orgId, bookieId, partyId);
        }
    }
}

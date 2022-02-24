using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Npgsql;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.IService.IBookieService;
using gaadi_ghoda_server.IRepository.IBookieRepository;

namespace gaadi_ghoda_server.Service.BookieService
{
    public class BookieBrokerService : IBookieBrokerService
    {
        private readonly IBookieBrokerRepository _bookieBrokerRepository;

        public BookieBrokerService(IBookieBrokerRepository bookieBrokerRepository)
        {
            _bookieBrokerRepository = bookieBrokerRepository;
        }

        public Task<Broker> Get(Guid orgId, Guid bookieId, Guid brokerId)
        {
            return _bookieBrokerRepository.Get(orgId, bookieId, brokerId);
        }

        public async Task<List<Broker>> Gets(Guid orgId, Guid bookieId)
        {
            return await _bookieBrokerRepository.Gets(orgId, bookieId);
        }

        public async Task<Broker> Save(Guid orgId, Guid bookieId, Broker broker)
        {
            return await _bookieBrokerRepository.Save(orgId, bookieId, broker);
        }

        public async Task<Broker> Update(Guid orgId, Guid bookieId, Broker broker)
        {
            return await _bookieBrokerRepository.Update(orgId, bookieId, broker);
        }

        public async Task<int> Delete(Guid orgId, Guid bookieId, Guid brokerId)
        {
            return await _bookieBrokerRepository.Delete(orgId, bookieId, brokerId);
        }
    }
}

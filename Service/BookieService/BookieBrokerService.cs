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

        public Task<Broker> Get(Guid id, string bookieId)
        {
            return _bookieBrokerRepository.Get(id, bookieId);
        }

        public async Task<List<Broker>> Gets(string bookieId)
        {
            return await _bookieBrokerRepository.Gets(bookieId);
        }

        public async Task<Broker> Save(Broker broker, string bookieId)
        {
            return await _bookieBrokerRepository.Save(broker, bookieId);
        }

        public async Task<Broker> Update(Broker broker, string bookieId)
        {
            return await _bookieBrokerRepository.Update(broker, bookieId);
        }

        public async Task<int> Delete(Guid id, string bookieId)
        {
            return await _bookieBrokerRepository.Delete(id, bookieId);
        }
    }
}

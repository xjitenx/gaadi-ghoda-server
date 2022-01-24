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

        public Task<Broker> Get(Guid id)
        {
            return _bookieBrokerRepository.Get(id);
        }

        public async Task<List<Broker>> Gets()
        {
            return await _bookieBrokerRepository.Gets();
        }

        public async Task<Broker> Save(Broker broker)
        {
            return await _bookieBrokerRepository.Save(broker);
        }

        public async Task<Broker> Update(Broker broker)
        {
            return await _bookieBrokerRepository.Update(broker);
        }

        public async Task<int> Delete(Guid id)
        {
            return await _bookieBrokerRepository.Delete(id);
        }
    }
}

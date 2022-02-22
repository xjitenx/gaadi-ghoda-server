using Dapper;
using gaadi_ghoda_server.IRepository.IBookieRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using System.Data;

namespace gaadi_ghoda_server.Repository.BookieRepository
{
    public class BookieBrokerRepository : IBookieBrokerRepository
    {
        private readonly string _connectionString;

        public BookieBrokerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GaadiGhodaDb");
        }

        public async Task<Broker> Get(string bookieId, string brokerId)
        {
            Broker _broker = new Broker();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.TblBookieBroker WHERE OrgId=@orgId and BookieId=@bookieId and Id=@id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", brokerId, DbType.Guid, ParameterDirection.Input);
                _broker = await connection.QueryFirstAsync<Broker>(commandText, parameters);

                connection.Close();
            }
            return _broker;
        }

        public async Task<List<Broker>> Gets(string bookieId)
        {
            List<Broker> _brokerList = new List<Broker>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.TblBookieBroker WHERE OrgId=@orgId and BookieId=@bookieId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                _brokerList = (await connection.QueryAsync<Broker>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _brokerList;
        }

        public async Task<Broker> Save(Broker broker, string bookieId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.TblBookieBroker " +
                            "(OrgID, BookieId, FirmName, FirstName, LastName, EmailId, ContactNo, Address, Country, State, City, ZipCode) " +
                            "VALUES " +
                            "(xxORG_ID, xxBOOKIE_ID, @firmName, @firstName, @lastName, @emailId, @contactNo, @address, @country, @state, @city, @zipCode)";
                await connection.ExecuteAsync(commandText, broker);

                connection.Close();
            }
            return broker;
        }

        public Task<Broker> Update(Broker broker, string bookieId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(Guid id, string bookieId)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.TblBookieBroker WHERE OrgId=@OrgId and BookieId=@bookieId and Id=@id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", "xxBOOKIE_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", id, DbType.Guid, ParameterDirection.Input);
                _result = await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return _result;
        }
    }
}

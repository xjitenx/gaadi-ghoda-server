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

        public async Task<Broker> Get(Guid orgId, Guid bookieId, Guid brokerId)
        {
            Broker _broker = new Broker();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_bookie_broker WHERE OrgId=@orgId and BookieId=@bookieId and Id=@id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", brokerId, DbType.Guid, ParameterDirection.Input);
                _broker = await connection.QueryFirstAsync<Broker>(commandText, parameters);

                connection.Close();
            }
            return _broker;
        }

        public async Task<List<Broker>> Gets(Guid orgId, Guid bookieId)
        {
            List<Broker> _brokerList = new List<Broker>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_bookie_broker WHERE OrgId=@orgId and BookieId=@bookieId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                _brokerList = (await connection.QueryAsync<Broker>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _brokerList;
        }

        public async Task<Broker> Save(Guid orgId, Guid bookieId, Broker broker)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.tbl_bookie_broker " +
                            "(OrgID, BookieId, FirmName, FirstName, LastName, EmailId, ContactNo, Address, Country, State, City, ZipCode, Status, CreatedAt) " +
                            "VALUES " +
                            "(@orgId, @bookieId, @firmName, @firstName, @lastName, @emailId, @contactNo, @address, @country, @state, @city, @zipCode, @status, now())";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@firmName", broker.FirmName, DbType.String, ParameterDirection.Input);
                parameters.Add("@firstName", broker.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@lastName", broker.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@emailId", broker.EmailId, DbType.String, ParameterDirection.Input);
                parameters.Add("@contactNo", broker.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@address", broker.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("@country", broker.Country, DbType.String, ParameterDirection.Input);
                parameters.Add("@state", broker.State, DbType.String, ParameterDirection.Input);
                parameters.Add("@city", broker.City, DbType.String, ParameterDirection.Input);
                parameters.Add("@zipCode", broker.ZipCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", broker.Status, DbType.String, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return broker;
        }

        public async Task<Broker> Update(Guid orgId, Guid bookieId, Broker broker)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "UPDATE public.tbl_bookie_broker " +
                            "SET FirmName = @firmName, FirstName = @firstName, LastName = @lastName, EmailId = @emailId, ContactNo = @contactNo, Address = @address, Country = @country, State = @state, City = @city, ZipCode = @zipCode, Status = @status " +
                            "WHERE OrgId = @orgId and BookieId = @bookieId and Id = @brokerId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@brokerId", broker.Id, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@firmName", broker.FirmName, DbType.String, ParameterDirection.Input);
                parameters.Add("@firstName", broker.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@lastName", broker.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@emailId", broker.EmailId, DbType.String, ParameterDirection.Input);
                parameters.Add("@contactNo", broker.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@address", broker.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("@country", broker.Country, DbType.String, ParameterDirection.Input);
                parameters.Add("@state", broker.State, DbType.String, ParameterDirection.Input);
                parameters.Add("@city", broker.City, DbType.String, ParameterDirection.Input);
                parameters.Add("@zipCode", broker.ZipCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", broker.Status, DbType.String, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return broker;
        }

        public async Task<int> Delete(Guid orgId, Guid bookieId, Guid brokerId)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.tbl_bookie_broker WHERE OrgId=@OrgId and BookieId=@bookieId and Id=@id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", brokerId, DbType.Guid, ParameterDirection.Input);
                _result = await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return _result;
        }
    }
}

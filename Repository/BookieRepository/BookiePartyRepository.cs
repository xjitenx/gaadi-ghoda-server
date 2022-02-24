using gaadi_ghoda_server.IRepository.IBookieRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using Dapper;
using System.Data;

namespace gaadi_ghoda_server.Repository.BookieRepository
{
    public class BookiePartyRepository : IBookiePartyRepository
    {
        private readonly string _connectionString;

        public BookiePartyRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GaadiGhodaDb");
        }

        public async Task<Party> Get(Guid orgId, Guid bookieId, Guid partyId)
        {
            Party _party = new Party();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_bookie_party WHERE OrgId=@orgId and BookieId=@bookieId and Id=@id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", partyId, DbType.Guid, ParameterDirection.Input);
                _party = await connection.QueryFirstAsync<Party>(commandText, parameters);

                connection.Close();
            }
            return _party;
        }

        public async Task<List<Party>> Gets(Guid orgId, Guid bookieId)
        {
            List<Party> _partyList = new List<Party>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_bookie_party WHERE OrgId=@orgId and BookieId=@bookieId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                _partyList = (await connection.QueryAsync<Party>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _partyList;
        }

        public async Task<Party> Save(Guid orgId, Guid bookieId, Party party)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.tbl_bookie_party " +
                            "(OrgID, BookieId, FirmName, FirstName, LastName, EmailId, ContactNo, Address, Country, State, City, ZipCode, Status, CreatedAt) " +
                            "VALUES " +
                            "(@orgId, @bookieId, @firmName, @firstName, @lastName, @emailId, @contactNo, @address, @country, @state, @city, @zipCode, @status, now())";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@firmName", party.FirmName, DbType.String, ParameterDirection.Input);
                parameters.Add("@firstName", party.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@lastName", party.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@emailId", party.EmailId, DbType.String, ParameterDirection.Input);
                parameters.Add("@contactNo", party.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@address", party.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("@country", party.Country, DbType.String, ParameterDirection.Input);
                parameters.Add("@state", party.State, DbType.String, ParameterDirection.Input);
                parameters.Add("@city", party.City, DbType.String, ParameterDirection.Input);
                parameters.Add("@zipCode", party.ZipCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", party.Status, DbType.String, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return party;
        }

        public async Task<Party> Update(Guid orgId, Guid bookieId, Party party)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "UPDATE public.tbl_bookie_party " +
                            "SET FirmName = @firmName, FirstName = @firstName, LastName = @lastName, EmailId = @emailId, ContactNo = @contactNo, Address = @address, Country = @country, State = @state, City = @city, ZipCode = @zipCode, Status = @status " +
                            "WHERE OrgId = @orgId and BookieId = @bookieId and Id = @brokerId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@brokerId", party.Id, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@firmName", party.FirmName, DbType.String, ParameterDirection.Input);
                parameters.Add("@firstName", party.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@lastName", party.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@emailId", party.EmailId, DbType.String, ParameterDirection.Input);
                parameters.Add("@contactNo", party.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@address", party.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("@country", party.Country, DbType.String, ParameterDirection.Input);
                parameters.Add("@state", party.State, DbType.String, ParameterDirection.Input);
                parameters.Add("@city", party.City, DbType.String, ParameterDirection.Input);
                parameters.Add("@zipCode", party.ZipCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", party.Status, DbType.String, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return party;
        }

        public async Task<int> Delete(Guid orgId, Guid bookieId, Guid partyId)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.tbl_bookie_party WHERE OrgId=@OrgId and BookieId=@bookieId and Id=@id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", partyId, DbType.Guid, ParameterDirection.Input);
                _result = await connection.ExecuteAsync(commandText, parameters);
                connection.Close();
            }
            return _result;
        }
    }
}

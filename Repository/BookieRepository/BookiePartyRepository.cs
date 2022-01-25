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

        public async Task<Party> Get(Guid id)
        {
            Party _party = new Party();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.TblBookieParty WHERE OrgId=@orgId and BookieId=@bookieId and Id=@id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", "xxBOOKIE_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", id, DbType.Guid, ParameterDirection.Input);
                _party = await connection.QueryFirstAsync<Party>(commandText, parameters);

                connection.Close();
            }
            return _party;
        }

        public async Task<List<Party>> Gets()
        {
            List<Party> _partyList = new List<Party>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.TblBookieParty WHERE OrgId=@orgId and BookieId=@bookieId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", "xxBOOKIE_ID", DbType.Guid, ParameterDirection.Input);
                _partyList = (await connection.QueryAsync<Party>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _partyList;
        }

        public async Task<Party> Save(Party party)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.TblBookieParty " +
                            "(OrgID, BookieId, FirmName, FirstName, LastName, EmailId, ContactNo, Address, Country, State, City, ZipCode) " +
                            "VALUES " +
                            "(xxORG_ID, xxBOOKIE_ID, @firmName, @firstName, @lastName, @emailId, @contactNo, @address, @country, @state, @city, @zipCode)";

                await connection.ExecuteAsync(commandText, party);
                connection.Close();
            }
            return party;
        }

        public Task<Party> Update(Party party)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(Guid id)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.TblBookieParty WHERE OrgId=@OrgId and BookieId=@bookieId and Id=@id";
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

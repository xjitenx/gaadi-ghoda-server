using gaadi_ghoda_server.IRepository.IBookieRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using gaadi_ghoda_server.Models;
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

        public async Task<Party> Save(Party party)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.tbl_bookie_party " +
                            "(org_id, party_name, party_email_id, party_person_first_name ,party_person_last_name, party_contact_no, party_address, party_country, party_state, party_city, party_zip_code) " +
                            "VALUES " +
                            "(@orgId, @partyName, @partyPersonFirstName, @partyPersonLastName, @partyEmailId, @partyContactNo, @partyAddress, @partyCountry, @partyState, @partyCity, @partyZipCode)";

                await connection.ExecuteAsync(commandText, party);
                connection.Close();
            }
            return party;
        }

        public async Task<Party> Get(Guid id)
        {
            Party _party = new Party();
            try
            {
                using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
                {
                    connection.Open();

                    string commandText = "select * from public.tbl_bookie_party where party_id=@partyId";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@partyId", id, DbType.String, ParameterDirection.Input, 64);
                    _party = await connection.QueryFirstOrDefaultAsync<Party>(commandText, parameters);

                    connection.Close();
                }
            }
            catch
            {
                throw;
            }
            return _party;
        }

        public async Task<List<Party>> Gets()
        {
            List<Party> _partyList = new List<Party>();
            try
            {
                using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
                {
                    connection.Open();

                    string commandText = "select * from public.tbl_bookie_party where org_id='" + AppConstants.ORG_ID + "'";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@orgId", "ORG_ID", DbType.String, ParameterDirection.Input, 64);
                    _partyList = await connection.QueryFirstOrDefaultAsync<List<Party>>(commandText, parameters);
                    
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return _partyList;
        }

        public Task<Party> Update(Party party)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

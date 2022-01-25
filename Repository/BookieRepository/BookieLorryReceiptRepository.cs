using Dapper;
using gaadi_ghoda_server.IRepository.IBookieRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using System.Data;

namespace gaadi_ghoda_server.Repository.BookieRepository
{
    public class BookieLorryReceiptRepository : IBookieLorryReceiptRepository
    {
        private readonly string _connectionString;

        public BookieLorryReceiptRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GaadiGhodaDb");
        }

        public async Task<LorryReceipt> Get(Guid id, string bookieId)
        {
            LorryReceipt _lorryReceipt = new LorryReceipt();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.TblBookieLorryReceipt WHERE OrgId=@orgId and BookieId=@bookieId and Id=@id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", "xxBOOKIE_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", id, DbType.Guid, ParameterDirection.Input);
                _lorryReceipt = await connection.QueryFirstAsync<LorryReceipt>(commandText, parameters);

                connection.Close();
            }
            return _lorryReceipt;
        }

        public async Task<List<LorryReceipt>> Gets(string bookieId)
        {
            List<LorryReceipt> _lorryReceiptList = new List<LorryReceipt>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.TblBookieLorryReceipt WHERE OrgId=@orgId and BookieId=@bookieId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", "xxBOOKIE_ID", DbType.Guid, ParameterDirection.Input);
                _lorryReceiptList = (await connection.QueryAsync<LorryReceipt>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _lorryReceiptList;
        }

        public async Task<LorryReceipt> Save(LorryReceipt lorryReceipt, string bookieId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.TblBookieLorryReceipt " +
                            "(OrgId, BookieId, Origin, Destination, Weight, Rate, VehicleNo, PartyId, BrokerId) " +
                            "VALUES " +
                            "(xxORG_ID, xxBOOKIE_ID, @origin, @destination, @weight, @rate, @vehicleNo, @partyId, @brokerId)";
                await connection.ExecuteAsync(commandText, lorryReceipt);
                connection.Close();
            }
            return lorryReceipt;
        }

        public Task<LorryReceipt> Update(LorryReceipt lorryReceipt, string bookieId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(Guid id, string bookieId)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.TblBookieLorryReceipt WHERE OrgId=@OrgId and BookieId=@bookieId and Id=@id";
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

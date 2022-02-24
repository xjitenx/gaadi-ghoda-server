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

        public async Task<LorryReceipt> Get(Guid orgId, Guid bookieId, Guid lorryReceiptId)
        {
            LorryReceipt _lorryReceipt = new LorryReceipt();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_bookie_lorry_receipt WHERE OrgId=@orgId and BookieId=@bookieId and Id=@id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", lorryReceiptId, DbType.Guid, ParameterDirection.Input);
                _lorryReceipt = await connection.QueryFirstAsync<LorryReceipt>(commandText, parameters);

                connection.Close();
            }
            return _lorryReceipt;
        }

        public async Task<List<LorryReceipt>> Gets(Guid orgId, Guid bookieId)
        {
            List<LorryReceipt> _lorryReceiptList = new List<LorryReceipt>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_bookie_lorry_receipt WHERE OrgId=@orgId and BookieId=@bookieId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                _lorryReceiptList = (await connection.QueryAsync<LorryReceipt>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _lorryReceiptList;
        }

        public async Task<LorryReceipt> Save(Guid orgId, Guid bookieId, LorryReceipt lorryReceipt)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.tbl_bookie_lorry_receipt " +
                            "(OrgId, BookieId, Origin, Destination, Weight, Rate, VehicleNo, PartyId, BrokerId, CreatedAt) " +
                            "VALUES " +
                            "(@orgId, @bookieId, @origin, @destination, @weight, @rate, @vehicleNo, @partyId, @brokerId, now())";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@origin", lorryReceipt.Origin, DbType.String, ParameterDirection.Input);
                parameters.Add("@destination", lorryReceipt.Destination, DbType.String, ParameterDirection.Input);
                parameters.Add("@weight", lorryReceipt.Weight, DbType.Double, ParameterDirection.Input);
                parameters.Add("@rate", lorryReceipt.Rate, DbType.Double, ParameterDirection.Input);
                parameters.Add("@vehicleNo", lorryReceipt.VehicleNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@partyId", lorryReceipt.PartyId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@brokerId", lorryReceipt.BrokerId, DbType.Guid, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return lorryReceipt;
        }

        public async Task<LorryReceipt> Update(Guid orgId, Guid bookieId, LorryReceipt lorryReceipt)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "UPDATE public.tbl_bookie_lorry_receipt " +
                            "SET Origin = @origin, Destination = @destination, Weight = @weight, Rate = @rate, VehicleNo = @vehicleNo, PartyId = @partyId, BrokerId = @brokerId " +
                            "WHERE OrgId = @orgId and BookieId = @bookieId and Id = @lorryReceiptId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@lorryReceiptId", lorryReceipt.Id, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@origin", lorryReceipt.Origin, DbType.String, ParameterDirection.Input);
                parameters.Add("@destination", lorryReceipt.Destination, DbType.String, ParameterDirection.Input);
                parameters.Add("@weight", lorryReceipt.Weight, DbType.Double, ParameterDirection.Input);
                parameters.Add("@rate", lorryReceipt.Rate, DbType.Double, ParameterDirection.Input);
                parameters.Add("@vehicleNo", lorryReceipt.VehicleNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@partyId", lorryReceipt.PartyId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@brokerId", lorryReceipt.BrokerId, DbType.Guid, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return lorryReceipt;
        }

        public async Task<int> Delete(Guid orgId, Guid bookieId, Guid lorryReceiptId)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.tbl_bookie_lorry_receipt WHERE OrgId=@OrgId and BookieId=@bookieId and Id=@id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", bookieId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", lorryReceiptId, DbType.Guid, ParameterDirection.Input);
                _result = await connection.ExecuteAsync(commandText, parameters);
                connection.Close();
            }
            return _result;
        }
    }
}

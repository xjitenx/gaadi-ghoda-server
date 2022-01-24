using gaadi_ghoda_server.IRepository.IBookieRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using System.Data;

namespace gaadi_ghoda_server.Repository.BookieRepository
{
    public class BookieLorryReceiptRepository : IBookieLorryReceiptRepository
    {
        public async Task<LorryReceipt> Save(LorryReceipt lorryReceipt)
        {
            try
            {
                using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    using (NpgsqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (NpgsqlCommand command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;

                            command.CommandText = "insert into public.tbl_lorry_receipt" +
                                "(org_id, lorry_receipt_origin, lorry_receipt_destination, lorry_receipt_vehicle_no, lorry_receipt_weight, lorry_receipt_rate, lorry_receipt_party_id, lorry_receipt_broker_id)" +
                                "values " +
                                "(@orgId, @lorryReceiptOrigin, @lorryReceiptDestination, @lorryReceiptVehicleNo, @lorryReceiptWeight, @lorryReceiptRate, @lorryReceiptPartyId, @lorryReceiptBrokerId)";
                            try
                            {
                                command.Parameters.AddWithValue("@orgId", "ORG_ID");
                                command.Parameters.AddWithValue("@lorryReceiptOrigin", lorryReceipt.Origin);
                                command.Parameters.AddWithValue("@lorryReceiptDestination", lorryReceipt.Destination);
                                command.Parameters.AddWithValue("@lorryReceiptVehicleNo", lorryReceipt.VehicleNo);
                                command.Parameters.AddWithValue("@lorryReceiptWeight", lorryReceipt.Weight);
                                command.Parameters.AddWithValue("@lorryReceiptRate", lorryReceipt.Rate);
                                command.Parameters.AddWithValue("@lorryReceiptPartyId", lorryReceipt.PartyId);
                                command.Parameters.AddWithValue("@lorryReceiptBrokerId", lorryReceipt.BrokerId);

                                if (await command.ExecuteNonQueryAsync() != 1)
                                {
                                    throw new InvalidProgramException();
                                }
                                transaction.Commit();
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                connection.Close();
                                throw;
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return lorryReceipt;
        }

        public Task<LorryReceipt> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LorryReceipt>> Gets()
        {
            List<LorryReceipt> lorryReceiptList = new List<LorryReceipt>();
            try
            {
                using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        //use command here
                        command.CommandText = "select * from public.tbl_lorry_receipt where org_id='" + AppConstants.ORG_ID + "'";
                        using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                LorryReceipt lorryReceiptItem = new LorryReceipt();
                                lorryReceiptItem.Id = reader.GetGuid(reader.GetOrdinal("lorry_receipt_id"));
                                lorryReceiptItem.No = reader.GetInt32(reader.GetOrdinal("lorry_receipt_no"));
                                lorryReceiptItem.Origin = reader.GetString(reader.GetOrdinal("lorry_receipt_origin"));
                                lorryReceiptItem.Destination = reader.GetString(reader.GetOrdinal("lorry_receipt_destination"));
                                lorryReceiptItem.VehicleNo = reader.GetString(reader.GetOrdinal("lorry_receipt_vehicle_no"));
                                lorryReceiptItem.Weight = reader.GetDouble(reader.GetOrdinal("lorry_receipt_weight"));
                                lorryReceiptItem.Rate = reader.GetDouble(reader.GetOrdinal("lorry_receipt_rate"));
                                lorryReceiptItem.PartyId = reader.GetGuid(reader.GetOrdinal("lorry_receipt_party_id"));
                                lorryReceiptItem.BrokerId = reader.GetGuid(reader.GetOrdinal("lorry_receipt_broker_id"));
                                lorryReceiptList.Add(lorryReceiptItem);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return lorryReceiptList;
        }

        public Task<LorryReceipt> Update(LorryReceipt lorryReceipt)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

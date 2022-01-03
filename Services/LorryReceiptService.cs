using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Services
{
    public class LorryReceiptService
    {
        public List<LorryReceipt> getLorryReceiptList()
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
                        command.CommandText = "select * from public.tbl_lorry_receipt where org_id=XYZ";
                        using (NpgsqlDataReader reader = command.ExecuteReader())
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
                                lorryReceiptItem.Freight = reader.GetDouble(reader.GetOrdinal("lorry_receipt_freight"));
                                lorryReceiptItem.PartyId = reader.GetGuid(reader.GetOrdinal("lorry_receipt_party_id"));
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

        public int saveLorryReceipt(List<LorryReceipt> lorryReceiptList)
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
                                "(lorry_receipt_origin, lorry_receipt_destination, lorry_receipt_vehicle_no, lorry_receipt_weight, lorry_receipt_rate, lorry_receipt_freight, lorry_receipt_party_id)" +
                                "values " +
                                "(@lorryReceiptOrigin, @lorryReceiptDestination, @lorryReceiptVehicleNo, @lorryReceiptWeight, @lorryReceiptRate, @lorryReceiptFreight, @lorryReceiptPartyId)";
                            try
                            {
                                lorryReceiptList.ForEach((lorryReceipt) =>
                                {
                                    command.Parameters.AddWithValue("@lorryReceiptOrigin", lorryReceipt.Origin);
                                    command.Parameters.AddWithValue("@lorryReceiptDestination", lorryReceipt.Destination);
                                    command.Parameters.AddWithValue("@lorryReceiptVehicleNo", lorryReceipt.VehicleNo);
                                    command.Parameters.AddWithValue("@lorryReceiptWeight", lorryReceipt.Weight);
                                    command.Parameters.AddWithValue("@lorryReceiptRate", lorryReceipt.Rate);
                                    command.Parameters.AddWithValue("@lorryReceiptFreight", lorryReceipt.Freight);
                                    command.Parameters.AddWithValue("@lorryReceiptPartyId", lorryReceipt.PartyId);

                                    if (command.ExecuteNonQuery() != 1)
                                    {
                                        throw new InvalidProgramException();
                                    }
                                });
                                transaction.Commit();
                            }
                            catch(Exception)
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
            return lorryReceiptList.Count;
        }
    }
}

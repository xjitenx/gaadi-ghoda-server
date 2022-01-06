using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Npgsql;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Services
{
    public class BrokerService
    {
        public List<Broker> getBrokerList()
        {
            List<Broker> brokerList = new List<Broker>();
            try
            {
                using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        //use command here
                        command.CommandText = "select * from public.tbl_bookie_broker where org_id='"+ AppConstants.ORG_ID +"'";
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Broker brokerItem = new Broker();
                                brokerItem.Id = reader.GetGuid(reader.GetOrdinal("broker_id"));
                                brokerItem.Name = reader.GetString(reader.GetOrdinal("broker_name"));
                                brokerItem.PersonFirstName = reader.GetString(reader.GetOrdinal("broker_person_first_name"));
                                brokerItem.PersonLastName = reader.GetString(reader.GetOrdinal("broker_person_last_name"));
                                brokerItem.EmailId = reader.GetString(reader.GetOrdinal("broker_email_id"));
                                brokerItem.ContactNo = reader.GetString(reader.GetOrdinal("broker_contact_no"));
                                brokerItem.Address = reader.GetString(reader.GetOrdinal("broker_address"));
                                brokerItem.Country = reader.GetString(reader.GetOrdinal("broker_country"));
                                brokerItem.State = reader.GetString(reader.GetOrdinal("broker_state"));
                                brokerItem.City = reader.GetString(reader.GetOrdinal("broker_city"));
                                brokerItem.ZipCode = reader.GetString(reader.GetOrdinal("broker_zip_code"));
                                brokerList.Add(brokerItem);
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
            return brokerList;
        }

        public void saveBroker(Broker broker)
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

                            command.CommandText = "insert into public.tbl_bookie_broker " +
                                "(org_id, broker_name, broker_email_id, broker_person_first_name ,broker_person_last_name, broker_contact_no, broker_address, broker_country, broker_state, broker_city, broker_zip_code) " +
                                "values " +
                                "(@orgId, @brokerName, @brokerPersonFirstName, @brokerPersonLastName, @brokerEmailId, @brokerContactNo, @brokerAddress, @brokerCountry, @brokerState, @brokerCity, @brokerZipCode)";
                            try
                            {
                                command.Parameters.AddWithValue("@orgId", broker.OrgId);
                                command.Parameters.AddWithValue("@brokerName", broker.Name);
                                command.Parameters.AddWithValue("@brokerPersonFirstName", broker.PersonFirstName);
                                command.Parameters.AddWithValue("@brokerPersonLastName", broker.PersonLastName);
                                command.Parameters.AddWithValue("@brokerEmailId", broker.EmailId);
                                command.Parameters.AddWithValue("@brokerContactNo", broker.ContactNo);
                                command.Parameters.AddWithValue("@brokerAddress", broker.Address);
                                command.Parameters.AddWithValue("@brokerCountry", broker.Country);
                                command.Parameters.AddWithValue("@brokerState", broker.State);
                                command.Parameters.AddWithValue("@brokerCity", broker.City);
                                command.Parameters.AddWithValue("@brokerZipCode", broker.ZipCode);
                                if (command.ExecuteNonQuery() != 1)
                                {
                                    throw new InvalidOperationException();
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
        }
    }
}

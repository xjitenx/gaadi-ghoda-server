using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Npgsql;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Service
{
    public class PartyService
    {
        public List<Party> getPartyList()
        {
            List<Party> partyList = new List<Party>();
            try
            {
                using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        //use command here
                        command.CommandText = "select * from public.tbl_bookie_party where org_id='" + AppConstants.ORG_ID + "'";
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Party partyItem = new Party();
                                partyItem.Id = reader.GetGuid(reader.GetOrdinal("party_id"));
                                partyItem.Name = reader.GetString(reader.GetOrdinal("party_name"));
                                partyItem.PersonFirstName = reader.GetString(reader.GetOrdinal("party_person_first_name"));
                                partyItem.PersonLastName = reader.GetString(reader.GetOrdinal("party_person_last_name"));
                                partyItem.EmailId = reader.GetString(reader.GetOrdinal("party_email_id"));
                                partyItem.ContactNo = reader.GetString(reader.GetOrdinal("party_contact_no"));
                                partyItem.Address = reader.GetString(reader.GetOrdinal("party_address"));
                                partyItem.Country = reader.GetString(reader.GetOrdinal("party_country"));
                                partyItem.State = reader.GetString(reader.GetOrdinal("party_state"));
                                partyItem.City = reader.GetString(reader.GetOrdinal("party_city"));
                                partyItem.ZipCode = reader.GetString(reader.GetOrdinal("party_zip_code"));
                                partyList.Add(partyItem);
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
            return partyList;
        }

        public void saveParty(Party party)
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

                            command.CommandText = "insert into public.tbl_bookie_party " +
                                "(org_id, party_name, party_email_id, party_person_first_name ,party_person_last_name, party_contact_no, party_address, party_country, party_state, party_city, party_zip_code) " +
                                "values " +
                                "(@orgId, @partyName, @partyPersonFirstName, @partyPersonLastName, @partyEmailId, @partyContactNo, @partyAddress, @partyCountry, @partyState, @partyCity, @partyZipCode)";
                            try
                            {
                                command.Parameters.AddWithValue("@orgId", party.OrgId);
                                command.Parameters.AddWithValue("@partyName", party.Name);
                                command.Parameters.AddWithValue("@partyPersonFirstName", party.PersonFirstName);
                                command.Parameters.AddWithValue("@partyPersonLastName", party.PersonLastName);
                                command.Parameters.AddWithValue("@partyEmailId", party.EmailId);
                                command.Parameters.AddWithValue("@partyContactNo", party.ContactNo);
                                command.Parameters.AddWithValue("@partyAddress", party.Address);
                                command.Parameters.AddWithValue("@partyCountry", party.Country);
                                command.Parameters.AddWithValue("@partyState", party.State);
                                command.Parameters.AddWithValue("@partyCity", party.City);
                                command.Parameters.AddWithValue("@partyZipCode", party.ZipCode);
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

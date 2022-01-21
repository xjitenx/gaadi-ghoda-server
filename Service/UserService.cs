using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Service
{
    public class UserService
    {
        public User getUserProfile(Guid userId)
        {
            User userProfile = new User();
            using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
            {
                //use connection here
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    //use command here
                    command.CommandText = "select org_id, user_id, user_first_name, user_last_name, user_email_id, user_contact_no from public.tbl_user where user_id = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userProfile.OrgId = reader.GetGuid(reader.GetOrdinal("org_id"));
                            userProfile.Id = reader.GetGuid(reader.GetOrdinal("user_id"));
                            userProfile.FirstName= reader.GetString(reader.GetOrdinal("user_first_name"));
                            userProfile.LastName = reader.GetString(reader.GetOrdinal("user_last_name"));
                            userProfile.EmailId = reader.GetString(reader.GetOrdinal("user_email_id"));
                            userProfile.ContactNo = reader.GetString(reader.GetOrdinal("user_contact_no"));
                        }
                    }
                }
                connection.Close();
            }
            return userProfile;
        }
    }
}

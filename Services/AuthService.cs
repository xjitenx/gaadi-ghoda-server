using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Services
{
    public class AuthService
    {
        public Boolean loginUser(LoginCredentials loginCredentials)
        {
            int usersFoundCount = 0;
            using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
            {
                //use connection here
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    //use command here
                    command.CommandText = "select count(user_id) as user_count from public.tbl_user where (user_email_id = @userLoginId or user_alias = @userLoginId) and user_password = @userPassword and user_enabled_YN = 'Y'";
                    command.Parameters.AddWithValue("@userLoginId", loginCredentials.LoginId);
                    command.Parameters.AddWithValue("@userPassword", loginCredentials.Password);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usersFoundCount = reader.GetInt32(reader.GetOrdinal("user_count"));
                        }
                    }
                }
                connection.Close();
            }
            return usersFoundCount > 0;
        }
    }
}

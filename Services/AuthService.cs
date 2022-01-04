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
        public LoginResponse loginUser(LoginCredentials loginCredentials)
        {
            LoginResponse loginResponse = new LoginResponse();
            Guid userIdFromDd = Guid.Empty;
            using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
            {
                //use connection here
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    //use command here
                    command.CommandText = "select user_id from public.tbl_user where (user_email_id = @userLoginId or user_alias = @userLoginId) and user_password = @userPassword and user_enabled_YN = 'Y'";
                    command.Parameters.AddWithValue("@userLoginId", loginCredentials.LoginId);
                    command.Parameters.AddWithValue("@userPassword", loginCredentials.Password);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userIdFromDd = reader.GetGuid(reader.GetOrdinal("user_id"));
                        }
                    }
                }
                connection.Close();
            }
            if (userIdFromDd != Guid.Empty)
            {
                loginResponse.UserId = userIdFromDd;
                loginResponse.LoginSuccess = true;
            }
            return loginResponse;
        }
    }
}

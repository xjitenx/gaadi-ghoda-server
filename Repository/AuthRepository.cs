using Npgsql;
using gaadi_ghoda_server.IRepository;
using gaadi_ghoda_server.Models;
using Dapper;
using System.Data;

namespace gaadi_ghoda_server.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string _connectionString;

        public AuthRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GaadiGhodaDb");
        }
        public async Task<User> login(string loginId, string password)
        {
            User _user = new User();
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    //use connection here
                    connection.Open();

                    var CommandText = "select org_id as OrgId, user_id as Id, user_first_name as FirstName, user_last_name as LastName, user_email_id as EmailId, user_contact_no as ContactNo from public.tbl_user where user_email_id = @userLoginId and user_password = @userPassword and user_enabled_YN = 'Y'";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@userLoginId", loginId, DbType.String, ParameterDirection.Input, 64);
                    parameters.Add("@userPassword", password, DbType.String, ParameterDirection.Input, 25);

                    _user = connection.QueryFirstOrDefault<User>(CommandText, parameters);

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw ;
            }
            return _user;
        }

        public void logout()
        {
            throw new NotImplementedException();
        }
    }
}

using Npgsql;
using gaadi_ghoda_server.Models;
using Dapper;
using System.Data;
using gaadi_ghoda_server.IRepository.ICommonRepository;

namespace gaadi_ghoda_server.Repository.CommonRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string _connectionString;

        public AuthRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GaadiGhodaDb");
        }

        public async Task<User> authenticateUserIdPassword(string loginId, string password)
        {
            User _user;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var CommandText = "select OrgId, Id, FirstName, LastName, EmailId, ContactNo, Status from public.tbl_user where EmailId = @userLoginId and password = @userPassword and status = 'Active'";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@userLoginId", loginId, DbType.String, ParameterDirection.Input, 64);
                parameters.Add("@userPassword", password, DbType.String, ParameterDirection.Input, 64);

                _user = await connection.QueryFirstOrDefaultAsync<User>(CommandText, parameters);

                connection.Close();
            }
            return _user;
        }

        public void logout()
        {
            throw new NotImplementedException();
        }
    }
}

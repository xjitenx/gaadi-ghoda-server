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

        public async Task<User> authenticateLoginId(string loginId)
        {
            User _user;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var CommandText = "select OrgId, Id, RoleId, FirstName, LastName, EmailId, ContactNo, Status from public.tbl_user where EmailId = @userLoginId and Status = 'Active'";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@userLoginId", loginId, DbType.String, ParameterDirection.Input, 64);

                _user = await connection.QueryFirstOrDefaultAsync<User>(CommandText, parameters);

                connection.Close();
            }
            return _user;
        }

        public async Task<bool> authenticateLoginPassword(Guid orgId, Guid userId, string password)
        {
            int rowCount = 0;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var commandText = "select COUNT(UserId) from public.tbl_user_sec_pswd where OrgId = @orgId and UserId = @userId and password = @password";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@userId", userId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@password", password, DbType.String, ParameterDirection.Input, 25);

                rowCount = await connection.QueryFirstOrDefaultAsync<int>(commandText, parameters);

                connection.Close();
            }
            return rowCount == 1 ;
        }

        public void logout()
        {
            throw new NotImplementedException();
        }
    }
}

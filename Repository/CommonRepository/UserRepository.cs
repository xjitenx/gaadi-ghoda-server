using Dapper;
using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using System.Data;

namespace gaadi_ghoda_server.Repository.CommonRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GaadiGhodaDb");
        }

        public async Task<User> Get(Guid id)
        {
            User _user = new User();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT *, CASE WHEN t.EnabledYN = 'Y' THEN 'Active' ELSE 'InActive' END AS Status FROM public.TblUser WHERE OrgId=@orgId and Id=@id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", id, DbType.Guid, ParameterDirection.Input);
                _user = await connection.QueryFirstAsync<User>(commandText, parameters);

                connection.Close();
            }
            return _user;
        }

        public async Task<List<User>> Gets()
        {
            List<User> _userList = new List<User>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.TblUser WHERE OrgId=@orgId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                _userList = (await connection.QueryAsync<User>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _userList;
        }

        public async Task<User> Save(User user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.TblUser " +
                            "(OrgID, FirstName, LastName, EmailId, ContactNo, EnabledYN) " +
                            "VALUES " +
                            "(xxORG_ID, @firstName, @lastName, @emailId, @contactNo, 'Y')";

                await connection.ExecuteAsync(commandText, user);
                connection.Close();
            }
            return user;
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(Guid id)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.TblUser WHERE OrgId=@OrgId and BookieId=@bookieId and Id=@id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", "xxORG_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@bookieId", "xxBOOKIE_ID", DbType.Guid, ParameterDirection.Input);
                parameters.Add("@id", id, DbType.Guid, ParameterDirection.Input);
                _result = await connection.ExecuteAsync(commandText, parameters);
                connection.Close();
            }
            return _result;
        }
    }
}

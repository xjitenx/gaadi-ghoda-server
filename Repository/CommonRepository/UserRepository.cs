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

        public async Task<User> Get(Guid orgId, Guid userId)
        {
            User _user = new User();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_user WHERE OrgId=@orgId and Id=@userId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@userId", userId, DbType.Guid, ParameterDirection.Input);
                _user = await connection.QueryFirstAsync<User>(commandText, parameters);

                connection.Close();
            }
            return _user;
        }

        public async Task<List<User>> Gets(Guid orgId)
        {
            List<User> _userList = new List<User>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_user WHERE OrgId=@orgId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                _userList = (await connection.QueryAsync<User>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _userList;
        }

        public async Task<User> Save(Guid orgId, User user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.tbl_user " +
                            "(OrgID, RoleId, FirstName, LastName, EmailId, ContactNo, Status, CreatedAt) " +
                            "VALUES " +
                            "(@orgId, @roleId, @firstName, @lastName, @emailId, @contactNo, @status, now())";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@roleId", user.RoleId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@firstName", user.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@lastName", user.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@emailId", user.EmailId, DbType.String, ParameterDirection.Input);
                parameters.Add("@contactNo", user.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", "Active", DbType.String, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);
                connection.Close();
            }
            return user;
        }

        public async Task<User> Update(Guid orgId, User user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "UPDATE public.tbl_user " +
                            "SET RoleId = @roleId, FirstName = @firstName, LastName = @lastName, EmailId = @emailId, ContactNo = @contactNo, Status = @status " +
                            "WHERE OrgId = @orgId and Id = @userId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@userId", user.Id, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@roleId", user.RoleId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@firstName", user.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@lastName", user.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@emailId", user.EmailId, DbType.String, ParameterDirection.Input);
                parameters.Add("@contactNo", user.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", user.Status, DbType.String, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return user;
        }

        public async Task<int> Delete(Guid orgId, Guid userId)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.tbl_user WHERE OrgId=@OrgId and Id=@userId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@userId", userId, DbType.Guid, ParameterDirection.Input);
                _result = await connection.ExecuteAsync(commandText, parameters);
                connection.Close();
            }
            return _result;
        }
    }
}

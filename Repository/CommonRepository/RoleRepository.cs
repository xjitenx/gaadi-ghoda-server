using Dapper;
using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using System.Data;

namespace gaadi_ghoda_server.Repository.CommonRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connectionString;

        public RoleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GaadiGhodaDb");
        }

        public async Task<Role> Get(Guid orgId, Guid roleId)
        {
            Role _role = new Role();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_user_role WHERE OrgId=@orgId and Id=@roleId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@roleId", roleId, DbType.Guid, ParameterDirection.Input);
                _role = await connection.QueryFirstAsync<Role>(commandText, parameters);

                connection.Close();
            }
            return _role;
        }

        public async Task<List<Role>> Gets(Guid orgId)
        {
            List<Role> _roleList = new List<Role>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_user_role WHERE OrgId = @orgId";

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("orgId", orgId, DbType.Guid, ParameterDirection.Input);

                _roleList = (await connection.QueryAsync<Role>(commandText, dynamicParameters)).ToList();

                connection.Close();
            }
            return _roleList;
        }

        public async Task<Role> Save(Guid orgId, Role role)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.tbl_user_role " +
                            "(OrgID, Name, BookieAccess, BrokerAccess, CreatedAt) " +
                            "VALUES " +
                            "(@orgId, @name, @bookieAccess, @brokerAccess, now())";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@name", role.Name, DbType.String, ParameterDirection.Input);
                parameters.Add("@bookieAccess", role.BookieAccess, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("@brokerAccess", role.BrokerAccess, DbType.Boolean, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return role;
        }

        public async Task<Role> Update(Guid orgId, Role role)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "UPDATE public.tbl_user_role " +
                            "SET Name = @name, BookieAccess = @bookieAccess, BrokerAccess = @brokerAccess " +
                            "WHERE OrgId = @orgId and Id = @roleId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@roleId", role.Id, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@name", role.Name, DbType.String, ParameterDirection.Input);
                parameters.Add("@bookieAccess", role.BookieAccess, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("@brokerAccess", role.BrokerAccess, DbType.Boolean, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return role;
        }

        public async Task<int> Delete(Guid orgId, Guid roleId)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.tbl_user_role WHERE OrgId=@OrgId and Id=@roleId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@roleId", roleId, DbType.Guid, ParameterDirection.Input);
                _result = await connection.ExecuteAsync(commandText, parameters);
                connection.Close();
            }
            return _result;
        }
    }
}

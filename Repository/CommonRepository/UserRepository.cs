using Dapper;
using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using System.Data;

namespace gaadi_ghoda_server.Repository.CommonRepository
{
    public class UserRepository : IUserRepository
    {
        public Task<User> Save(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(Guid id)
        {
            User _user = new User();
            try
            {
                using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
                {
                    connection.Open();

                    var commandText = "select org_id as OrgId, user_id as Id, user_first_name as FirstName, user_last_name as LastName, user_email_id as EmailId, user_contact_no as ContactNo from public.tbl_user where user_id = @userId";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@userId", id, DbType.String, ParameterDirection.Input, 64);
                    _user = await connection.QueryFirstOrDefaultAsync<User>(commandText, parameters);

                    connection.Close();
                }
            }
            catch
            {
                throw;
            }
            return _user;
        }

        public async Task<List<User>> Gets()
        {
            List<User> _user = new List<User>();
            try
            {
                using (var connection = new NpgsqlConnection(AppConstants.CONNECTION_STRING))
                {
                    connection.Open();

                    var commandText = "select org_id as OrgId, user_id as Id, user_first_name as FirstName, user_last_name as LastName, user_email_id as EmailId, user_contact_no as ContactNo from public.tbl_user where org_id = @orgId";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@orgId", "ORG_ID", DbType.String, ParameterDirection.Input, 64);
                    _user = await connection.QueryFirstOrDefaultAsync<List<User>>(commandText, parameters);

                    connection.Close();
                }
            }
            catch
            {
                throw;
            }
            return _user;
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

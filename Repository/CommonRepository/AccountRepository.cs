using Dapper;
using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.Models;
using Npgsql;
using System.Data;

namespace gaadi_ghoda_server.Repository.CommonRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GaadiGhodaDb");
        }

        public async Task<Account> Get(Guid orgId, Guid accountId)
        {
            Account _account = new Account();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_org_account WHERE OrgId=@orgId and Id=@accountId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@accountId", accountId, DbType.Guid, ParameterDirection.Input);
                _account = await connection.QueryFirstAsync<Account>(commandText, parameters);

                connection.Close();
            }
            return _account;
        }

        public async Task<List<Account>> Gets(Guid orgId)
        {
            List<Account> _accountList = new List<Account>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "SELECT * FROM public.tbl_org_account WHERE OrgId=@orgId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                _accountList = (await connection.QueryAsync<Account>(commandText, parameters)).ToList();

                connection.Close();
            }
            return _accountList;
        }

        public async Task<Account> Save(Guid orgId, Account account)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO public.tbl_org_account " +
                            "(OrgID, Type, FirmName, FirstName, LastName, EmailId, ContactNo, Address, City, State, Country, ZipCode, Status, CreatedAt) " +
                            "VALUES " +
                            "(@orgId, @type, @firmName, @firstName, @lastName, @emailId, @contactNo, @address, @city, @state, @country, @zipCode, @status, now())";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@type", account.Type, DbType.String, ParameterDirection.Input);
                parameters.Add("@firmName", account.FirmName, DbType.String, ParameterDirection.Input);
                parameters.Add("@firstName", account.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@lastName", account.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@emailId", account.EmailId, DbType.String, ParameterDirection.Input);
                parameters.Add("@contactNo", account.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@address", account.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("@city", account.City, DbType.String, ParameterDirection.Input);
                parameters.Add("@state", account.State, DbType.String, ParameterDirection.Input);
                parameters.Add("@country", account.Country, DbType.String, ParameterDirection.Input);
                parameters.Add("@zipCode", account.ZipCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", account.Status, DbType.String, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return account;
        }

        public async Task<Account> Update(Guid orgId, Account account)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "UPDATE public.tbl_org_account " +
                            "SET Type = @type, FirmName = @firmName, FirstName = @firstName, LastName = @lastName, EmailId = @emailId, ContactNo = @contactNo, Address = @address, Country = @country, State = @state, City = @city, ZipCode = @zipCode, Status = @status " +
                            "WHERE OrgId = @orgId and Id = @accountId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@accountId", account.Id, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@type", account.Type, DbType.String, ParameterDirection.Input);
                parameters.Add("@firmName", account.FirmName, DbType.String, ParameterDirection.Input);
                parameters.Add("@firstName", account.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@lastName", account.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@emailId", account.EmailId, DbType.String, ParameterDirection.Input);
                parameters.Add("@contactNo", account.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("@address", account.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("@country", account.Country, DbType.String, ParameterDirection.Input);
                parameters.Add("@state", account.State, DbType.String, ParameterDirection.Input);
                parameters.Add("@city", account.City, DbType.String, ParameterDirection.Input);
                parameters.Add("@zipCode", account.ZipCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", account.Status, DbType.String, ParameterDirection.Input);

                await connection.ExecuteAsync(commandText, parameters);

                connection.Close();
            }
            return account;
        }

        public async Task<int> Delete(Guid orgId, Guid accountId)
        {
            int _result;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string commandText = "DELETE FROM public.tbl_org_account WHERE OrgId=@OrgId and Id=@accountId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@orgId", orgId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@accountId", accountId, DbType.Guid, ParameterDirection.Input);
                _result = await connection.ExecuteAsync(commandText, parameters);
                connection.Close();
            }
            return _result;
        }
    }
}

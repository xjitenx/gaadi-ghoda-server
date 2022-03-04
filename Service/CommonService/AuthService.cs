using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Service.CommonService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> validateUserCredentials(AuthRequest authRequest)
        {
            User _user = new User();

            if (string.IsNullOrWhiteSpace(authRequest.LoginId) || string.IsNullOrWhiteSpace(authRequest.Password))
            {
                return _user;
            }

            _user = await _authRepository.authenticateLoginId(authRequest.LoginId);
            if (_user == null || _user.OrgId == Guid.Empty || _user.Id == Guid.Empty)
            {
                return new User();
            }
            
            bool result = await _authRepository.authenticateLoginPassword(_user.OrgId, _user.Id, authRequest.Password);

            return result ? _user : new User();
        }

        public void logout()
        {
            throw new NotImplementedException();
        }
    }
}

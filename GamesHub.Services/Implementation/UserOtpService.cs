using GamesHub.Infrastructure.DapperRepo;
using GamesHub.Infrastructure.IRepo;
using GamesHub.Infrastructure.Repo;
using GamesHub.Model.RequestModel;
using GamesHub.Model.UtilityModel;
using GamesHub.Services.Interface;

namespace GamesHub.Services.Implementation
{
    public class UserOtpService : IUserOtpService
    {
        private readonly IUserDapperRep _userDapperRepo;
        private readonly IUserOtpRepo _userOtpRepo;
        private readonly IJWTManagerRepository _jWTManagerRepository;

        public UserOtpService(IUserDapperRep userDapperRepo, IUserOtpRepo userOtpRepo, IJWTManagerRepository jWTManagerRepository)
        {
            _userDapperRepo = userDapperRepo;
            _userOtpRepo = userOtpRepo;
            _jWTManagerRepository = jWTManagerRepository;
        }

        public Task<int> GetOtp(OtpRequestModel model)
        {
            return _userDapperRepo.SetUserOtp(model);
        }

        public async Task<TokenModel> VerifyOtp(VerifyPassCodeRequestModel model)
        {
            var data = await _userOtpRepo.VerifyOtp(model);
            if (data != null)
            {
                return _jWTManagerRepository.GenerateToken(data);
            }
            return null;
        }
    }
}

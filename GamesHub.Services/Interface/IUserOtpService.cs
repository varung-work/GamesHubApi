using GamesHub.Model.RequestModel;
using GamesHub.Model.UtilityModel;

namespace GamesHub.Services.Interface
{
    public interface IUserOtpService
    {
        Task<int> GetOtp(OtpRequestModel model);
        Task<TokenModel> VerifyOtp(VerifyPassCodeRequestModel model);
    }
}

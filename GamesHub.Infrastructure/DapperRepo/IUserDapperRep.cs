using GamesHub.Model.RequestModel;

namespace GamesHub.Infrastructure.DapperRepo
{
    public interface IUserDapperRep
    {
        Task<int> SetUserOtp(OtpRequestModel model);
    }
}

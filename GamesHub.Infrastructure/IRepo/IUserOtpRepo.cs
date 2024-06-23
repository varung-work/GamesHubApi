using GamesHub.Model.RequestModel;
using GamesHUb.Domain.Entity;

namespace GamesHub.Infrastructure.IRepo
{
    public interface IUserOtpRepo
    {
        Task<User> VerifyOtp(VerifyPassCodeRequestModel model);
    }
}

using GamesHub.Infrastructure.IRepo;
using GamesHub.Model.RequestModel;
using GamesHUb.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GamesHub.Infrastructure.Repo
{
    public class UserOtpRepo : IUserOtpRepo
    {
        private readonly GamesHubContext _context;

        public UserOtpRepo(GamesHubContext context)
        {
            _context = context;
        }

        public async Task<User> VerifyOtp(VerifyPassCodeRequestModel model)
        {
            var data = await _context.UserOtps.Where(x => x.MobileNo == model.MobileNo && x.Otp == model.Otp)
                .Include(x => x.User).FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }
            return data.User;
        }

    }
}

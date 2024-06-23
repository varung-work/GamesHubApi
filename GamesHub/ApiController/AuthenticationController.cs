using GamesHub.Model.RequestModel;
using GamesHub.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GamesHub.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserOtpService _userOtpService;

        public AuthenticationController(IUserOtpService userOtpService)
        {
            _userOtpService = userOtpService;
        }

        [HttpGet("GetPassCode")]
        public async Task<IActionResult> GetPassCode(OtpRequestModel model)
        {
            try
            {
                if (model.MobileNo.ToCharArray().Length==10)
                {
                    return Ok(await _userOtpService.GetOtp(model));
                }
                else
                {
                    return BadRequest("Mobile No should be 10");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("VerifyPassCode")]
        public async Task<IActionResult> VerifyPassCode(string mobileNo, int otp)
        {
            try
            {
                var model = new VerifyPassCodeRequestModel
                {
                    MobileNo= mobileNo,
                    Otp=otp
                };
                var response = await _userOtpService.VerifyOtp(model);
                if(response == null)
                {
                    return Unauthorized("");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}

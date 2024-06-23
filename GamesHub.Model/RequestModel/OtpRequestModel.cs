using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GamesHub.Model.RequestModel
{
    public class OtpRequestModel
    {

        public string MobileNo { get; set; }
        [JsonIgnore]
        public int Otp { get; set; }
    }
}
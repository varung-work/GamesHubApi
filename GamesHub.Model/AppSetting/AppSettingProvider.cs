namespace GamesHub.Model.AppSetting
{
    public static class AppSettingProvider
    {
        public static string SqlConnectionString { get; set; }
        public static Jwt JWT { get; set; }
    }
    public class Jwt
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
        public string TokenValidityInMinutes { get; set; }
        public string RefreshTokenValidityInDays { get; set; }
    }
}

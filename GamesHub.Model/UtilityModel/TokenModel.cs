namespace GamesHub.Model.UtilityModel
{
    public class TokenModel
    {
        public bool IsAuthenticated { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}

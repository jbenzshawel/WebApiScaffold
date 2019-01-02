namespace WebApiScaffold.Core.Settings
{
    public class JwtSettings 
    {
        public string TokenSecret { get; set; }
        public int TokenLifeInMinutes { get; set; }
        public string TokenAudience { get; set; }
        public string TokenIssuer { get; set; }
    }
}
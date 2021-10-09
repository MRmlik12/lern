namespace Lern.Core.Configuration
{
    public class AuthConfiguration : IAuthConfiguration
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
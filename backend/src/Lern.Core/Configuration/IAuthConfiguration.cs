namespace Lern.Core.Configuration
{
    public interface IAuthConfiguration
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
namespace Pokemon.Infrastructure.Configuration
{
    public class ExternalApiConfiguration
    {
        public string ExternalApiBaseUrl { get; }

        public ExternalApiConfiguration(string externalApiBaseUrl)
        {
            ExternalApiBaseUrl = externalApiBaseUrl;
        }
    }
}

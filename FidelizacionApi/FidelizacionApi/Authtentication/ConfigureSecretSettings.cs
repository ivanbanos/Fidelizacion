using Aplicacion.Authtentication;
using Microsoft.Extensions.Options;

namespace Authtentication
{
    public class ConfigureSecretSettings : IConfigureOptions<SecretSettings>
    {
        private IConfiguration _configuration;
        private readonly ILogger<ConfigureSecretSettings> _logger;

        public ConfigureSecretSettings(IConfiguration configuration, ILogger<ConfigureSecretSettings> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public void Configure(SecretSettings options)
        {
            _configuration.Bind("SecretSettings", options);

            if (string.IsNullOrEmpty(options.Secret))
            {
                _logger.LogWarning("Secret is missing");
            }
        }
    }
}

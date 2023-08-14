namespace SingltonApi
{
    public class AppSettings
    {
        private static AppSettings _instance;
        private static readonly object _lock = new object();
        private readonly IConfiguration _configuration;

        public string ApiKey { get; }
        public string ApiUrl { get; }

        private AppSettings()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            ApiKey = _configuration.GetSection("AppSettings:ApiKey").Value;
            ApiUrl = _configuration.GetSection("AppSettings:ApiUrl").Value;
        }

        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppSettings();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}

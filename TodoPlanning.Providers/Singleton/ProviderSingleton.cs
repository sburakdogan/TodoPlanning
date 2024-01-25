namespace TodoPlanning.Providers.Singleton
{
    public class ProviderSingleton
    {
        private static ProviderSingleton instance;

        private string providerName;

        private ProviderSingleton()
        {
        }

        public static ProviderSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProviderSingleton();
                }

                return instance;
            }

        }

        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }
    }
}

namespace TypoEditor
{
    using System.Configuration;

    public class Configuration : IConfiguration
    {
        public string Editor
        {
            get
            {
                return ConfigurationManager.AppSettings["Editor"];
            }
        }
    }
}

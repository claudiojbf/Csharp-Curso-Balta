namespace BlogApi
{
    public class Configuration
    {
        // Token - JWT -Json Web Token 
        //7e7a23fd-74b3-4c16-af7c-532473423c99
        public static string JwtKey { get; set; } = "N2U3YTIzZmQtNzRiMy00YzE2LWFmN2MtNTMyNDczNDIzYzk5";
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "curso_api_IlTevUM/";
        public static SmtpConfiguration Smtp = new();

        public static string localhost;

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}

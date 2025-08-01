using System;

namespace WebApi.Model
{
    public class LoginResult
    {

        /// <summary>
        /// UserName y JwtToken
        /// </summary>
        /// <example>admin</example>
        public string UserName { get; set; }
        public string Token { get; set; }
        public int ExpirationYear { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationDay { get; set; }
        public int ExpirationHour { get; set; }
        public int ExpirationMinute { get; set; }
        public int UniversalCentralTime { get; set; }
        public string TimeSetUTC
        {
            get 
            {
                DateTime d = DateTime.UtcNow.AddHours(UniversalCentralTime);
                return d.ToString();
            }
        }

    }
}

﻿namespace WebApi.Model
{
    public class LoginResult
    {

        /// <summary>
        /// UserName y JwtToken
        /// </summary>
        /// <example>admin</example>
        public string UserName { get; set; }
        public string JwtToken { get; set; }

    }
}

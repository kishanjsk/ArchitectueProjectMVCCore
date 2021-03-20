using Microsoft.AspNetCore.Http;
using System;

namespace Architecture.Utility
{
    public class CustomCookieHandler
    {
        private readonly IHttpContextAccessor _httpContext;
        public CustomCookieHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        /// <summary>  
        /// Get the cookie  
        /// </summary>  
        /// <param name="key">Key </param>  
        /// <returns>string value</returns>  
        public string Get(string key)
        {
            return _httpContext.HttpContext.Request.Cookies[key];
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique identifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void Set(string key, string value, int? expireTime = null)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddYears(1);

            _httpContext.HttpContext.Response.Cookies.Append(key, value, option);
        }
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param> 
        public void Remove(string key)
        {
            _httpContext.HttpContext.Response.Cookies.Delete(key);
        }
    }
}

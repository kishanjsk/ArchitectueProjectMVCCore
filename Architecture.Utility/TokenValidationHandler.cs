using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Architecture.Utility
{

    public class TokenValidationHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        //public IConfigService _config;

        public TokenValidationHandler(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        //public string GetEmail(string token)
        //{
        //    HttpStatusCode statusCode;
        //    //determine whether a jwt exists or not
        //    try
        //    {
        //        ClaimsPrincipal claimsPrincipal = GenerateClaimPrincipal(token);
        //        return (from c in claimsPrincipal.Claims where c.Type == TokenEnum.UserName.ToString() select c.Value).FirstOrDefault();
        //        //var data = claimsPrincipal.Identity.Name;
        //        ////var email = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.UserName.ToString());
        //        //return data;
        //    }
        //    catch (SecurityTokenValidationException e)
        //    {
        //        statusCode = HttpStatusCode.Unauthorized;
        //    }
        //    catch (Exception ex)
        //    {
        //        statusCode = HttpStatusCode.InternalServerError;
        //    }
        //    return null;
        //}
        public string GetValueFromToken(string token, string type)
        {
            HttpStatusCode statusCode;
            //determine whether a jwt exists or not
            try
            {
                ClaimsPrincipal claimsPrincipal = GenerateClaimPrincipal(token);
                return (from c in claimsPrincipal.Claims where c.Type == type select c.Value).FirstOrDefault();
                //var data = claimsPrincipal.Identity.Name;
                ////var email = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.UserName.ToString());
                //return data;
            }
            catch (SecurityTokenValidationException e)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            return null;
        }
        //public string GetUserId(string token)
        //{
        //    HttpStatusCode statusCode;
        //    //determine whether a jwt exists or not
        //    try
        //    {
        //        ClaimsPrincipal claimsPrincipal = GenerateClaimPrincipal(token);
        //        return (from c in claimsPrincipal.Claims where c.Type == TokenEnum.UserId.ToString() select c.Value).FirstOrDefault();

        //    }
        //    catch (SecurityTokenValidationException e)
        //    {
        //        statusCode = HttpStatusCode.Unauthorized;
        //    }
        //    catch (Exception ex)
        //    {
        //        statusCode = HttpStatusCode.InternalServerError;
        //    }
        //    return null;
        //}

        private ClaimsPrincipal GenerateClaimPrincipal(string token)
        {
            var mySecret = _config["Tokens:Key"];
            var mySecurityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(mySecret));

            SecurityToken securityToken;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidAudience = _config["Tokens:Issuer"],
                ValidIssuer = _config["Tokens:Issuer"],
                ValidateLifetime = false,
                ValidateIssuerSigningKey = false,
                LifetimeValidator = LifetimeValidator,
                IssuerSigningKey = mySecurityKey
            };
            //extract and assign the user of the jwt
            ClaimsPrincipal claimsPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
            return claimsPrincipal;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            //determine whether a jwt exists or not
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                var mySecret = _config["Tokens:Key"];
                var mySecurityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(mySecret));

                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = _config["Tokens:Issuer"],
                    ValidIssuer = _config["Tokens:Issuer"],
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    LifetimeValidator = LifetimeValidator,
                    IssuerSigningKey = mySecurityKey
                };
                //extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                var context = _httpContextAccessor.HttpContext;
                context.Response.HttpContext.User = handler.ValidateToken(token, validationParameters, out securityToken);
                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException e)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (!expires.CheckIsNull())
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
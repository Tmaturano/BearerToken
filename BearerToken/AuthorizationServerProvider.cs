using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using System.Security.Principal;

namespace BearerToken
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //check if the token exists in /api/security/token and will check if the token is valid.
            //Each request will hit this point, so will not hit the database, just the token.
            //OAuth control/manage the Token
            context.Validated();
        }


        /// <summary>
        /// Responsible for the authentication
        /// If ValidateClientAuthentication fails (token not valid), this method is called to authenticate the user.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //The origins are external, the * means to allow post, put, get, delete to any origin (urls)
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = context.UserName;
                var password = context.Password;

                //This piece of code can be changed to some user validation.
                if (!user.Equals("thiago") || !password.Equals("thiago"))
                {
                    context.SetError("invalid_grant", "User or Password are invalid");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //this claim can be reached in the controller by User.Identity.Name will return user
                identity.AddClaim(new Claim(ClaimTypes.Name, user));


                var roles = new List<string>();
                roles.Add("Admin");
                roles.Add("User");

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                //principal is the manager of the connection
                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());

                //Without this, the informations would not be accessed from the controller.
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);

            }
            catch (Exception)
            {
                context.SetError("invalid_grant", "Fail on authenticate");                
            }
        }
    }
}
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Configuration;
using TaskService.App_Start;

namespace TaskService
{
    public partial class Startup
    {
        // These values are pulled from web.config
        public static string AadInstance = ConfigurationManager.AppSettings["ida:AadInstance"];
        public static string Tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        public static string ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
        public static string SignUpSignInPolicy = ConfigurationManager.AppSettings["ida:SignUpSignInPolicyId"];
        public static string DefaultPolicy = SignUpSignInPolicy;

        //Tenant1
        public static string AadInstance_tenant1 = ConfigurationManager.AppSettings["ida:AadInstance-tenant1"];
        public static string Tenant_tenant1 = ConfigurationManager.AppSettings["ida:Tenant-tenant1"];
        public static string ClientId_tenant1= ConfigurationManager.AppSettings["ida:ClientId-tenant1"];
        public static string SignUpSignInPolicy_tenant1 = ConfigurationManager.AppSettings["ida:SignUpSignInPolicyId-tenant1"];
        public static string DefaultPolicy_tenant1 = SignUpSignInPolicy_tenant1;

        //Tenant2
        public static string AadInstance_tenant2 = ConfigurationManager.AppSettings["ida:AadInstance-tenant2"];
        public static string Tenant_tenant2 = ConfigurationManager.AppSettings["ida:Tenant-tenant2"];
        public static string ClientId_tenant2 = ConfigurationManager.AppSettings["ida:ClientId-tenant2"];
        public static string SignUpSignInPolicy_tenant2 = ConfigurationManager.AppSettings["ida:SignUpSignInPolicyId-tenant2"];
        public static string DefaultPolicy_tenant2 = SignUpSignInPolicy_tenant2;

        /*
         * Configure the authorization OWIN middleware 
         */
        public void ConfigureAuth(IAppBuilder app)
        {
            //TokenValidationParameters tvps = new TokenValidationParameters
            //{
            //    // Accept only those tokens where the audience of the token is equal to the client ID of this app
            //    ValidAudience = ClientId,
            //    AuthenticationType = Startup.DefaultPolicy
            //};

            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            //{
            //    // This SecurityTokenProvider fetches the Azure AD B2C metadata & signing keys from the OpenIDConnect metadata endpoint
            //    AccessTokenFormat = new JwtFormat(tvps, new OpenIdConnectCachingSecurityTokenProvider(String.Format(AadInstance, Tenant, DefaultPolicy)))

            //});

            TokenValidationParameters tvps_tenant1 = new TokenValidationParameters
            {
                // Accept only those tokens where the audience of the token is equal to the client ID of this app
                ValidAudience = ClientId_tenant1,
                AuthenticationType = Startup.DefaultPolicy_tenant1
            };


            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                // This SecurityTokenProvider fetches the Azure AD B2C metadata & signing keys from the OpenIDConnect metadata endpoint
                AccessTokenFormat = new JwtFormat(tvps_tenant1, new OpenIdConnectCachingSecurityTokenProvider(String.Format(AadInstance_tenant1, Tenant_tenant1, DefaultPolicy_tenant1)))
            });

            //TokenValidationParameters tvps_tenant2 = new TokenValidationParameters
            //{
            //    // Accept only those tokens where the audience of the token is equal to the client ID of this app
            //    ValidAudience = ClientId_tenant2,
            //    AuthenticationType = Startup.DefaultPolicy_tenant2
            //};


            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            //{
            //    // This SecurityTokenProvider fetches the Azure AD B2C metadata & signing keys from the OpenIDConnect metadata endpoint
            //    AccessTokenFormat = new JwtFormat(tvps_tenant2, new OpenIdConnectCachingSecurityTokenProvider(String.Format(AadInstance_tenant2, Tenant_tenant2, DefaultPolicy_tenant2)))
            //});
        }
    }
}

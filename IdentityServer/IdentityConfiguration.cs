using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public class IdentityConfiguration
    {
        #region Old version 3.1.2
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("test_resource", "Resource API")
                {
                    Scopes = {new Scope("userservice") }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
           return new []
            {
                    new Client
                    {
                        ClientId = "xsqqXHqK0A4H7GASezcRdSGMOsgtwLoypI5K5FeUQ8I=",//ClientId ="Test the power of IT" //converter link - Text to encription key
                        ClientName = "Test Client Credentials",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = { new Secret("oj33s0LJZPQujioA+Ik8dg==".Sha256()) },// ClientSecrets = "Test Pvt. Ltd."
                        AllowedScopes = { "userservice"}
                    },
            };


        }
        #endregion
        //Identity server request endpoint  
        //http://localhost:5000/connect/token
        //grant_type:client_credentials
        //client_id:xsqqXHqK0A4H7GASezcRdSGMOsgtwLoypI5K5FeUQ8I=
        //client_secret:oj33s0LJZPQujioA+Ik8dg==
        //scope:userservice
    }
}

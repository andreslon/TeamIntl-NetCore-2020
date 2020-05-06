using System;
using System.Collections.Generic;
using IdentityServer4.Models;
namespace lab.Security
{
    public static class Config
    {

        public static List<ApiResource> Apis => new List<ApiResource>
        {
            new ApiResource("api","api lab")
        };


        public static List<Client> Clients => new List<Client>
        {
            new Client{
                ClientName="WebApp-React",
                ClientId="webapp",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                ClientSecrets= {
                    new Secret("team".Sha256())
                },
                AllowedScopes= { "api" }
            }
        };

    }
}

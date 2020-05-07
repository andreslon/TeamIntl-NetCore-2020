using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Security.Auth
{
    public class ClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            if (clientId == "webapp")
            {
                return Task.FromResult(new Client
                {
                    ClientName = "WebApp-React",
                    ClientId = "webapp",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = {
                    new Secret("team".Sha256())
                },
                    AllowedScopes = { "api" },
                });
            }
            return Task.FromResult(new Client());
        }
    }
}

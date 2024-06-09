using Duende.IdentityServer.Models;
using System.Collections.Generic;

public static class Clients
{
    public static IEnumerable<Client> Get()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "client_id",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("client_secret".Sha256())
                },
                AllowedScopes = { "api1" }
            }
        };
    }
}

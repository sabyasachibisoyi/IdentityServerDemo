// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            //Define device manager api scope
            //Naming
            new List<ApiScope>
            {
                new ApiScope("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {   
                //need to add code for one time access token that the device will provide
                //attach scope with device manager api access
                //check for validity of OTP
                //Connect with SQL Server
                new Client
                {   
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser=true,
                    ClientId = "client",
                    AllowedScopes = { "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    RedirectUris = new []{
                        "https://www.getpostman.com/oauth2/callback"
                    },
                    Enabled = true,
                    ClientUri = null,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }

                    // scopes that client has access to
                    
                }
            };
    }
}
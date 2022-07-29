using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Custumer = "Custumer";


        //Identity Resourse => (Recursos a serem protegidos pelo Identity Server)
        public static IEnumerable<IdentityResource> IdentityResource => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        //APIScope => (Recursos que um Client pode acessar)
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            //Quem?
            new ApiScope("geek_shopping", "GeekShopping Server"),
            //O que faz?
            new ApiScope(name: "read", "Read Data"),
            new ApiScope(name: "write", "Write Data"),
            new ApiScope(name: "delete", "Delete Data"),

        };

        //Client => (Quem vai consumir os recursos)
        public static IEnumerable<Client> Client => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("my_secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read","write","profile" }
            }
        };
    }
}

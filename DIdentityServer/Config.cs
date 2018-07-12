using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace DIdentityServer
{

    /// <summary>
    /// nuget IdentityServer4 
    /// </summary>
    public class Config
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        // client want to access resources (aka scopes)
        /// <summary>
        /// 对于这种情况，客户端将不具有交互式用户，并将使用IdentityServer使用所谓的客户机密码进行身份验证
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    // 没有交互性用户，使用 clientid/secret 实现认证。
                    //AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    // 用于认证的密码
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    // 客户端有权访问的范围（Scopes）
                    AllowedScopes = { "api1" }
                }
            };
        }

        /// <summary>
        /// Define which uses will use this IdentityServer
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestUser> GetUsers()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "10001",
                    Username = "mqkfc123@163.com",
                    Password = "123456"
                } 
            };
        }

    }
}

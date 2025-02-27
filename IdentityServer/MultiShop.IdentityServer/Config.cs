﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        //Standart olarak ApiResources, IdentityResource ve ApiScope türleri tek tek config dosyasına eklenir. ApiResources bölümünde hnagi mikroservislere hangi yetkilerin verildiği tanımlanır. IdentityResource bölümünde token alan kullanıcının o token içinde hangi bilgilere erişebileceği tanımlanır. ApiScope bölümünde ise verilen her bir yetkiye  hangi yetkiye sahip olduğu açıklaması yazılır.
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] //Apiresource çağırıldığı zaman her bir mikroservis için o mikroservise erişim sağlayabilecek bir key belirlenir. Bu şekilde catalog mikroservisi için yetkiler tanımlanır.
        {
            new ApiResource("ResourceCatalog"){ Scopes={"CatalogFullPermission", "CatalogReadPermission"} }, //ResorceCatalog ismindeki key'e sahip olan bir mikroservis kullanıcısı CatalogFullPermission işlemini gerçekleştirebilir. Virgül ile ayrılarak okuma yazma silme gibi işlemlere erişim verebiliriz.
            new ApiResource("ResourceDiscount"){ Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){ Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){ Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){ Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){ Scopes={"CommentFullPermission"}},
            new ApiResource("ResourcePayment"){ Scopes={"PaymentFullPermission"}},
            new ApiResource("ResourceImage"){ Scopes={"ImageFullPermission"}},
            new ApiResource("ResourceOcelot"){ Scopes={"OcelotFullPermission"}},
            new ApiResource("ResourceMessage"){ Scopes={"MessageFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[] //Token alan kullanıcının o token içinde hangi bilgilere erişebileceği burada tanımlanır.
        {
            new IdentityResources.OpenId(), //Herkese açık olan id ye erişebilecek.
            new IdentityResources.Email(),  //Herkese açık olan email bilgisine erişebilecek
            new IdentityResources.Profile() //Herkese açık olan profil bilgisine erişebilecek
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"), //CatalogFullPermission yetkisine sahip bir kullanıcının ne yapabileceğini açıklama olarak yazıyoruz.
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"), //CatalogFullPermission yetkisine sahip kullanıcının okuma yetkisine sahip olduğu açıklaması girilebilir.
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for basket operations"),
            new ApiScope("CommentFullPermission","Full authority for comment operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            new ApiScope("ImageFullPermission","Full authority for image operations"),
            new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[] //Burada da ayrı ayrı istenildiği kadar client oluşturulabilir. Bu clientlar ile hangi tip kullanıcıya hangi yetkilerin verileceği tanımlanır. Örneğin ziyaretçi ise onun görebileceği sayfalar belirlenir.
        {
            //Visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())}, //Burada her bir client için özel bir şifre oluşturulur. Karmaşık şifreler yazılabilir. Sha256 ile şifreliyor.
                AllowedScopes={"CatalogReadPermission", "CatalogFullPermission", "OcelotFullPermission", "CommentFullPermission", "ImageFullPermission", "CommentFullPermission",
                IdentityServerConstants.LocalApi.ScopeName}, //Visitor kullanıcısı sadece catalog okuma yetkisine sahip olsun diye belirtiyoruz.
                AllowAccessTokensViaBrowser = true
            },

            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "BasketFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImageFullPermission","DiscountFullPermission", "OrderFullPermission",  "MessageFullPermission", "CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName, //Manager kullanıcısı için ayrıca scopename, email gibi bilgilere de erişebilmesi sağlanır.
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                }
            },

            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission", "BasketFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImageFullPermission", "CargoFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName, //Admin kullanıcısı için ayrıca scopename, email gibi bilgilere de erişebilmesi sağlanır.
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                    },
                AccessTokenLifetime=600 //Token'ın ömrü burada belirlenebilir. Hiçbir şey yazılmazsa default olarak 3600 sn yapar.
            }
        };
    }
}
# TodoApi Auth AAD

Librerie NuGet
Microsoft.AspNetCore.Authentication.JwtBearer 
Microsoft.AspNetCore.Authentication.OpenIdConnect
Microsoft.Identity.Web

appsettings.json

"AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "qualified.domain.name",
    "TenantId": "22222222-2222-2222-2222-222222222222",
    "ClientId": "11111111-1111-1111-11111111111111111",

    "CallbackPath": "/signin-oidc"
}

Callback PostMan
https://app.getpostman.com/oauth2/callback
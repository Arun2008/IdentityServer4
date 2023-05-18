using IdentityServer;
using IdentityServer4.Services;
using IdentityServer4.Test;

var builder = WebApplication.CreateBuilder(args);

var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddSingleton<ICorsPolicyService>((container) =>
{
    var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
    return new DefaultCorsPolicyService(logger)
    {
        AllowedOrigins = { MyConfig.GetValue<string>("AppSettings:LocalUrl"), MyConfig.GetValue<string>("AppSettings:LiveUrl") }
    };
});

#region old version 3.1.2
builder.Services.AddIdentityServer().AddDeveloperSigningCredential().AddOperationalStore(options =>
            {
                options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 30; // interval in seconds
            })
            .AddInMemoryApiResources(IdentityConfiguration.GetApiResources())
            .AddInMemoryClients(IdentityConfiguration.GetClients());
#endregion

#region New version 4.1.2
//builder.Services.AddIdentityServer()
//    .AddInMemoryClients(IdentityConfiguration.Clients)
//    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
//    .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
//    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
//    .AddTestUsers(new List<TestUser>())
//    .AddDeveloperSigningCredential()
//    .AddOperationalStore(options => {
//        options.EnableTokenCleanup = true;
//        options.TokenCleanupInterval = 30; // interval in seconds
//    });

#endregion



var app = builder.Build();
app.UseCors("AllowAllOrigins");
app.UseIdentityServer();
app.MapGet("/", () => "Identity server started!");
app.Run();

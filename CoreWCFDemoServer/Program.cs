var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

// Configure an explicit none credential type for WSHttpBinding as it defaults to Windows which requires extra configuration in ASP.NET
var myWSHttpBinding = new WSHttpBinding(SecurityMode.Transport);
myWSHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;


app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<EchoService>();
    serviceBuilder.AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService/basichttp");

    // Add a WSHttpBinding with Transport Security for TLS
    serviceBuilder.AddServiceEndpoint<EchoService, IEchoService>(myWSHttpBinding, "/EchoService/WSHttps");


    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpGetEnabled = serviceMetadataBehavior.HttpsGetEnabled = true;
});

app.Run();

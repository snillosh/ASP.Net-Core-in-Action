WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddRazorPages();

WebApplication app = builder.Build();

app.MapGet("/test", () => "Hello world!");
app.MapHealthChecks("/healthz");
app.MapRazorPages();

app.Run();
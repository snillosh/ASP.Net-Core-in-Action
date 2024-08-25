WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddRazorPages();

WebApplication app = builder.Build();

app.MapGet("/product/{name}", (string name) => $"The product is {name}")
    .WithName("product");

app.MapGet("/links", (LinkGenerator links) =>
{
    string link = links.GetPathByName("product",
        new { name = "big-widget" });
    return $"View the product at {link}";
});

app.Run();
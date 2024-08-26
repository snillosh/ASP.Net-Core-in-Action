using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/products/{id}/paged",
    ([FromRoute] int id,
     [FromQuery] int page,
     [FromHeader(Name = "PageSize")] int pageSize)
     => $"Received id {id}, page {page}, pageSize {pageSize}");

app.Run();
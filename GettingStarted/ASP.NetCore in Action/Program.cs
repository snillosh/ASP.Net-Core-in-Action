using System.Diagnostics.CodeAnalysis;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/product/{id}", (ProductId id) => $"Received {id}");
app.Run();

record ProductId(int Id) : IParsable<ProductId>
{
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ProductId result)
    {
        if (s is not null
           && s.StartsWith('p')
           && int.TryParse(
                s.AsSpan().Slice(1),
                out int id))
        {
            result = new ProductId(id);
            return true;
        }

        result = default;
        return false;
    }

    static ProductId IParsable<ProductId>.Parse(string s, IFormatProvider? provider)
    {
        _ = int.TryParse(
                s.AsSpan().Slice(1),
                out int id);

        return new ProductId(id);
    }
}
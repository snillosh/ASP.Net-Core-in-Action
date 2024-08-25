WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/fruit", () => Fruit.All);

var getFruit = (string id) => Fruit.All[id];
app.MapGet("/fruit/{id}", getFruit);

app.MapPost("/fruit/{id}", Handlers.AddFruit);

Handlers handlers = new();
app.MapPut("/fruit/{id}", handlers.ReplaceFruit);

app.MapDelete("/fruit/{id}", DeleteFruit);

app.Run();

void DeleteFruit(string id)
{
    Fruit.All.Remove(id);
}

record Fruit(string Name, int Stock)
{
    public static readonly Dictionary<string, Fruit> All = new();
};

class Handlers
{
    public void ReplaceFruit(string id, Fruit fruit)
    {
        Fruit.All[id] = fruit;
    }

    public static void AddFruit(string id, Fruit fruit)
    {
        Fruit.All.Add(id, fruit);
    }
}
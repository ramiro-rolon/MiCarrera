var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

var productos = new List<Producto>();

// EndPoint para hacer los Get de los productos
app.MapGet("/productos", () => productos);

// EndPoint para hacer los Get de un producto por id
app.MapGet("/productos/{id}", (int id) =>
{
    var producto = productos.FirstOrDefault(p => p.Id == id);
    if (producto == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(producto);
});

// EndPoint para hacer los Post de los productos
app.MapPost("/productos", (Producto producto) =>
{
    producto.Id = productos.Count > 0 ? productos.Max(p => p.Id) + 1 : 1;    
    productos.Add(producto);
    return Results.Created($"/productos/{producto.Id}", producto);
});

// EndPoint para hacer los Put de los productos
app.MapPut("/productos/{id}", (int id, Producto producto) =>
{
    var productoExistente = productos.FirstOrDefault(p => p.Id == id);
    if (productoExistente == null)
    {
        return Results.NotFound();
    }
    productoExistente.Nombre = producto.Nombre;
    productoExistente.Precio = producto.Precio;
    return Results.Ok(productoExistente);
});

// EndPoint para hacer los Patch de los productos
app.MapPatch("/productos/{id}", (int id, Producto productoParcial) =>
{
    var producto = productos.FirstOrDefault(p => p.Id == id);

    if (producto is null)
        return Results.NotFound();

    if (productoParcial.Nombre is not null)
        producto.Nombre = productoParcial.Nombre;

    if (productoParcial.Precio != 0)
        producto.Precio = productoParcial.Precio;

    return Results.Ok(producto);
});


// EndPoint para hacer los Delete de los productos
app.MapDelete("/productos/{id}", (int id) =>
{
    var producto = productos.FirstOrDefault(p => p.Id == id);
    if (producto == null)
    {
        return Results.NotFound();
    }
    productos.Remove(producto);
    return Results.NoContent();
});

app.Run();

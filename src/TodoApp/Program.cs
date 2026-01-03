using TodoApp.Models;
using TodoApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TodoService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();

// Serve static files (wwwroot) and default files like index.html
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/todos", (TodoService s) => Results.Ok(s.GetAll()));
app.MapGet("/todos/{id:int}", (int id, TodoService s) =>
{
    var todo = s.Get(id);
    return todo is not null ? Results.Ok(todo) : Results.NotFound();
});
app.MapPost("/todos", (TodoItem item, TodoService s) =>
{
    var added = s.Add(item);
    return Results.Created($"/todos/{added.Id}", added);
});
app.MapDelete("/todos/{id:int}", (int id, TodoService s) => s.Remove(id) ? Results.NoContent() : Results.NotFound());

// Fallback to index.html for SPA-like behavior
app.MapFallbackToFile("/", "index.html");

app.Run();

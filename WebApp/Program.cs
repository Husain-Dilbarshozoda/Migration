using FluentMigrator.Runner;
using Infastructure.Data;
using Infastructure.Interfaces;
using Infastructure.Migrations;
using Infastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorsService, AuthorsService>();
builder.Services.AddScoped<IDataContaxt, DataContaxt>();



builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ScanIn(typeof(CreateAuthorTable).Assembly).For.Migrations()
        .ScanIn(typeof(CreateBooksTable).Assembly).For.Migrations());




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebApp v1"));
}

using var scope = app.Services.CreateScope();
var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
try
{
    runner.MigrateUp();
}
catch (Exception ex)
{
    Console.WriteLine($"Error applying migrations: {ex.Message}");
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();


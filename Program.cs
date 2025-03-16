using Microsoft.EntityFrameworkCore;
using AddressBookAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext with the SQL Server provider.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add controllers support.
builder.Services.AddControllers();

// Add Swagger for API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

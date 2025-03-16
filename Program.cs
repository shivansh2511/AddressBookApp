using AddressBookAPI.Data;
using AddressBookAPI.ServiceLayer;
using AddressBookAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services
builder.Services.AddScoped<IAddressBookService, AddressBookService>();

// Add FluentValidation
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AddressBookValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

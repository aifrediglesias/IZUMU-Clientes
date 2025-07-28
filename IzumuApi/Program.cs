using IzumuApi.Utils;
using IzumuBussiness.Implementations;
using IzumuBussiness.Interfaces;
using IzumuData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddDbContext<IzumuContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddTransient<ICustomerBussiness, CustomerBussiness>();
builder.Services.AddTransient<IPlanBussiness, PlanBussiness>();
builder.Services.AddTransient<IDocumentTypeBussiness, DocumentTypeBussiness>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDbContext<IzumuContext>(MasterSeed.Seed);

app.Run();

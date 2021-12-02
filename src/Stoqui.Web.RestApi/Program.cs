using Stoqui.Catalog.Infrastructure.IoC;
using Stoqui.Kernel.Infrastructure.IoC;
using Stoqui.Stock.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddKernelConfigure(typeof(Program));
builder.Services.AddCatalogConfigure(builder.Configuration.GetConnectionString("CatalogConnection"));
builder.Services.AddStockConfigure(builder.Configuration.GetConnectionString("StockConnection"));


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

app.Run();

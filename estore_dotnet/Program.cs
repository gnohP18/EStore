using estore_dotnet.Databases;
using estore_dotnet.Models;
using estore_dotnet.Models.Items;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EstoreDatabaseSetting>(
    builder.Configuration.GetSection("EStoreDatabase"));
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IItemModel, ItemModel>();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddSingleton<BaseModel>();
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


using Test3.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.Configure<Mongosettings>(options =>
{
    options.Connection = builder.Configuration.GetSection("MongoSettings:Connection").Value.ToString();
    options.DatabaseName = builder.Configuration.GetSection("MongoSettings:DatabaseName").Value.ToString();
});

builder.Services.AddScoped<IdbContext, dbContext>();
builder.Services.AddScoped<IEmployeesRepositories, EmployeesRepositories>();
builder.Services.AddScoped<ICentresRepositories, CentresRepositories>();





builder.Services.AddControllers();
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

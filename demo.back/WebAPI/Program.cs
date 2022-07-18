using Repository.Interfaces;
using Repository;
using Data;
using Service.Interfaces;
using Service;
using AutoMapper;
using Service.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Setup CORS
var AllowAllOrigins = "_AllowAllOrigins";
builder.Services.AddCors(options => options.AddPolicy(
    name: AllowAllOrigins,
    policy => policy.WithOrigins("*").WithMethods("*").WithHeaders("*"))
);

// Automapper configuration.
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// DB Context configuration.
// Environment.GetEnvironmentVariable("CONNECTION_STRING")
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPwd = Environment.GetEnvironmentVariable("DB_PWD");

builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer($"Initial Catalog={dbName};Data Source={dbServer};Persist Security Info=True;User ID={dbUser};Password={dbPwd}"));

// Add services to the container.
builder.Services.AddTransient<IGenericRepository<Todo>, GenericRespository<Todo>>();
builder.Services.AddTransient<ITodoService, TodoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Todo Database migration
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TodoContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowAllOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

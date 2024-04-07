using AutoMapper;
using Inmobiliaria.Api.Resource;
using Inmobiliaria.Domain.Util.Mapper;
using Inmobiliaria.Infraestructura.Configuration.Contexto;

using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Infraestructura.Configuration.Extension;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SqlConnections");
// Add services to the container.
builder.Services.AddCommonLayer();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationsContext>(x =>
{
    x.UseSqlServer(connectionString);
    x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddTransient<ApplicationsContext>();


var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile<AutoMappingProfile>();
    m.AddProfile<AutoMapperProfile>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

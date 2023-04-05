
using CirqulorBeMongo.Models;
using CirqulorBeMongo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MongoDbGenericRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CirqulorDatabaseSettings>(builder.Configuration.GetSection("CirqulorDatabase"));


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddMongoDbStores<ApplicationUser,ApplicationRole,Guid>
    ("mongodb+srv://cirqulor:sabfqTduXqlVi01n@cirqulor.wckody9.mongodb.net/?retryWrites=true&w=majority", "CirqulorDb")
    .AddDefaultTokenProviders();


builder.Services.AddScoped<BioBasedMaterialService>();
builder.Services.AddScoped<TypeOfMaterialService>();
builder.Services.AddScoped<BaseOfMaterialService>();
builder.Services.AddScoped<NameOfMaterialService>();
builder.Services.AddScoped<SourceOfMaterialService>();
builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<ProductionService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddCors(opt=>opt.AddDefaultPolicy(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();

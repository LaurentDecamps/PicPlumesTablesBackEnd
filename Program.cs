using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityDbContext<User>>()
    .AddDefaultTokenProviders();

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//      c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
// });

// builder.Services

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();



class User : IdentityUser { }

class PicPlumesTablesBackendDbContext : IdentityDbContext<User>
{
    public PicPlumesTablesBackendDbContext(DbContextOptions<PicPlumesTablesBackendDbContext> options) : base(options)
    {
    }
}
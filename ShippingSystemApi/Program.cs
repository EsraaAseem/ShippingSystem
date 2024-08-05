using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShippingSystem.Application.ExtensionService;
using ShippingSystem.Domain.Models;
using ShippingSystem.Domain.Share;
using ShippingSystem.Infrastructure.ExtensionService;
using ShippingSystem.Presentation.MiddleWare;
using ShippingSystem.Presistance.Data;
using ShippingSystem.Presistance.ExtensionService;
using ShippingSystemApi.migratserv;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddControllers();
builder.Services.AddControllers();


builder.Services.AddInfrastructure()
                .AddApplication()
                .AddPresistance(builder.Configuration);

/*builder.Host.UseSerilog((context, configuration) => {
    configuration.ReadFrom.Configuration(context.Configuration);
});
*/
builder
    .Services
    .AddControllers()
    .AddApplicationPart(ShippingSystem.Presentation.ExtensionService.AssemblyReference.Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
}); 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
   {
     o.RequireHttpsMetadata = false;
     o.SaveToken = false;
     o.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
     };
  });
builder.Services.AddScoped<IInlize,Inlize>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.AddGlobalExceptionGlobalHandler();
seedDatabase();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.AddGlobalExceptionGlobalHandler();
app.MapControllers();
var supportedCultures = new[] { "en-US", "ar-EG" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);



seedDatabase();




app.Run();

void seedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
       var DbIntilizer = scope.ServiceProvider.GetRequiredService<IInlize>();
        DbIntilizer.intials();
    }
}
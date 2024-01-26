using System.Text;
using API.Data;
using API.Data.Repositories;
using API.Entities;
using API.Helpers;
using API.Interfaces.IRepositories;
using API.Interfaces.ITokenService;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});








builder.Services.AddControllers()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
           });


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,//server checks token's signing key, and check if its valid
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IToDoSingleEventRepository, ToDoSingleEventRepository>();
builder.Services.AddScoped<ITodoRangedEventRepository, ToDoRangedEventRepository>();



//For database
builder.Services.AddDbContext<TodoDataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//For automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors();

var app = builder.Build();


// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

//app.UseHttpsRedirection();

app.UseCors(pol => pol.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
// app.UseStaticFiles();
// app.UseStaticFiles(new StaticFileOptions()
// {
//     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
//     RequestPath = new PathString("/Resources")
// });



app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<TodoDataContext>();
    await context.Database.MigrateAsync();


    if (!await context.Roles.AnyAsync())
    {
        var role_Guest = new Role() { RoleName = "Guest" };
        var role_Analyst = new Role() { RoleName = "Analyst" };
        var role_Admin = new Role() { RoleName = "Admin" };

        context.Roles.Add(role_Guest);
        context.Roles.Add(role_Analyst);
        context.Roles.Add(role_Admin);
        await context.SaveChangesAsync();
    };


}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during seeding data/migration");
}



app.Run();

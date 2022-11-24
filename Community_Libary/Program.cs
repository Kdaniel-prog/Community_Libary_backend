using Community_Libary.API.BookReviewAPI;
using Community_Libary.API.BooksAPI;
using Community_Libary.API.BorrowedAPI;
using Community_Libary.API.UserReviewsAPI;
using Community_Libary.API.UsersAPI;
using Community_Libary.BL.BookReviewBL;
using Community_Libary.BL.BooksBL;
using Community_Libary.BL.BorrowedBL;
using Community_Libary.BL.UserReviewsBL;
using Community_Libary.BL.UsersBL;
using Community_Libary.DAL.DATA;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Token"])),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddSingleton <JwtAuthenticationManager>();
///

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBookReviewsService, BookReviewsService>();
builder.Services.AddScoped<IBorrowedService, BorrowedService>();
builder.Services.AddScoped<IUserReviewsSerivce, UserReviewsService>();

builder.Services.AddDbContext<Community_LibaryDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Community_LibaryDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();

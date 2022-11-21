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
using Microsoft.EntityFrameworkCore;

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

app.UseAuthorization();
app.UseCors();


app.MapControllers();
app.UseRouting();

app.MapControllers();
app.UseAuthentication();

app.Run();

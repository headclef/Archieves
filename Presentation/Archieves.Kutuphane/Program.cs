using Archieves.Application.Repositories;
using Archieves.Kutuphane.Mapping;
using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Kutuphane.Services.Concretes;
using Archieves.Persistence.Contexts;
using Archieves.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// IConfiguration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

// Add IConfiguration to sservices
builder.Services.AddSingleton<IConfiguration>(configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddRazorRuntimeCompilation();
#region Dependency Injections
builder.Services.AddDbContext<ArchievesDbContext>
    (options => 
    { 
        options.UseSqlServer(configuration.GetConnectionString("VeriTabaniBaglantisi")); 
    });

builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<ISubscriberRepository, SubscriberRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IArchievesService, ArchievesService>();

// AutoMapper
var mapperConfiguration = new MapperConfiguration
    (cfg =>
    {
        cfg.AddProfile<GeneralMapping>();
    });
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion
builder.Services.AddSession();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Archieves/IndexLogIn";
        //options.LogoutPath = "/Login/Logout";
        //options.AccessDeniedPath = "/Login/AccessDenied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Archieves/ErrorPage", $"?statusCode={0}"); // TODO: Hata mekanizmasý olmasý gerektiði gibi çalýþmýyor.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Archieves}/{action=IndexHome}/{id?}");

app.Run();
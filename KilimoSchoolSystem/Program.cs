using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KilimoSchoolSystem.Data;
using KilimoSchoolSystem.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KilimoSchoolSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KilimoSchoolSystemContext") ?? throw new InvalidOperationException("Connection string 'KilimoSchoolSystemContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStreamRepository, StreamRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

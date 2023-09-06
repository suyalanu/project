
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using project.Data;

using Microsoft.Extensions.DependencyInjection;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173/")
            .AllowAnyOrigin().AllowAnyHeader() .AllowAnyMethod(); 
                               
        });
});

//Connection to db
builder.Services.AddDbContext<projectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("projectContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();


//razorruntime
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


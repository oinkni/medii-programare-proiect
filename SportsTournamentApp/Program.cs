using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsTournamentApp.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options => { options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin")); });

// Add services to the container.
builder.Services.AddRazorPages(options => { 
    options.Conventions.AuthorizeFolder("/Matches", "AdminPolicy");
    options.Conventions.AuthorizePage("/Teams/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Teams/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Teams/Delete", "AdminPolicy");

    options.Conventions.AuthorizePage("/Tournaments/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Tournaments/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Tournaments/Delete", "AdminPolicy");

    options.Conventions.AuthorizePage("/Players/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Players/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Players/Delete", "AdminPolicy");
});

builder.Services.AddDbContext<SportsTournamentAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportsTournamentAppContext") ?? throw new InvalidOperationException("Connection string 'SportsTournamentAppContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SportsTournamentAppContext") ?? throw new InvalidOperationException("Connection string 'SportsTournamentAppContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

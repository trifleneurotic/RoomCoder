using Spark.Library.Environment;
using Spark.Library.Config;
using RoomCoder.Application.Startup;
using Vite.AspNetCore.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using RoomCoder.Application.Database;
using System.Diagnostics;

EnvManager.LoadConfig();
// System.IO.Directory.CreateDirectory("/app/Storage/Mail");
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetupSparkConfig();

// Add all services to container.
builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
	// Do something only in dev environments
	app.UseViteDevMiddleware();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Services.RegisterScheduledJobs();
app.Services.RegisterEvents();

app.Run();

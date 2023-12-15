using RoomCoder.Application.Database;
using RoomCoder.Application.Events.Listeners;
using RoomCoder.Application.Models;
using RoomCoder.Application.Services.Auth;
using RoomCoder.Application.Services;
using Spark.Library.Database;
using Spark.Library.Logging;
using Coravel;
using Microsoft.AspNetCore.Components.Authorization;
using Spark.Library.Auth;
using RoomCoder.Application.Jobs;
using Spark.Library.Mail;
using Vite.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using IARRoomCoder.Application.Services;

namespace RoomCoder.Application.Startup;

public static class AppServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddCustomServices();
        services.AddViteServices();
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddDatabase<DatabaseContext>(config);
        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddLogger(config);
        services.AddAuthorization(config, new string[] { CustomRoles.Admin, CustomRoles.User });
        services.AddAuthentication<IAuthValidator>(config);
        services.AddScoped<AuthenticationStateProvider, SparkAuthenticationStateProvider>();
        services.AddJobServices();
        services.AddScheduler();
        services.AddQueue();
        services.AddEventServices();
        services.AddEvents();
        services.AddMailer(config);
        services.AddTransient<DatabaseContext>();

        // remove if in Prod
        services.AddMvc().AddRazorPagesOptions(o =>
        {
            o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
        });

        services.AddScoped<PostFormService>();
        return services;
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        // add custom services
        services.AddScoped<UsersService>();
        services.AddScoped<RolesService>();
		services.AddScoped<IAuthValidator, AuthValidator>();
		services.AddScoped<AuthService>();
        services.AddScoped<RoomCodesService>();
        services.AddScoped<CurrentCodeNumbersService>();
        return services;
    }

    private static IServiceCollection AddEventServices(this IServiceCollection services)
    {
        // add custom events here
        services.AddTransient<EmailNewUser>();
        return services;
    }

    private static IServiceCollection AddJobServices(this IServiceCollection services)
    {
        // add custom background tasks here
        services.AddTransient<ExampleJob>();
        return services;
    }
}

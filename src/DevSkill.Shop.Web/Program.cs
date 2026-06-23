using Autofac;
using Autofac.Extensions.DependencyInjection;
using Cortex.Mediator.DependencyInjection;
using DevSkill.Shop.Application.Features.Teams.Command;
using DevSkill.Shop.Infrastructure.Data;
using DevSkill.Shop.Infrastructure.Extensions;
using DevSkill.Shop.Web;
using Serilog;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/web-log-.log", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);

    #region Serilog Configuration
    builder.Host.UseSerilog((context, configuration) => configuration
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(context.Configuration)
    );
    #endregion

    var connectionString = builder.Configuration.GetConnectionString("db")
        ?? throw new InvalidOperationException("Connection string not found.");
    var migrationAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));

    #region Dependency Injection
    builder.Services.AddInfrastructureDependency();
    #endregion

    #region Autofac based dependency injection
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new WebModule());
    });
    #endregion

    builder.Services.AddCortexMediator(
        new[] { typeof(Program), typeof(TeamAddCommand) },
        option => option.AddDefaultBehaviors()
        );


    #region DbContext Configuration
    builder.Services.AddDbContext(connectionString, migrationAssembly!);
    #endregion

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();
    app.MapStaticAssets();


    app.MapControllerRoute(
        name: "area",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    Log.Information("Application started successfully");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application crashed during startup");
}
finally
{
    Log.CloseAndFlush();
}
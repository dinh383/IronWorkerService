using IronWorkerService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace IronWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Logger configuration! In real scenarios, it is convenient to use the Json approach.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"C:\Temp\Test\IronWorkerService\log.txt")
                .CreateLogger();

            try
            {
                //We don't inject the logger in the main class for this reason,
                //we need to use Singleton Log class
                Log.Information("Starting up the service");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex, "There was a problem starting the service");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService() //We host this worker service on Windows! We need to specify it because a worker service can run in differents S.O's
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>(); //Register Worker as a background service | scope: singleton
                    services.AddSingleton<IEmailService, EmailService>();
                    services.AddSingleton<ISenderService, SenderService>();
                })
                .UseSerilog();
        //we use UserSerilog() to override the Default Configuration (CreateDefaultBuilder)
        //we override the default logger built-in
    }
}

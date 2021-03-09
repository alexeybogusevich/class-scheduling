using KNU.IS.ClassScheduling.Constants;
using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Logic.Configuration;
using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using KNU.IS.ClassScheduling.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var directory = Environment.CurrentDirectory;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile(ConfigurationConstants.ConfigurationFilename)
                .Build();

            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo(ConfigurationConstants.CultureCode);

            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(ConfigurationConstants.DatabaseName))
                .AddScoped<IAlgorithmOutputManager<ScheduledClass>, BaseScheduleOutputManager>()
                .AddScoped<IAlgorithmRunner, GeneticAlgorithmRunner<ScheduledClass>>()
                .AddScoped<IGeneticAlgorithm<ScheduledClass>, SchedulingGeneticAlgorithm>()
                .AddScoped<IScheduleManager, BaseScheduleManager>()
                .Configure<GeneticOptions>(options => configuration.GetSection(nameof(GeneticOptions)).Bind(options))
                .BuildServiceProvider();

            var algorithmRunner = serviceProvider.GetRequiredService<IAlgorithmRunner>();
            await algorithmRunner.RunAsync();
        }
    }
}

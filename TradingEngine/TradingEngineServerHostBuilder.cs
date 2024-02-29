using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TradingEngineServer.Core.Configuration;
/**
 * This file is responsible for actually hosting the server engine that we build.
 * Adds the trading engine server as its hosted service.
 */
namespace TradingEngineServer.core
{
    //public, but nobody can override the contents of this class
    public sealed class TradingEngineServerHostBuilder
    {
        /**
        * Static method to return a host
        * This allows us to create a default builder and access various services
        * Whenever we configure a service, we can take in a context for the service to be built (for the calling thread) (includes appsettings.json and set them in the service), 
        * and have access to various services (hosted service, options, singleton service, etc.)
        */
        public static IHost BuildTradingEngineServer() => Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            //First, inject dependencies from configs
            services.AddOptions();

            //Next, add the TradingServerEngineConfig class
            //.Configure() abstracts the process of reading the configs we want and applying them.
            services.Configure<TradingEngineServerConfiguration>(context.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));

            //Now, we are adding singleton objects.
            //any association with IEngineTradingServer should be done so with a concrete instance of TradingEngineServer.
            services.AddSingleton<ITradingEngineServer, TradingEngineServer>();

            /**
             * Now, we are adding the actual hosted service.
             * TradingEngineServer is the type we want to host. This is what Microsoft's hosting library is going to rely on inheriting from BackgroundService.
             * It registers TradingEngineServer in the app's dependency injection container.
             */
            services.AddHostedService<TradingEngineServer>();
        }).Build();
    }
}

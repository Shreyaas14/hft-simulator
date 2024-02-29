using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

//imports necessary for intellisense
using System;
using System.Threading;
using System.Threading.Tasks;
using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.core
{
    //the class extends the trading engine server interface
    public sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {
        //This instantiates a logger class from Microsoft's logging library.
        private readonly ILogger<TradingEngineServer> _logger;
        private readonly TradingEngineServerConfiguration _tradingEngineServerConfig;
        public TradingEngineServer(ILogger<TradingEngineServer> logger, IOptions<TradingEngineServerConfiguration> config)
        {
            //sets logger to not be null, and throws a null exception if it is.
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            //stores the trading engine server config, and if its null throw an exception, but if not then store it
            _tradingEngineServerConfig = config.Value ?? throw new ArgumentNullException(nameof(config));
        }

        /**
         * this task allows ExecuteAsync to be public, so it can be called out of this class.
         * it's not necessary, because the microsoft library calling ExecuteAsync will call it for us.
         * this is here for added functionality if we want this to perform some specific purpose.
        */
        public Task Run(CancellationToken token) => ExecuteAsync(token);
        /** 
         ExecuteAsync is the key method of BackgroundService. It must be wherever the BackgroundService base class is being used.
        Anytime you use a service/game engine, there's a concept of some server loop. 
        Even if the server doesn't need it, you should have one.
         */
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Started {nameof(TradingEngineServer)}");
            while (!stoppingToken.IsCancellationRequested)
            {
                //instantiates a cancellation token object
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                //cancels the token, returns true for is cancellation requested, ending the while loop
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
            }
            _logger.LogInformation($"Stopped {nameof(TradingEngineServer)}");
            return Task.CompletedTask;
        }
    }
}

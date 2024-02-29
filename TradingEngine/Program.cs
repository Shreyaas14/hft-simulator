using System;

//dependency injection package
using Microsoft.Extensions.DependencyInjection;

//hosting package
using Microsoft.Extensions.Hosting;
using TradingEngineServer.core;
using TradingEngineServer.Core;


//This builds the entire DI container and hosted service.
//The using keyword allows us to dispose of the instance of the object when it is done.
using var engine = TradingEngineServerHostBuilder.BuildTradingEngineServer();

//Now, the engine is of type IHost.
TradingEngineServerServiceProvider.ServiceProvider = engine.Services;
{
    //Now we create scope. This allows us to add scoped services if we ever need to.
    using var scope = TradingEngineServerServiceProvider.ServiceProvider.CreateScope();

    //So, now we run the actual engine.
    await engine.RunAsync().ConfigureAwait(false);
}






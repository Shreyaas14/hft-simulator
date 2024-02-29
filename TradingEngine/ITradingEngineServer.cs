using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.core
{
    //instantiating a public interface for the trading engine server
    public interface ITradingEngineServer
    {
        Task Run(CancellationToken token);
    }
}

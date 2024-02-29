 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.Logging
{
    /**
     * This is our logging interface which overrides the default Microsoft ILogger interface.
     */
    internal interface ILogger
    {
        //module represents where the debug was called from
        //message represents the message
        void Debug(string module, string message);

        /**
         * This call to debug takes in an exception/error.
         * Least derived object--you can pass in any exception and Debug will be able to handle it.
         */
        void Debug(string module, Exception exception);

        void Information(string module, string message);
        void Information(string module, Exception exception);

        void Warning(string module, string message);
        void Warning(string module, Exception exception);

        void Error(string module, string message);
        void Error(string module, Exception exception);
    }
}

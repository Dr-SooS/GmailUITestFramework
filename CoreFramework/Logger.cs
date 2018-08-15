using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework
{
    /// <summary>
    /// NLog.Logger singleton wrapper 
    /// </summary>
    public class Logger
    {
        
        private static NLog.Logger _logger;

        private Logger()
        {
            _logger = NLog.LogManager.GetLogger("GmailtestProgectLogger");
        }
        
        /// <summary>
        /// Returns current instance of logger
        /// </summary>
        /// <returns></returns>
        private static NLog.Logger GetLogger()
        {
            return _logger ?? (_logger = NLog.LogManager.GetCurrentClassLogger());
        }

        /// <summary>
        /// Logs info message
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(string message)
        {
            GetLogger().Info(message);
        }

        /// <summary>
        /// Logs error message
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            GetLogger().Error(message);
        }
    }
}

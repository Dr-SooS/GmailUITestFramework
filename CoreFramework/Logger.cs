using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework
{
    public class Logger
    {
        
        private static NLog.Logger _logger;

        private Logger()
        {
            _logger = NLog.LogManager.GetLogger("GmailtestProgectLogger");
        }
        

        private static NLog.Logger GetLogger()
        {
            return _logger ?? (_logger = NLog.LogManager.GetCurrentClassLogger());
        }

        public static void LogInfo(string message)
        {
            GetLogger().Info(message);
        }

        public static void LogError(string message)
        {
            GetLogger().Error(message);
        }
    }
}

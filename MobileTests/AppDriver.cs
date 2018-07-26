using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace MobileTests
{
    public class AppDriver
    {
        private static IApp _app;
        private static Platform _platform;

        public AppDriver(Platform platform)
        {
            _platform = platform;
        }

        public static IApp App => _app ?? (_app = AppInitializer.StartApp(_platform));
    }
}

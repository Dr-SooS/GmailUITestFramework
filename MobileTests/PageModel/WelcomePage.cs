using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace MobileTests
{
    /// <summary>
    /// POM for welcome page
    /// </summary>
    public class WelcomePage
    {
        private string _nextButtonId = "nextView";

        /// <summary>
        /// Spkipping welcome page
        /// </summary>
        public void SkipWelcomePage()
        {
            AppDriver.App.Tap(c => c.Id(_nextButtonId));
            AppDriver.App.Tap(c => c.Id(_nextButtonId));
            AppDriver.App.Tap(c => c.Id(_nextButtonId));
            AppDriver.App.Tap(c => c.Id(_nextButtonId));
            AppDriver.App.Tap(c => c.Id(_nextButtonId));
        }
    }
}

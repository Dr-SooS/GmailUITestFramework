using CoreFramework.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreFramework
{
    public class BaseTest
    {
        protected static Browser.Browser Browser = CoreFramework.Browser.Browser.Instance; 

        [TestInitialize]
        public virtual void InitTest()
        {
            Browser = CoreFramework.Browser.Browser.Instance;
            CoreFramework.Browser.Browser.WindowMaximize();
            CoreFramework.Browser.Browser.NamvigateTo(Configuration.StartUrl);
        }

        [TestCleanup]
        public virtual void CleanTest()
        {
            CoreFramework.Browser.Browser.Quit();
        }
    }
}

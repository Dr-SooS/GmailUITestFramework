using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GmailUITestFramework.Browser
{
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance; 

        [TestInitialize]
        public virtual void InitTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NamvigateTo(Configuration.StartUrl);
        }

        [TestCleanup]
        public virtual void CleanTest()
        {
            Browser.Quit();
        }
    }
}

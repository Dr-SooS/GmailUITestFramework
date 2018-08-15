using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MobileTests
{
	[TestFixture(Platform.Android)]
	public class Tests
	{
		
		Platform platform;
        public readonly AppDriver AppDriver;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
		    new AppDriver(platform);
		}

        /// <summary>
        /// Verify that welcome page displayed
        /// </summary>
	    [Test]
	    public void WelcomeTextIsDisplayed()
	    {
	        var title = AppDriver.App.Query(c => c.Id("text_title"));
            Assert.AreEqual("Добро пожаловать!", title[0].Text);
	    }

        /// <summary>
        /// Check search
        /// </summary>
        /// <param name="searchProduct"></param>
	    [Test]
        [TestCase("OnePlus 5T")]
	    public void CatalogTest(string searchProduct)
	    {
            new WelcomePage().SkipWelcomePage();
	        var serchResult = new SearchPage()
	            .OpenSearch()
	            .EnterQuery(searchProduct)
	            .OpenFirstResult();
            
	        Assert.IsTrue(serchResult.GetProductTitle().Contains(searchProduct));
	    }
    }
}

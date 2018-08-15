using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace MobileTests
{
    /// <summary>
    /// Pom for product page
    /// </summary>
    public class ProductPage
    {
        private string _productTitleId = "tv_product_title";

        /// <summary>
        /// Gets product title
        /// </summary>
        /// <returns></returns>
        public string GetProductTitle()
        {
            return AppDriver.App.Query(c => c.Id("tv_product_title"))[0].Text;
        }
    }
}

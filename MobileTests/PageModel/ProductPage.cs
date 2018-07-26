using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace MobileTests
{
    public class ProductPage
    {
        private string _productTitleId = "tv_product_title";

        public string GetProductTitle()
        {
            return AppDriver.App.Query(c => c.Id("tv_product_title"))[0].Text;
        }
    }
}

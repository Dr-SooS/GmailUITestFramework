using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace MobileTests
{
    public class SearchPage
    {
        private string _searchButtonId = "menu_search";
        private string _searchFieldId = "search_src_text";
        private string _serchResultId = "view";

        public SearchPage OpenSearch()
        {
            AppDriver.App.Tap(c => c.Id(_searchButtonId));
            return this;
        }

        public SearchPage EnterQuery(string query)
        {
            AppDriver.App.EnterText(c => c.Id(_searchFieldId), query);
            return this;
        }

        public ProductPage OpenFirstResult()
        {
            AppDriver.App.Tap(c => c.Id(_serchResultId));
            return new ProductPage();
        }
    }
}
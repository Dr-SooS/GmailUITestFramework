using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace MobileTests
{
    /// <summary>
    /// Pom for search field and results
    /// </summary>
    public class SearchPage
    {
        private string _searchButtonId = "menu_search";
        private string _searchFieldId = "search_src_text";
        private string _serchResultId = "view";

        /// <summary>
        /// Opens search page
        /// </summary>
        /// <returns></returns>
        public SearchPage OpenSearch()
        {
            AppDriver.App.Tap(c => c.Id(_searchButtonId));
            return this;
        }

        /// <summary>
        /// Enters search query
        /// </summary>
        /// <param name="query">search text</param>
        /// <returns></returns>
        public SearchPage EnterQuery(string query)
        {
            AppDriver.App.EnterText(c => c.Id(_searchFieldId), query);
            return this;
        }

        /// <summary>
        /// opens first search result
        /// </summary>
        /// <returns></returns>
        public ProductPage OpenFirstResult()
        {
            AppDriver.App.Tap(c => c.Id(_serchResultId));
            return new ProductPage();
        }
    }
}
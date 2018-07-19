using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GmailUITestFramework.Browser
{
    public class BaseForm
    {
        protected By IndicatorLocator;

        protected BaseForm(By indicatorLocator)
        {
            IndicatorLocator = indicatorLocator;
        }

        public BaseForm WaitForPageLoaded()
        {
            var label = new BaseElement(IndicatorLocator);
            label.WaitForElementIsVisible();
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.steps.common
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


        [BeforeFeature()]
        [Scope(Tag = "web")]
        public static void SetBrowser()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

    }
}

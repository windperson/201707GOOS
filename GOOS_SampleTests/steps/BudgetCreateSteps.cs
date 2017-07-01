using System;
using FluentAutomation;
using GOOS_SampleTests.PageObjects;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.steps
{
    [Binding]
    [Scope(Feature = "BudgetCreate")]
    public class BudgetCreateSteps : FluentTest
    {
        private BudgetCreatePage _budgetCreatePage;


        public BudgetCreateSteps()
        {
            this._budgetCreatePage = new BudgetCreatePage(this);
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }



        [Given(@"go to adding budget page")]
        public void GivenGoToAddingBudgetPage()
        {
            this._budgetCreatePage.Go();
        }
        
        [Given(@"I add a budget (.*) for ""(.*)""")]
        public void GivenIAddABudgetFor(int amount, string yearMonth)
        {
            this._budgetCreatePage
                .Amount(amount)
                .Month(yearMonth)
                .AddBudget();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"It should dispaly ""(.*)""")]
        public void ThenItShouldDispaly(string message)
        {
            this._budgetCreatePage.ShouldDisplay(message);
        }
    }
}

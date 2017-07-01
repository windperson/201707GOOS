using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_SampleTests.DataModelsForIntegrationTest;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using Budget = GOOS_Sample.Models.DataModels.Budget;

namespace GOOS_SampleTests.steps.common
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public static UnityContainer UnityContainer { get; set; }

        [BeforeTestRun]
        public static void RegisterDIContainer()
        {
            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<IRepository<Budget>, BudgetRepository>();
            UnityContainer.RegisterType<IBudgetService, BudgetService>();
        }

        [BeforeScenario()]
        public void BeforeScenarioCleanTable()
        {
            CleanTableByTags();
        }

        [AfterFeature()]
        public static void AfterFeatureCleanTable()
        {
            CleanTableByTags();
        }


        private static void CleanTableByTags()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags
                .Where(x => x.StartsWith("Clean"))
                .Select(x => x.Replace("Clean", ""));

            if (!tags.Any())
            {
                tags = FeatureContext.Current.FeatureInfo.Tags
                    .Where(x => x.StartsWith("Clean"))
                    .Select(x => x.Replace("Clean", ""));
            }

            using (var dbcontext = new BudgetDBEntitiesForTest())
            {
                foreach (var tag in tags)
                {
                    dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}]");
                }

                dbcontext.SaveChangesAsync();
            }
        }


        [BeforeFeature()]
        [Scope(Tag = "web")]
        public static void SetBrowser()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

    }
}

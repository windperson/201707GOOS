using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOOS_SampleTests.DataModelsForIntegrationTest;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps.common
{
    [Binding]
    public sealed class InsertTable
    {
        [Given(@"Budget table existed budgets")]
        public void GivenBudgetTableExistedBudgets(Table table)
        {
            //same with BudgetCreateSteps
            var budgets = table.CreateSet<Budget>();
            using (var dbcontext = new BudgetDBEntitiesForTest())
            {
                dbcontext.Budgets.AddRange(budgets);
                dbcontext.SaveChanges();
            }
        }
    }
}

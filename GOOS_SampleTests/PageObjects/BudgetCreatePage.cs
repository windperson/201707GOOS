﻿using FluentAutomation;
using GOOS_SampleTests.steps;

namespace GOOS_SampleTests.PageObjects
{
    internal class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        private BudgetCreateSteps budgetCreateSteps;

        public BudgetCreatePage(FluentTest test) : base(test)
        {
        }

        public BudgetCreatePage Amount(int amount)
        {
            throw new System.NotImplementedException();
        }

        public BudgetCreatePage Month(string yearMonth)
        {
            throw new System.NotImplementedException();
        }

        public BudgetCreatePage AddBudget()
        {
            throw new System.NotImplementedException();
        }

        public BudgetCreatePage ShouldDisplay(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
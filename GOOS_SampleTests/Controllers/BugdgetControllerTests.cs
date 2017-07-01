using System;
using System.Text;
using System.Collections.Generic;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using GOOS_Sample.Models;
using GOOS_Sample.Models.DataModels;

namespace GOOS_SampleTests.Controllers
{
    /// <summary>
    /// Summary description for BugdgetControllerTests
    /// </summary>
    [TestClass]
    public class BugdgetControllerTests
    {
        private BudgetController _budgetController;
        private IBudgetService _budgetService = Substitute.For<IBudgetService>();
        private IRepository<Budget> _budgetRepositoryStub;


        [TestMethod()]
        public void AddTest_add_budget_successfully_should_invoke_budgetService_Create_one_time()
        {
            this._budgetController = new BudgetController(_budgetService);
            var model = new BudgetAddViewModel()
                { Amount = 2000, Month = "2017-02" };
            var result = this._budgetController.Add(model);
            _budgetService.Received()
                .Create(Arg.Is<BudgetAddViewModel>(x => x.Amount == 2000 && x.Month == "2017-02"));
        }


        [TestMethod()]
        public void CreateTest_when_exist_record_should_update_budget()
        {
            this._budgetService = new BudgetService(_budgetRepositoryStub);
            var budgetFromDb = new Budget { Amount = 999, YearMonth = "2017-02" };
            _budgetRepositoryStub.Read(Arg.Any<Func<Budget, bool>>())
                .ReturnsForAnyArgs(budgetFromDb);
            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };
            this._budgetService.Create(model);
            _budgetRepositoryStub.Received()
                .Save(Arg.Is<Budget>(x => x == budgetFromDb && x.Amount == 2000));
        }

    }
}

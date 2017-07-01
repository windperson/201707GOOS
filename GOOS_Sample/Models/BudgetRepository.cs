using System;
using System.Linq;
using GOOS_Sample.Models.DataModels;

namespace GOOS_Sample.Models
{
    public class BudgetRepository : IRepository<Budget>
    {
        public Budget Read(Func<Budget, bool> predicate)
        {
            using (var dbcontext = new BudgetDBEntities())
            {
                var firstBudget = dbcontext.Budgets.FirstOrDefault(predicate);
                return firstBudget;
            }
        }

        public void Save(Budget budget)
        {

            using (var dbcontext = new BudgetDBEntities())
            {

                var budgetFromDb = dbcontext.Budgets.FirstOrDefault(x => x.YearMonth == budget.YearMonth);

                if (budgetFromDb == null)
                {
                    dbcontext.Budgets.Add(budget);
                }
                else
                {
                    budgetFromDb.Amount = budget.Amount;
                }

                dbcontext.SaveChanges();
            }
        }

        
    }
}
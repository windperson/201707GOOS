using System;
using GOOS_Sample.Models.DataModels;

namespace GOOS_Sample.Models
{
    public class BudgetRepository : IRepository<Budget>
    {
        public Budget Read(Func<Budget, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Save(Budget budget)
        {

            using (var dbcontext = new BudgetDBEntities())
            {
                dbcontext.Budgets.Add(budget);
                dbcontext.SaveChanges();
            }
        }

        
    }
}
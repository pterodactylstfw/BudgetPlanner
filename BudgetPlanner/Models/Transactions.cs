using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Models
{
    internal class Transactions
    {
        Guid Id { get; set; }
        decimal Amount { get; set; }
        string Description { get; set; }
        DateTime Date {  get; set; }
        Guid CategoryId { get; set; }

    }
}

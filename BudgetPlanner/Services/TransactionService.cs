using BudgetPlanner.Models;



namespace BudgetPlanner.Services
{
    public class TransactionService
    {
        private static readonly List<Category> _mockCategories = new()
        {
            new Category { Id = Guid.NewGuid(), Name = "Mancare", Color = "#FFD700" },
            new Category { Id = Guid.NewGuid(), Name = "Transport", Color = "#4682B4" },
            new Category { Id = Guid.NewGuid(), Name = "Salariu", Color = "#32CD32" }
        };


        public List<Transaction> GetTransactions()
        {

            Guid foodCategoryId = _mockCategories.First(c => c.Name == "Mancare").Id;
            Guid transportCategoryId = _mockCategories.First(c => c.Name == "Transport").Id;
            Guid salaryCategoryId = _mockCategories.First(c => c.Name == "Salariu").Id;
            
            return new List<Transaction>
            {
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = 1200, // Venit
                    Description = "Salariu Septembrie",
                    Date = new DateTime(2025, 9, 5),
                    CategoryId = salaryCategoryId
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = -45.50m, // Cheltuială
                    Description = "Prânz la cantină",
                    Date = new DateTime(2025, 9, 6),
                    CategoryId = foodCategoryId 
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = -80,
                    Description = "Abonament STB",
                    Date = new DateTime(2025, 9, 7),
                    CategoryId = transportCategoryId 
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = -150.75m,
                    Description = "Cumpărături supermarket",
                    Date = new DateTime(2025, 9, 8),
                    CategoryId = foodCategoryId 
                }
            };
        }
    }
}
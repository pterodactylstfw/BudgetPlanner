namespace BudgetPlanner;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent(); 
        Routing.RegisterRoute("DashboardPage", typeof(DashboardPage));
        Routing.RegisterRoute("TransactionsPage", typeof(TransactionsPage));
    }
}
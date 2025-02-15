public class ATM
{
    private int _id;
    private string _location;
    private bool _isAvailable;

    public decimal CashAvailable { get; set; }
    public decimal MaxWithdrawalLimit {  get; private set; }
    public decimal MinWithdrawalLimit { get; private set; }

    public ATM(int id, string location, decimal cashAvailable = 10000, decimal maxWithdrawalLimit = 100000, decimal minWithdrawalLimit = 1, bool isAvailable = true)
    {
        _id = id;
        _location = location;
        CashAvailable = cashAvailable;
        MaxWithdrawalLimit = maxWithdrawalLimit;
        MinWithdrawalLimit = minWithdrawalLimit;
        _isAvailable = isAvailable;
    }

    public void ShowAtmStartMenu()
    {
        Console.Clear();
        StartMenu.ShowTitle("   X ATM Bank \n");

        Console.WriteLine("\n[1] Deposit\n");
        Console.WriteLine("[2] Withdraw\n");
        Console.WriteLine("[3] Balance INQ.\n");
        Console.WriteLine("[4] Change PIN\n");
        Console.WriteLine("[5] Exit\n");

        Console.WriteLine("----------------------------------------");
    }

    public static void GoToOperationMenu(User user)
    {
        string choice = user.UserChoice("Enter your choice");
        user.OperationHandle(choice);
    }

}
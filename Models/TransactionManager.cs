public class TransactionManager
{
    private User _user;
    private ATM atm;
    private StartMenu StartMenu;
    public ATM Atm { get => atm; set => atm = value; }
    

    public TransactionManager() { }
    public TransactionManager(User user)
    {
        Atm = new ATM(732837483, "Egypt", 90000000000m, 10000000m, 2m, true);
        Atm.ShowAtmStartMenu();
        _user = user;
    }


    public void HandleDeposit()
    {
        Console.Clear();
        StartMenu.ShowTitle("  Deposit Money");
        Console.Write("Enter the amount in dollars you want to deposit: ");
        try
        {
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            _user.Balance += amount;

            Report.ReportSuccess(TransactionType.DEPOSIT, _user);

            string ch = _user.UserChoice("Press any key to go back");
            Atm.ShowAtmStartMenu();
            ATM.GoToOperationMenu(_user);
        }
        catch (Exception ex)
        {
            Report.ReportError(TransactionType.DEPOSIT, "1", _user);
        }
    }
    public void HandleWithdrawal()
    {
        Console.Clear();
        StartMenu.ShowTitle("  Withdraw Money");
        Console.Write("\nEnter the amount in dollars you want to withdraw: ");

        try
        {
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            short status = WithdrawalStatus(amount);

            if (status < 1)
            {
                StartMenu.ShowError("\nOperation Failed. Please wait while we redirect you back.\n");
                System.Threading.Thread.Sleep(3000);
                Atm.ShowAtmStartMenu();
                ATM.GoToOperationMenu(_user);
            }

            else
            {
                _user.Balance -= amount;
                Atm.CashAvailable -= amount;

                Report.ReportSuccess(TransactionType.WITHDRAW, _user);

                string ch = _user.UserChoice("Press any key to go back");
                Atm.ShowAtmStartMenu();
                ATM.GoToOperationMenu(_user);
            }
        } 
        catch (Exception ex)
        {
            Report.ReportError(TransactionType.WITHDRAW, "2", _user);
        }
    }
    public void HandleBalanceINQ()
    {
        Console.Clear();
        StartMenu.ShowTitle("  Balance INQ.");
        Console.Write($"\nYour current balance : ${_user.Balance}\n\n");
        Console.WriteLine("------------------------------------------------------\n\n");
        string ch = _user.UserChoice("Press any key to go back");
        Atm.ShowAtmStartMenu();
        ATM.GoToOperationMenu(_user);
    }
    public void HandleChangePin()
    {
        Console.Clear();
        StartMenu.ShowTitle("  Balance INQ.");
        StartMenu = new StartMenu();
        Console.Write("Please enter your new pin: ");
        string newPin = StartMenu.InputPin();


        if (StartMenu.IsValidPin(newPin))
        {
            Console.WriteLine($"\n\nThe pin you entered is: {newPin}");
            string ch = _user.UserChoice("\n\nPress [Y] if this pin is not the pin you wanted , Press [N] if you want to continue");
            if (ch.ToLower() == "y")
            {
                Console.Clear();
                Atm.ShowAtmStartMenu();
                ATM.GoToOperationMenu(_user);
            }

            else if (ch.ToLower() == "n") {
                Console.Write("\n\nPlease re enter your new pin: ");
                string reEnterPin = StartMenu.InputPin();
                bool equality = validatePinEquality(newPin, reEnterPin);
                if (equality)
                {
                    Console.Write($"\n\nPin Changed Successfully From {_user.Pin} To ");
                    _user.Pin = newPin;
                    Console.Write($"{_user.Pin}\n\n");
                    Console.WriteLine("Redirecting You Back To Menu");
                    System.Threading.Thread.Sleep(8500);
                    Atm.ShowAtmStartMenu();
                    ATM.GoToOperationMenu(_user);
                }
                else
                {
                    StartMenu.ShowError("\n\nThe pins doesnt match! Redirecting you back to menu");
                    System.Threading.Thread.Sleep(2500);
                    Atm.ShowAtmStartMenu();
                    ATM.GoToOperationMenu(_user);
                }
            }
            else
            {
                StartMenu.ShowError("\n\nThe character is invalid");
                System.Threading.Thread.Sleep(1000);
                HandleChangePin();
            }
        }
        else
        {
            Console.WriteLine("\nPin must be exactly 4 digits and numbers only.\n");
            Console.WriteLine("Redirecting you back\n");
            System.Threading.Thread.Sleep(2000);
            Atm.ShowAtmStartMenu();
            ATM.GoToOperationMenu(_user);
        }

    }
    public void HandleExit()
    {
        Console.Clear();
        StartMenu.ShowTitle("TRANSACTION HISTORY");
        if(_user.TransactionHistory.Count == 0)
            Console.WriteLine("No Recent Transactions.");
        else
        {
            foreach (Transaction transaction in _user.TransactionHistory)
            {
                Console.WriteLine("\n------------------------------------------------\n");
                Console.WriteLine(transaction);
                Console.WriteLine("\n------------------------------------------------");
            }
        }
        
    }

 

   
    private short WithdrawalStatus(decimal amount)
    {
        if (amount > Atm.CashAvailable)
            return -1;

        if(amount > Atm.MaxWithdrawalLimit || amount < Atm.MinWithdrawalLimit)
            return 0;

        if (_user.Balance < amount)
            return -2;

        return 1;
    }
    private bool validatePinEquality(string pin1, string pin2)
    {
        if(pin1 is null || pin2 is null) return false;
        return pin1.Equals(pin2);
    }

}

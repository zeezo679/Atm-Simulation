public class Report
{
    public static void ReportError(TransactionType type, string operationNumber, User _user)
    {
        _user.Transaction = new Transaction(_user.CardNum, _user.Pin, _user.Id, type, DateTime.Now, TransactionStatus.FAIL);
        Console.WriteLine("\n====================================\n");
        Console.WriteLine(_user.Transaction);
        Console.WriteLine("\n====================================\n\n");
        Console.WriteLine("Please Wait Before Trying Again!");
        System.Threading.Thread.Sleep(5000);
        _user.OperationHandle(operationNumber);
    }

    public static void ReportSuccess(TransactionType type, User _user)
    {
        Console.WriteLine("\n\tTransaction done Successfully!");
        Console.WriteLine($"\n\tCurrent Balance: ${_user.Balance}");

        _user.Transaction = new Transaction(_user.CardNum, _user.Pin, _user.Id, type, DateTime.Now, TransactionStatus.SUCCESS);
        _user.TransactionHistory.Add(_user.Transaction);

        Console.WriteLine("\n====================================\n");
        Console.WriteLine(_user.Transaction);
        Console.WriteLine("\n====================================\n");
    }
}



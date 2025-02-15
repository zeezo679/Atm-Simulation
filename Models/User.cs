using System.ComponentModel.DataAnnotations;
using System.Transactions;

public class User
{
    private const int _maxChoice = 6;
    private int _id;
    private string _cardNum;
    private string _pin;
    private decimal _balance;
    private Transaction transaction;
    private List<Transaction> transactionHistory;

    public static int MaxChoice => _maxChoice;
    public int Id { get => _id; private set => _id = value; }
    public string CardNum { get => _cardNum; private set => _cardNum = value; }
    public string Pin { get => _pin; set => _pin = value; }
    public decimal Balance { get => _balance; set => _balance = value; }
    public Transaction Transaction { get => transaction; set => transaction = value; }
    public List<Transaction> TransactionHistory { get => transactionHistory; set => transactionHistory = value; }
    public TransactionManager tm;

    public User(string cardNum, string pin)
    {
     
        tm = new TransactionManager(this);
        TransactionHistory = new List<Transaction>();
        Id = DateTime.Now.Millisecond*2;
        CardNum = cardNum;
        Pin = pin;
    }


    public void OperationHandle(string choice)
    {
        int ParsedChoice = GetValidChoice(choice);
        switch (ParsedChoice)
        {
            case 1:
                tm.HandleDeposit();
                break;
            case 2:
                tm.HandleWithdrawal();
                break;
            case 3: 
                tm.HandleBalanceINQ();
                break;
            case 4:
                tm.HandleChangePin();
                break;
            case 5:
                tm.HandleExit();
                break;
        }
    }
    public  string UserChoice(string choiceMessage)
    {
        Console.Write(choiceMessage);
        var choice = Console.ReadKey(true).KeyChar;
        return choice.ToString();
    }
    private int GetValidChoice(string choice)
    {
        int ParsedChoice;
        while (!int.TryParse(choice, out ParsedChoice) || ParsedChoice > 5 || ParsedChoice < 1)
        {
            Console.WriteLine("\nThe choice you entered is invalid!");
            Console.WriteLine("--------------------------------------------\n");
            choice = UserChoice("Enter your choice: ");
        }
        return ParsedChoice;
    }

}

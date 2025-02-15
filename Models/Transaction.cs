using System.Diagnostics.Metrics;
using System.Text;
public class Transaction
{
    private static int cnt = 0;
    private long _transactionID;
    private string _userCardNo;
    private string _userPin;
    private int _userID;
    private TransactionType _transactionType;
    private TransactionStatus _status;

    public DateTime _transactionDate;



    public Transaction(string cardNo, string pin, int id, TransactionType type, DateTime date, TransactionStatus status)
    {
        _transactionID = DateTime.Now.Millisecond;
        _userCardNo = cardNo;
        _userPin = pin;
        _userID = id;
        _transactionType = type;
        _transactionDate = date;
        _status = status;
    }

    public override string ToString()
    {
        return $"Transaction ID - {_transactionID}\n\nTransaction Type - {_transactionType}\n\nCard Number - {_userCardNo}\n\nUser ID - {_userID}\n\nDate - {_transactionDate}\n\nStatus - {_status.ToString()}";
    }
}
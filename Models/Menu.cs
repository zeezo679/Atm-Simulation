using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

public class StartMenu
{
    private const int PinLength = 4;
    private const int CardNoLength = 8;
    public string CardNo { get; set; }
    public string Pin {  get; set; }
    public bool ShowNext { get; set; }
    public void ShowLoginMenu()
    {
        Console.CursorVisible = false;

        ShowTitle("   X ATM Bank ");
        do
        {
            Console.Write("\nEnter your CARD no: ");

            var cardNo = Console.ReadLine();
            CardNo = cardNo;

            if (!IsValidCardNo(CardNo))
            {
                Console.WriteLine("\nCard number must be exactly 8 digits and numbers only.\n");
                Console.WriteLine("Press [N] to quit or press any key to try again");
                var retryChoice = Retry();
                if (retryChoice == 'n' || retryChoice == 'N')
                {
                    Console.Clear();
                    ShowTitle("Thank you for using the Atm.");
                    break;
                }
                else
                    continue;
            }
            else
            {
                Console.Write("\nEnter your PIN: ");
                string pin = InputPin();
                Pin = pin;

                if (!IsValidPin(Pin))
                {
                    Console.WriteLine("\nPin must be exactly 4 digits and numbers only.\n");
                    Console.WriteLine("Press [N] to quit or press any key to try again");
                    var retryChoice = Retry();
                    if (retryChoice == 'n' || retryChoice == 'N')
                    {
                        Console.Clear();
                        ShowTitle("Thank you for using the Atm.");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else
                {
                    this.ShowNext = true;
                    break;
                }
            }
        } while (true);
        
    }

    public string InputPin()
    {
        StringBuilder pin = new StringBuilder("");

        while (pin.Length <= 4)
        {
            char pinChar = Console.ReadKey(true).KeyChar;
            if (pinChar == (char)ConsoleKey.Enter)
                break;

            if (pinChar == (char)ConsoleKey.Backspace && pin.Length > 0)
            {
                pin = pin.Remove(pin.Length - 1, 1);
                Console.Write("\b \b");
            }
            else
            {
                Console.Write('*');
                pin.Append(pinChar);
            }
        }
        return pin.ToString();
    }
    public bool IsValidPin(string pin)
    {
        return pin.Length == PinLength && pin.All(char.IsDigit);
    }
    private bool IsValidCardNo(string cardNo)
    {
        return cardNo.Length == CardNoLength && cardNo.All(char.IsDigit);
    }
    public static char Retry()
    {
        var choice = Console.ReadKey(true).KeyChar;
        return choice;
    }
    public static void ShowTitle(string message)
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"         {message}");
        Console.WriteLine("========================================");
    }
    
    public static void ShowError(string message)
    {
        Console.WriteLine(message);
    }
}
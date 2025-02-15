using System;


public class Program
{
    public static void Main(string[] args)
    {
        var initiate = new StartMenu();
        initiate.ShowLoginMenu();
        if(initiate.ShowNext)
        {
            var user = new User(initiate.CardNo, initiate.Pin);
            ATM.GoToOperationMenu(user);
        }
    }

   
}



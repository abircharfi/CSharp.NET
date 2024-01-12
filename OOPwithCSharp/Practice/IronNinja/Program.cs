using System.Timers;
using System;
class Program
{
    static void Main()
    {
        Buffet buffet = new Buffet();
        SweetTooth sweetTooth = new SweetTooth();
        SpiceHound spiceHound = new SpiceHound();
        Random rand = new Random();

        buffet.AddToMenu(new Drink("Soda", 500, false, true));
        buffet.AddToMenu(new Drink("Cocktail", 500, false, true));
        buffet.AddToMenu(new Drink("Coffee", 200, false, true));
        buffet.AddToMenu(new Drink("Tea", 300, false, true));


        int sweetToothConsumed = 0;
        int spiceHoundConsumed = 0;
        // Console.WriteLine(sweetTooth.Calories);
        // int randomIndex = rand.Next(0, buffet.Menu.Count);
        // sweetTooth.Consume(buffet.Menu[randomIndex]);
        // Console.WriteLine(buffet.Menu[randomIndex].Name);
        // Console.WriteLine(sweetTooth.Calories);

        while (sweetTooth.Calories < 1200)
        {
            int randomIndex = rand.Next(0, buffet.Menu.Count);
            sweetTooth.Consume(buffet.Menu[randomIndex]);
            sweetToothConsumed++;
        }

        Console.WriteLine($"sweetTooth consumed {sweetToothConsumed} items");

        while (spiceHound.Calories < 1200)
        {
            int randomIndex = rand.Next(0, buffet.Menu.Count);
            spiceHound.Consume(buffet.Menu[randomIndex]);
            spiceHoundConsumed++;
            
        }
        Console.WriteLine($"spiceHound consumed {spiceHoundConsumed} items");
        if (sweetToothConsumed > spiceHoundConsumed )
        {
            Console.WriteLine("sweetTooth consumed more items");
        }
        else if (sweetToothConsumed == spiceHoundConsumed)
        {
           Console.WriteLine("sweetTooth  and spiceHound consumed equal items"); 
        }
        else
        {
          Console.WriteLine("spiceHound consumed more items");
        }  
        

    }
}

using System;

class Program
{
    static void Main()
    {
        Wizard player1 = new Wizard("Gandalf",25,100);
        Ninja player2 = new Ninja("Ryu",25,75,100);
        Samurai player3 = new Samurai("Hattori Hanzo",25,75,75);

        Console.WriteLine("Welcome to the battle!");
        Console.WriteLine("The players are :");
        Console.WriteLine($"**  {player1.Name}  * * *  {player2.Name}  * * *  {player3.Name}  * *");
        
        
        player1.Attack(player2);
        player1.Heal(player1); 
        player2.Attack(player3);
        player2.Steal(player3); 
        player3.Attack(player1);
        player3.Meditate(); 

        Console.WriteLine($"{player1.Name} has {player1.Health} health remaining.");
        Console.WriteLine($"{player2.Name} has {player2.Health} health remaining.");
        Console.WriteLine($"{player3.Name} has {player3.Health} health remaining.");
    }
}


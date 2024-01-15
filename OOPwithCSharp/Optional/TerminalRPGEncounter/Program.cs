class Program
{
    static void Main()
    {
        // heros
        Ninja ninja = new Ninja("Ryu", 8, 3, 100);
        Samurai samurai = new Samurai("Hattori Hanzo", 8, 3, 75);
        Wizard wizard = new Wizard("Gandalf", 8, 100);

        // enemy party
        Zombie zombie1 = new Zombie("Hungry Zombie 1", 8, 3, 6, 80);
        Zombie zombie2 = new Zombie("Hungry Zombie 2", 8, 3, 6, 80);
        Spider spider = new Spider("Venomous Spider", 8, 3, 6, 80);

        Human[] players = { ninja, samurai, wizard };
        Enemy[] enemies = { zombie1, zombie2, spider };

        Console.WriteLine("Ally party, it's your turn!");

        int turn = 0;

        while (AnyAlive(players) && AnyAliveEnemy(enemies))
        {
            foreach (var player in players)
            {
                if (player.Health > 0)
                {
                    Console.WriteLine($"{player.Name}'s turn.");
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Attack  2. Special Action");
                    int MoveChoice = int.Parse(Console.ReadLine());

                    switch (MoveChoice)
                    {
                        case 1:
                            player.Attack(enemies[turn % enemies.Length]);
                    
                            break;
                        case 2:
                            if (player is Ninja)
                            {
                                ninja.Steal(enemies[turn % enemies.Length]);
                            }
                            else if (player is Samurai)
                            {
                                samurai.Meditate();
                            }
                            else if (player is Wizard)
                            {
                                wizard.Heal(enemies[turn % enemies.Length]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid player type!");
                            }

                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"{player.Name} is down!");
                }
            }

        // enemies turn 
        
        foreach (var enemy in enemies)
        {
            if (enemy.Health > 0)
            {

                Console.WriteLine($"{enemy.Name}'s turn.");
                enemy.Attack(players[turn % players.Length]);
            }
        }
        turn ++ ;
        }
        
     static bool AnyAlive(Human[] players)
    {
       
        foreach (var player in players)
        {
          return (player.Health > 0) ;  
        }
        return false;
    }
    static bool AnyAliveEnemy(Enemy[] enemies)
    {
        
        foreach (var enemy in enemies)
        {
          return (enemy.Health > 0) ;  
        }
        return false;
    }

    if (!AnyAlive(players))
        {
            Console.WriteLine("Enemies win!");
        }
        else
        {
            Console.WriteLine("Players win!");
        }
    }

    }
    






     



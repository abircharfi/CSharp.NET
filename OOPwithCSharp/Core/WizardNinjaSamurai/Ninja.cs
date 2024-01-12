class Ninja : Human
{
    public int Dexterity { get; private set; } 
 
    public Ninja (string name, int str,int intel, int hp) : base(name, str, intel, 75, hp)
    {
        Dexterity = 75 ;
    }

    public int Attack(Human target)
    {
        Random rand = new Random();
        int baseDmg = Dexterity;
        int BadLuck = rand.Next(1, 101);
        if (BadLuck <= 20 )
        {
            Console.WriteLine($"{Name} landed a critical hit on {target.Name}!");
            baseDmg -= 10;
        }
        target.Health -= baseDmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {baseDmg} damage!");

        return target.Health;

    }
    public void Steal(Human target)
    {
        int stealAmount = 5;
        target.Health -= stealAmount;
        Health += stealAmount;

        Console.WriteLine($"{Name} stole {stealAmount} health from {target.Name}!");
    }
}
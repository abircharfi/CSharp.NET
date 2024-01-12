class Samurai : Human
{
    public int Health { get; private set; } 

    public Samurai(string name, int str,int intel, int dex) : base(name, str, intel, dex, 200)
   { 

    Health = 200 ;

   }

   public int Attack(Human target)
   {
    base.Attack(target);
    if (target.Health < 50)
    {
        target.Health =0;
        Console.WriteLine($"{Name} has been defeated by {target.Name}'s finishing blow!");
    }
    return target.Health;
   }

   public void Meditate()
   {
    Health = 200 ;
    Console.WriteLine($"{Name} meditated and restored health to full!");

   }
    
}
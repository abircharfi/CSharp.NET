class Wizard : Human
{
  
    public int Health { get; private set; } 
    public int Intelligence { get; private set; } 

  

    public Wizard(string name, int str, int dex) : base(name, str, 25, dex, 50)
    {
        Intelligence = 25;
        Health = 50;
    }



    public int Attack(Human target)
    {
        int damage = (3 * Intelligence);
        target.Health -= damage ; 
         Console.WriteLine($"Wizard cast a spell on {target.Name} for {damage} damage!");
        this.Health += damage ;
        Console.WriteLine("Wizard healed himself by "+ damage);
        return damage;
        

    }

    public void Heal(Human target)
    {

        int amount = (3 * Intelligence);
        target.Health += amount ; 
        Console.WriteLine($"{Name} heals for "+ amount);

    }
    
}
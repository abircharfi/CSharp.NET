class Zombie : Enemy
    {
        public Zombie(string name, int str, int ener, int bd, int hp) : base(name,str,ener,bd, hp)
        {
        }

        public void Bite(Human target)
        {
        int dmg = Blood * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} bit {target.Name} for {dmg} damage!");
  
        }
    }
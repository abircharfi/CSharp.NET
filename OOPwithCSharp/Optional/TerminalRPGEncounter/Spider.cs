class Spider : Enemy
    {
        public Spider(string name, int str, int ener, int bd, int hp) : base(name,str,ener,bd, hp)
        {
        }

        public void SpiderAttack(Human target)
        {
            int dmg = Strength * 3;
            target.Health -= dmg;
            Console.WriteLine($"{Name} used web attack on {target.Name} for {dmg} damage!");
 
        }
    }
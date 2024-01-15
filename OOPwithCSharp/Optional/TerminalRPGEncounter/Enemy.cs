public class Enemy
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Energy { get; set; }
    public int Blood { get; set; }
    public int Health { get; set; }

    public Enemy(string name, int str, int ener, int bd, int hp)
    {
        Name = name;
        Strength = str;
        Energy = ener;
        Blood = bd;
        Health = hp;
    }

    public int Attack(Human target)
    {
        int dmg = Strength * 2;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}

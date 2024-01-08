class Human
{
    // Properties for Human
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }
    // Add a constructor that takes a value to set Name, and set the remaining fields to default values

    public Human(string name){

        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;

    }
     
    // Add a constructor to assign custom values to all fields

    public Human(string name,int strength,int intelligence,int dexterity,int health)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
        Health = health;

    }
     
    // Build Attack method
    public int Attack(Human target)
    {
        int damage = 3 * Strength;

        target.Health -= damage;

        if (target.Health < 0)
        {
            target.Health = 0;
        }

        return target.Health;
    }



}
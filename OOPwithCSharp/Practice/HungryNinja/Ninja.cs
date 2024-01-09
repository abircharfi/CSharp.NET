class Ninja
{
    private int calorieIntake { get; set; }
    public List<Food> FoodHistory;

    // Add a constructor
    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }

    // Add a public "getter" property called "IsFull"
    public bool IsFull
    {
        get
        {
            return calorieIntake > 1200;
        }
    }

    // Build out the Eat method
    public void Eat(Food item)
    {
        if (!IsFull)
        {
            FoodHistory.Add(item);
            calorieIntake += item.Calories;
            Console.WriteLine($"Eating {item.Name}...");

            if (item.IsSpicy)
            {
                Console.WriteLine("It's Spicy!");
            }
            else
            {
                Console.WriteLine("It's not Spicy.");
            }

            if (item.IsSweet)
            {
                Console.WriteLine("It's Sweet!");
            }
            else
            {
                Console.WriteLine("It's not Sweet.");
            }
        }
        else
        {
            Console.WriteLine("I'm full, can't eat anymore!");
        }
    }
}

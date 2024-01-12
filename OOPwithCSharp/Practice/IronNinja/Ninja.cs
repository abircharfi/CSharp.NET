abstract class Ninja
{
    protected int calorieIntake;
    public int Calories { get { return calorieIntake; } }
    public List<IConsumable> ConsumptionHistory;
    public Ninja()
    {
        calorieIntake = 0;
        ConsumptionHistory = new List<IConsumable>();
    }
    public abstract bool IsFull {get;}
    public abstract void Consume(IConsumable item);
    public void GetInfo()
    {
        Console.WriteLine($"Ninja - Calories: {calorieIntake}");
    }
}
using System;

class SpiceHound : Ninja
{


    
    public override bool IsFull
    {
        get { return calorieIntake >= 1200; }
    }


    public override void Consume(IConsumable item)
    {
        if (!IsFull)
        {
            if (item.IsSpicy)
            {
                calorieIntake -= 5;

            }
            calorieIntake += item.Calories;
            ConsumptionHistory.Add(item);
            this.GetInfo();
        }
        else
        {
            Console.WriteLine("The SpiceHound is full and cannot eat anymore");
        }
    }
}

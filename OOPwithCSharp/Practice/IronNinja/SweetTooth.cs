using System;

class SweetTooth : Ninja
{


    public override bool IsFull
    {
        get { return calorieIntake >= 1200; }
    }

    public override void Consume(IConsumable item)
    {
       
        if (!IsFull)
        {
            calorieIntake += 10;
            calorieIntake += item.Calories;
            ConsumptionHistory.Add(item);
            this.GetInfo();
        }
        else
        {
            Console.WriteLine("The SweetTooth is full and cannot eat anymore");
        }
    }

   
}

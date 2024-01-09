class Program 
{
    static void Main()
    {
Console.WriteLine("Hello, Ninja!");
Buffet MyBuffet = new Buffet();
Ninja MyNinja = new Ninja();


 while (!MyNinja.IsFull)
        {
        
            MyNinja.Eat(MyBuffet.Serve());
        }

       //++ Ninja Foord history  
Console.WriteLine("Ninja Food History :");

foreach (Food item in MyNinja.FoodHistory)
{
  Console.WriteLine($"- {item.Name} ({item.Calories} calories)");  
}

        Console.WriteLine("Ninja is full!");

    }

}
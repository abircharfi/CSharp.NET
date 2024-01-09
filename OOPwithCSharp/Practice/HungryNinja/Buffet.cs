using System;
class Buffet
{
    public List<Food> Menu;
    Random rand = new Random();
     
    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
           
            new Food("Pizza", 300, true, false),
        new Food("Waffle", 150, false, true),
        new Food("Salad", 200, true, true),
        new Food("Burger", 100, false, false),
        new Food("Smoothie", 20, true, true),
        new Food("Chocolate Cake", 30, false, false),
        new Food("Chicken Caesar Salad", 60, false, true)
        };
    }
    
    public Food Serve()
    {
        
        int index = rand.Next(Menu.Count); 
        return Menu[index];

    }
}
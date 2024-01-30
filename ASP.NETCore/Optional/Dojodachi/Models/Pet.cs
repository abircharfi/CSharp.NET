
using System.ComponentModel.DataAnnotations;
namespace Dojodachi.Models ; 

public class Pet
{
    private int _fullness;
    public int fullness
    {
        get { return _fullness; }
        set { _fullness = Math.Max(0, value); } 
    }
    private int _happiness;
    public int happiness
    {
        get { return _happiness;}
        set { _happiness = Math.Max(0, value);}
    }
     
    private int _energy;
    public int energy
    {
         get{return _energy;} 
         set {_energy  = Math.Max(0, value);}
    }

    private int _meals;
    public int meals 
    { 
        get{return _meals ;} 
         set { _meals = Math.Max(0, value);}
    }
    private static Random rand = new Random();

    public Pet ()
    {
     happiness = 20 ;
     fullness = 20;
     energy =50;
     meals = 3;
    }

    public string feed() 
    {
        
        int likeChance = rand.Next(1, 100);
       
            if(likeChance > 25)
            {
                if (meals > 0)
               {
                 int amount = rand.Next(5, 10);
                 fullness += amount;
                 meals -= 1;

                 return $"Your Dojodachi has eaten! Fullness increased by {amount}.";
                }
                else
                {
                  return "You cannot feed your Dojodachi; you do not have meals!";
                }
            }
            else
            {
                 meals -= 1;
                return "Your Dojodachi doesn't want to Feed ! Meals decrease by 1";
            }
       
    }

    public string  play()
    {
            
        int likeChance = rand.Next(1, 100);

        if(likeChance > 25)
        {

        int amount = rand.Next(5, 10);
        happiness += amount;
        energy -= 5;

        return $"You played with your Dojodachi! Happiness + {amount} , Energy -5 ";

        }
        else
        {
            energy -= 5;
            return "Your Dojodachi doesn't want to Play ! Energy decrease by 5";
        }
            
    }

    public string  work() 
    {
        
        int EarnMeals = rand.Next(1,3);
        meals +=EarnMeals;
        energy -= 5;
        return $"Your Dojodachi Worked and earn {EarnMeals} meals, Energy -5";
            
    }

    public string  sleep() 
    {
         energy += 15;
         fullness -=5;
         happiness -=5;
         return $"Your Dojodachi slept and earned +15 of Energy, Fullness -5 , Happiness -5";  
    }
}
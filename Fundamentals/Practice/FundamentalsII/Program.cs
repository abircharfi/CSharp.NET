using System.Globalization;
static void PrintNumbers()
{
    Print all of the integers from 1 to 255.
    for (int i = 0; i < 256; i++)
    {
       Console.WriteLine(i);
    }
    
}
PrintNumbers();

static void PrintOdds()
{
     Print all of the odd integers from 1 to 255.
    Console.WriteLine("odd integers from 1 to 255 are :");
    for (int i = 0; i < 256; i++)
    {
      if (i % 2 != 0 )  {
        Console.WriteLine(i);
      }
    }
   
}
PrintOdds();

static void PrintSum()
{
    // Print all of the numbers from 0 to 255, 
    // but this time, also print the sum as you go. 
    // For example, your output should be something like this:
    
    // New number: 0 Sum: 0
    // New number: 1 Sum: 1
    // New number: 2 Sum: 3
    int Sum =0;
    for (int i = 0; i < 256; i++)
    {
       
       Sum+=i;
       Console.WriteLine("New number:"+ i+"  Sum: "+Sum);
         
    }
       
}

PrintSum();

static void LoopArray(int[] numbers)
{
    // Write a function that would iterate through each item of the given integer array and 
    // print each value to the console. 
    for (int i = 0; i < numbers.Length; i++)
    {

        Console.WriteLine(numbers[i]);
        
    }

}

LoopArray(new int[] {1,2,5,87,9,5,10,25,11,13});

static int FindMax(int[] numbers)
{
    // Write a function that takes an integer array and prints and returns the maximum value in the array. 
    // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
    // or even a mix of positive numbers, negative numbers and zero.

int i = 1;
int MaxNum = numbers[0];

    while (i < numbers.Length)
    {
        if (numbers[i] > MaxNum)
        {
            MaxNum = numbers[i];
        }
        i++;
    }

    Console.WriteLine(MaxNum);
    return MaxNum;

}

FindMax(new int[] {1, -1 , -2 , 0, 27 , 88 , -100});

static void GetAverage(int[] numbers)
{
    // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
    // For example, with an array [2, 10, 3], your program should write 5 to the console.
int sum =0;
    for (int i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
         
    }
    Console.WriteLine("the AVERAGE of the values in the array is : " + sum  / (numbers.Length));
}

GetAverage(new int[] {2,10,3});

static List<int> OddList()
{
    // Write a function that creates, and then returns, a List that contains all the odd numbers between 1 to 255. 
    // When the program is done, the List should have the values of [1, 3, 5, 7, ... 255].
   List<int> oddNumbers = new List<int>();

        for (int i = 1; i <= 255; i += 2)
        {
            oddNumbers.Add(i);
            
            
        }
        Console.WriteLine("[" + string.Join(", ", oddNumbers) + "]");
        return oddNumbers;
    
}

OddList();
static int GreaterThanY(List<int> numbers, int y)
{
    // Write a function that takes an integer List, and an integer "y" and returns the number of values 
    // That are greater than the "y" value. 
    // For example, if our List contains 1, 3, 5, 7 and y is 3. Your function should return 2 
    // (since there are two values in the List that are greater than 3).
    int MaxVal = 0;
    foreach (int number in numbers)
    {
        if (number> y)
        {
            MaxVal ++;
        }
    }
    Console.WriteLine("the number of values That are greater than "+y+" are " +MaxVal);
    return MaxVal ;
}

GreaterThanY(new List<int> {1, 3, 5, 7}, 3);

static void SquareArrayValues(List<int> numbers)
{
    // Write a function that takes a List of integers called "numbers", and then multiplies each value by itself.
    // For example, [1,5,10,-10] should become [1,25,100,100]
    List<int> NewList = new List<int>();
    
    for (int i = 0; i < numbers.Count; i++)
    {
        NewList.Add(numbers[i]*numbers[i]);
    }
    Console.WriteLine("[" + string.Join(", ", NewList) + "]");

}

SquareArrayValues(new List<int> {1,5,10,-10});

static void EliminateNegatives(List<int> numbers)
{
    // Given a List of integers called "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
    // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
        List<int> NewList = new List<int>();
    
    for (int i = 0; i < numbers.Count; i++)
    {
        if (numbers[i]<0){

           NewList.Add(numbers[i]*(-1));  

        }
        else {
          NewList.Add(numbers[i]);  
        }
    }
    Console.WriteLine("[" + string.Join(", ", NewList) + "]");
}

EliminateNegatives(new List<int> {1, 5, 10, -2});



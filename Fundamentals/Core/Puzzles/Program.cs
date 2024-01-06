// Random Array

static void RandomArray()
{
    int[] ArrInt = new int[10];
    Random rand = new Random();
    int MinVal=25;
    int MaxVal=0;
    for (int i = 0; i < ArrInt.Length; i++)
    {

       ArrInt[i] = rand.Next(5,25);
       if (ArrInt[i]<MinVal)
       {
        MinVal = ArrInt[i];
       }
       else {
        MaxVal = ArrInt[i];
       }

       System.Console.WriteLine("la valeur ajouter est "+ ArrInt[i]);
      
        
    }
    Console.WriteLine("La valeur maximale est "+MaxVal);
    Console.WriteLine("La valeur minimal est "+MinVal);



}

RandomArray();

Coin Flip

static string  TossCoin()

{

    Random rand = new Random();
    int randomNumber= rand.Next(1,3);
    string result ="";

    Console.WriteLine( "Tossing a Coin!");

    if (randomNumber == 1)
    {
        result ="Heads";
    }
    else
    {
        result = "Tails";
    } 

    System.Console.WriteLine(result); 
    
    return result;

}

//TossCoin();

static double TossMultipleCoins(int num){

    int HeadsOcc = 0;

    for (int i = 0; i < num; i++)
    {

        string result = TossCoin();

        if (result == "Heads"){

            HeadsOcc ++ ;

        }
        
    }
    
    double HeadPercentage = (double)HeadsOcc / num;
    Console.WriteLine(HeadPercentage);

    return HeadPercentage;


}

TossMultipleCoins(10);

static void Names()
{

    List<string> names = new List<string> {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
    List<string> NewList = new List<string>();
    
    foreach (string chaine in names)
        {
            
            int numberOfCaracter = 0;

            foreach (char caractere in chaine)
            {
               numberOfCaracter ++ ;
            }
            if (numberOfCaracter> 5)
            {
                NewList.Add(chaine);
            }

            
        }
    foreach (string item in NewList)
    {
        
    
        Console.WriteLine(item); 

    }
}

Names();
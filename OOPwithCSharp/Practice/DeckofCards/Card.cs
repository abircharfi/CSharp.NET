class Card
{
    public string Name;
    public string Suit;
    public int Val;


    public Card(string N, String S, int V)
    {
     Name= N;
     Suit=S;
     Val =V;

    }
    public void Print()
    {
     Console.WriteLine($"the name of the card is {Name} ");
     Console.WriteLine($"the suit is {Suit} ");
     Console.WriteLine($"the value is {Val} ");
     
    }



}
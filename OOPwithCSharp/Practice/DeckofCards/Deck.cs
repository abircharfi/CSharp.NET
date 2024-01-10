class Deck
{
    public List<Card> cards { get; set; } 

    public Deck()
    {
      cards = new List<Card>();
    }

    public static List<Card> InitializeDeck()
    {
        List<Card> deck = new List<Card>();
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] names = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        for (int i = 0; i < suits.Length; i++)
        {
            for (int j = 0; j < names.Length; j++)
            {
                int val = j + 1;
                deck.Add(new Card(names[j], suits[i], val));
            }
        }

        return deck;
    }


   public Card Deal()
{
    int maxVal = 0;
    int maxIndex = -1;

    for (int i = 0; i < cards.Count; i++)
    {
        string cardName = cards[i].Name;

        switch (cardName)
        {
            case "Ace":
                cards[i].Val = 0;
                break;
            case "Jack":
                cards[i].Val = 11;
                break;
            case "Queen":
                cards[i].Val = 12;
                break;
            case "King":
                cards[i].Val = 13;
                break;
            default:
                cards[i].Val = int.Parse(cardName);
                break;
        }

        if (cards[i].Val > maxVal)
        {
            maxVal = cards[i].Val;
            maxIndex = i;
        }
    }

    if (maxIndex != -1)
    {
        Console.WriteLine($"Topmost card: {cards[maxIndex].Name} of {cards[maxIndex].Suit} (Value: {cards[maxIndex].Val})");

        Card topmostCard = cards[maxIndex];
        cards.RemoveAt(maxIndex);

        return topmostCard;
    }
    else
    {
        Console.WriteLine("Deck is empty. Cannot find the topmost card.");
        return null; 
    }
}


   public Deck Reset()
    {
        cards = InitializeDeck();
        Console.WriteLine($"The new cards after resetting are : ");
        foreach (Card item in cards)
        {
            item.Print();
        }
        return this;
    }

    public Deck Shuffle()
    {
        Random rand = new Random();

        for (int i = 0; i < cards.Count - 1; i++)
        {
            int j = rand.Next(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
        Console.WriteLine($"The new cards after shuffling are : ");
        foreach (Card item in cards)
        {
            item.Print();
        }
        return this;
    }
}

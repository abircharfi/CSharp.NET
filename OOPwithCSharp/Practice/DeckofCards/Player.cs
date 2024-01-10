
class Player
{
    public string Name { get; set; }
    public List<Card> Hand { get; } = new List<Card>();

    private static readonly Random rand = new Random();

    public Player(string playerName)
    {
        Name = playerName;
        
    }
    
    public Card Draw(Deck deck)
    {
        

        if (deck.cards.Count > 0 && Hand.Count < 27)
        {
            int randomIndex = rand.Next(0, deck.cards.Count);
            Card chosenCard = deck.cards[randomIndex];

            if (chosenCard != null)
            {
                deck.cards.RemoveAt(randomIndex);
                Hand.Add(chosenCard);

                Console.WriteLine($"Drawn Card: {chosenCard.Name} of {chosenCard.Suit} (Value: {chosenCard.Val})");

                return chosenCard;
            }
        }
        else
        {
            Console.WriteLine("Cannot draw a card. Either the deck is empty or the player's hand is full.");
        }

        return null; 
    }

    public Card Discard(int value)
{
    for (int i = Hand.Count - 1; i >= 0; i--)
    {
        if (Hand[i].Val == value)
        {
            Card discardedCard = Hand[i];
            Hand.RemoveAt(i);
            return discardedCard;
        }
    }

    return null;
}

}
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Hello, Deck Card!");
            Console.WriteLine("*******************************************************");

            Player player1 = new Player("John Doe");
            Player player2 = new Player("Bibou");

            Deck deck = new Deck();

            Deck resetDeck = deck.Reset();
            Deck shuffledDeck = resetDeck.Shuffle();

            Console.WriteLine("*******************************************************");

            Deck handOfPlayer1 = new Deck();
            Deck handOfPlayer2 = new Deck();

            if (deck != null)
            {
                Console.WriteLine($"\n{player1.Name}'s Hand after Drawing 26 Cards:");
                for (int i = 0; i < 26; i++)
                {
                    Card drawnCard1 = player1.Draw(deck);
                    handOfPlayer1.cards.Add(drawnCard1);
                }

                Console.WriteLine($"\n{player2.Name}'s Hand after Drawing 26 Cards:");
                for (int i = 0; i < 26; i++)
                {
                    Card drawnCard2 = player2.Draw(deck);
                    handOfPlayer2.cards.Add(drawnCard2);
                }
            }

            Console.WriteLine("*******************************************************");
           

            while (handOfPlayer1.cards.Count > 3 && handOfPlayer2.cards.Count > 3)
            {
                  Console.WriteLine(handOfPlayer1.cards.Count);
                  Console.WriteLine(handOfPlayer2.cards.Count);
                Card topMost1 = handOfPlayer1.Deal();
                Card topMost2 = handOfPlayer2.Deal();

                Console.WriteLine("*******************************************************");
                Console.WriteLine($"{player1.Name} plays: {topMost1.Val} of {topMost1.Suit}");
                Console.WriteLine($"{player2.Name} plays: {topMost2.Val} of {topMost2.Suit}");

                if (topMost1.Val > topMost2.Val)
                {
                    Console.WriteLine($"{player1.Name} wins this round!");
                    player1.Hand.Add(topMost1);
                    player1.Hand.Add(topMost2);
                }
                else if (topMost1.Val < topMost2.Val)
                {
                    Console.WriteLine($"{player2.Name} wins this round!");
                    player2.Hand.Add(topMost1);
                    player2.Hand.Add(topMost2);
                }
                else
                {
                    Console.WriteLine("It's a tie! Going to war...");

                    
                    War(handOfPlayer1, handOfPlayer2, player1, player2);
                }
            }

            Console.WriteLine("*******************************************************");
            Console.WriteLine("Game Over!");

           
            while (handOfPlayer1.cards.Count > 3 && handOfPlayer2.cards.Count > 3)
            {
                  Console.WriteLine(handOfPlayer1.cards.Count);
                  Console.WriteLine(handOfPlayer2.cards.Count);
                Card topMost1 = handOfPlayer1.Deal();
                Card topMost2 = handOfPlayer2.Deal();

                Console.WriteLine("*******************************************************");
                Console.WriteLine($"{player1.Name} plays: {topMost1.Val} of {topMost1.Suit}");
                Console.WriteLine($"{player2.Name} plays: {topMost2.Val} of {topMost2.Suit}");

                if (topMost1.Val > topMost2.Val)
                {
                    Console.WriteLine($"{player1.Name} wins this round!");
                    player1.Hand.Add(topMost1);
                    player1.Hand.Add(topMost2);
                }
                else if (topMost1.Val < topMost2.Val)
                {
                    Console.WriteLine($"{player2.Name} wins this round!");
                    player2.Hand.Add(topMost1);
                    player2.Hand.Add(topMost2);
                }
                else
                {
                    Console.WriteLine("It's a tie! Going to war...");

                    
                    War(handOfPlayer1, handOfPlayer2, player1, player2);
                }
            }

            Console.WriteLine("*******************************************************");
            Console.WriteLine("Game Over!");

           
            if (player1.Hand.Count > player2.Hand.Count)
            {
                Console.WriteLine($"{player1.Name} wins the game!");
            }
            else if (player1.Hand.Count < player2.Hand.Count)
            {
                Console.WriteLine($"{player2.Name} wins the game!");
            }
            else
            {
                Console.WriteLine("It's a tie! The game is a draw.");
            }

          
            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgainResponse = Console.ReadLine().ToLower();

            if (playAgainResponse != "yes")
            {
                break; 
            }
        }
    }

    


    static void War(Deck hand1, Deck hand2, Player player1, Player player2)
{
    List<Card> warCards1 = new List<Card>();
    List<Card> warCards2 = new List<Card>();

  
    for (int i = 0; i < 4; i++)
    {
        if (hand1.cards.Count > 0)
        {
            Card warCard1 = hand1.Deal();
            if (warCard1 != null)
            {
                
                warCards1.Add(warCard1);
            }
            else
            {
                Console.WriteLine($"{player1.Name}'s hand is empty during war!");
                break;
            }
        }

        if (hand2.cards.Count > 0)
        {
            Card warCard2 = hand2.Deal();
            if (warCard2 != null)
            {
                
                warCards2.Add(warCard2);
            }
            else
            {
                Console.WriteLine($"{player2.Name}'s hand is empty during war!");
                break;
            }
        }
    }

    
    if (warCards1.Count == 4 && warCards2.Count == 4)
    {
        Console.WriteLine("War Cards:");
        foreach (var card in warCards1)
        {
            Console.WriteLine($"{player1.Name} plays: {card.Val} of {card.Suit}");
        }

        foreach (var card in warCards2)
        {
            Console.WriteLine($"{player2.Name} plays: {card.Val} of {card.Suit}");
        }

       
        Card warTopMost1 = warCards1[warCards1.Count - 1];
        Card warTopMost2 = warCards2[warCards2.Count - 1];

        Console.WriteLine($"{player1.Name} plays: {warTopMost1.Val} of {warTopMost1.Suit}");
        Console.WriteLine($"{player2.Name} plays: {warTopMost2.Val} of {warTopMost2.Suit}");

        if (warTopMost1.Val > warTopMost2.Val)
    {
    Console.WriteLine($"{player1.Name} wins the war!");

    foreach (var card in warCards1)
    {
        player1.Hand.Add(card);
    }

    foreach (var card in warCards2)
    {
        player1.Hand.Add(card);
    }
    }
    else if (warTopMost1.Val < warTopMost2.Val)
    {
    Console.WriteLine($"{player2.Name} wins the war!");

    foreach (var card in warCards1)
    {
        player2.Hand.Add(card);
    }

    foreach (var card in warCards2)
    {
        player2.Hand.Add(card);
    }
    }

        else
        {
            Console.WriteLine("It's a tie again! Another war...");
            War(hand1, hand2, player1, player2);
        }
    }
}

}

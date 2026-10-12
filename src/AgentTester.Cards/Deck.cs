namespace AgentTester.Cards;

public class Deck
{
    private readonly List<Card> _cards;

    public Deck()
    {
        _cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues<Suit>())
        {
            foreach (Rank rank in Enum.GetValues<Rank>())
            {
                _cards.Add(new Card(rank, suit));
            }
        }
    }

    public int RemainingCount => _cards.Count;

    public void Shuffle()
    {
        var random = Random.Shared;
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    public Card Draw()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("The deck is empty.");
        }

        var card = _cards[^1];
        _cards.RemoveAt(_cards.Count - 1);
        return card;
    }
     public List<Card> DrawHand(int count)
    {
        if (_cards.Count < count)
        {
            throw new InvalidOperationException("Not enough cards in the deck.");
        }

        var hand = new List<Card>();
        for (int i = 0; i < count; i++)
        {
            hand.Add(Draw());
        }
        return hand;
    }
}



using AgentTester.Cards;

namespace AgentTester.Tests;

public class DeckTests
{
    [Fact]
    public void Constructor_CreatesFullDeck_With52UniqueCards()
    {
        // Arrange
        var deck = new Deck();

        // Act
        var remaining = deck.RemainingCount;

        // Assert
        Assert.Equal(52, remaining);
    }

    [Fact]
    public void Draw_RemovesOneCard_DecrementsRemainingCount()
    {
        // Arrange
        var deck = new Deck();

        // Act
        deck.Draw();

        // Assert
        Assert.Equal(51, deck.RemainingCount);
    }

    [Fact]
    public void Draw_OnEmptyDeck_ThrowsInvalidOperationException()
    {
        // Arrange
        var deck = new Deck();
        for (int i = 0; i < 52; i++)
        {
            deck.Draw();
        }

        // Act
        var act = () => deck.Draw();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Draw_AllCards_ReturnsNoDuplicates()
    {
        // Arrange
        var deck = new Deck();
        var drawnCards = new List<Card>();

        // Act
        for (int i = 0; i < 52; i++)
        {
            drawnCards.Add(deck.Draw());
        }

        // Assert
        Assert.Equal(52, drawnCards.Distinct().Count());
    }

    [Fact]
    public void Shuffle_DoesNotChangeRemainingCount()
    {
        // Arrange
        var deck = new Deck();

        // Act
        deck.Shuffle();

        // Assert
        Assert.Equal(52, deck.RemainingCount);
    }

    [Fact]
    public void Shuffle_ChangesCardOrder()
    {
        // Arrange
        var ordered = new Deck();
        var originalOrder = new List<Card>();
        for (int i = 0; i < 52; i++)
        {
            originalOrder.Add(ordered.Draw());
        }

        var shuffled = new Deck();
        shuffled.Shuffle();
        var shuffledOrder = new List<Card>();

        // Act
        for (int i = 0; i < 52; i++)
        {
            shuffledOrder.Add(shuffled.Draw());
        }

        // Assert
        Assert.NotEqual(originalOrder, shuffledOrder);
    }
}

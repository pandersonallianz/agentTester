using AgentTester.Cards;

namespace AgentTester.Tests;

public class CardTests
{
    [Fact]
    public void ToString_ReturnsRankAndSuit()
    {
        // Arrange
        var card = new Card(Rank.Ace, Suit.Spades);

        // Act
        var result = card.ToString();

        // Assert
        Assert.Equal("Ace of Spades", result);
    }

    [Fact]
    public void Equals_SameRankAndSuit_AreEqual()
    {
        // Arrange
        var first = new Card(Rank.King, Suit.Hearts);
        var second = new Card(Rank.King, Suit.Hearts);

        // Act
        var areEqual = first.Equals(second);

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void Equals_DifferentSuit_AreNotEqual()
    {
        // Arrange
        var first = new Card(Rank.King, Suit.Hearts);
        var second = new Card(Rank.King, Suit.Clubs);

        // Act
        var areEqual = first.Equals(second);

        // Assert
        Assert.False(areEqual);
    }
}

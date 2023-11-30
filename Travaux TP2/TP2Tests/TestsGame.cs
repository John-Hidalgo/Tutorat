using Xunit;
using TP2;
namespace TP2Tests
{
  public class TestsGame
  {
    
    
    #region GetHighestCard
    [Fact]
    public void CanGetHighestCardOnRandomHand ()
    {
      // Arrange
      int[] values = { 2, 12, 43, 23, 1 };

      // Act
      int highestCard = Game.GetHighestCard (values);

      // Assert
      Assert.Equal (Game.CK, highestCard);
    }
    [Fact]
    public void CanGetHighestCardOnRandomHandWithAce ()
    {
      // Arrange
      int[] values = { 2, 12, 43, 23, 0 };

      // Act
      int highestCard = Game.GetHighestCard (values);

      // Assert
      Assert.Equal (Game.CA, highestCard);
    }
    [Fact]
    public void CanGetHighestCardOnConstantHand ()
    {
      // Arrange
      int[] values = { 2, 2, 2, 2, 2 };

      // Act
      int highestCard = Game.GetHighestCard (values);

      // Assert
      Assert.Equal (Game.C3, highestCard);
    }
    #endregion // GetHighestCard

    #region HasPair
    [Fact]
    public void CantFindOnePairIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 15, 17, 24, 31 };

      // Act
      bool hasPair = Game.HasPair (values);

      // Assert
      Assert.False (hasPair);
    }
    [Fact]
    public void CanFindOnePairIfPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 24, 31 };

      // Act
      bool hasPair = Game.HasPair (values);

      // Assert
      Assert.True (hasPair);
    }
    [Fact]
    public void CantFindOnePairIfThreeOfAKindPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 24, 29 };

      // Act
      bool hasPair = Game.HasPair (values);

      // Assert
      Assert.False (hasPair);
    }
    
    
    
    [Fact]
    public void CantFindOnePairIfFourOfAKindPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 29, 42 };

      // Act
      bool hasPair = Game.HasPair (values);

      // Assert
      Assert.False (hasPair);
    }
    #endregion // HasPair

    #region HasTwoPairs
    [Fact]
    public void CantFindTwoPairsIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 15, 17, 19, 31 };

      // Act
      bool hasTwoPairs = Game.HasTwoPairs (values);

      // Assert
      Assert.False (hasTwoPairs);
    }
    [Fact]
    public void CantFindTwoPairsIfOnePairPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 24, 31 };

      // Act
      bool hasTwoPairs = Game.HasTwoPairs (values);

      // Assert
      Assert.False (hasTwoPairs);
    }
    [Fact]
    public void CanFindTwoPairsIfPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 28, 31 };

      // Act
      bool hasTwoPairs = Game.HasTwoPairs (values);

      // Assert
      Assert.True (hasTwoPairs);
    }
    [Fact]
    public void CantFindTwoPairsIfThreeOfAKindPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 29, 31 };

      // Act
      bool hasTwoPairs = Game.HasTwoPairs (values);

      // Assert
      Assert.False (hasTwoPairs);
    }
    [Fact]
    public void CantFindTwoPairsIfFourOfAKindPresent ()
    {
      // Arrange
      int[] values = { 3, 16, 17, 29, 42 };

      // Act
      bool hasTwoPairs = Game.HasTwoPairs (values);

      // Assert
      Assert.False (hasTwoPairs);
    }
    #endregion // HasTwoPairs

    #region HasThreeOfAKind
    [Fact]
    public void CantFindThreeOfAKindIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 15, 17, 24, 31 };

      // Act
      bool hasThreeOfAKind = Game.HasThreeOfAKind (values);

      // Assert
      Assert.False (hasThreeOfAKind);
    }
    [Fact]
    public void CantFindThreeOfAKindIfOnePairPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 24, 31 };

      // Act
      bool hasThreeOfAKind = Game.HasThreeOfAKind (values);

      // Assert
      Assert.False (hasThreeOfAKind);
    }
    [Fact]
    public void CantFindThreeOfAKindIfTwoPairsPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 28, 31 };

      // Act
      bool hasThreeOfAKind = Game.HasThreeOfAKind (values);

      // Assert
      Assert.False (hasThreeOfAKind);
    }
    [Fact]
    public void CanFindThreeOfAKindIfPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 29, 31 };

      // Act
      bool hasThreeOfAKind = Game.HasThreeOfAKind (values);

      // Assert
      Assert.True (hasThreeOfAKind);
    }
    [Fact]
    public void CantFindThreeOfAKindPairsIfFourOfAKindPresent ()
    {
      // Arrange
      int[] values = { 3, 15, 16, 29, 42 };

      // Act
      bool hasThreeOfAKind = Game.HasThreeOfAKind (values);

      // Assert
      Assert.False (hasThreeOfAKind);
    }
    #endregion // HasThreeOfAKind

    #region HasStraight
    [Fact]
    public void CantFindStraightIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 17, 31, 45, 8 };

      // Act
      bool hasStraight = Game.HasStraight (values);

      // Assert
      Assert.False (hasStraight);
    }

    [Fact]
    public void CantFindStraightIfNonePresentButSmallestCardIs5MinusHighestCard ()
    {
      // Arrange
      int[] values = { 3, 4, 5, 7, 16 };

      // Act
      bool hasStraight = Game.HasStraight (values);

      // Assert
      Assert.False (hasStraight);
    }
    [Fact]
    public void CanFindStraightWithNoAceIfPresent ()
    {
      // Arrange
      int[] values = { 3, 17, 31, 45, 7 };

      // Act
      bool hasStraight = Game.HasStraight (values);

      // Assert
      Assert.True (hasStraight);
    }
    [Fact]
    public void CanFindStraightWithAceAtBeginningIfPresent ()
    {
      // Arrange
      int[] values = { 13, 14, 28, 3, 43 };

      // Act
      bool hasStraight = Game.HasStraight (values);

      // Assert
      Assert.True (hasStraight);
    }
    [Fact]
    public void CanFindStraightWithAceAtEndIfPresent ()
    {
      // Arrange
      int[] values = { 13, 22, 36, 24, 12 };

      // Act
      bool hasStraight = Game.HasStraight (values);

      // Assert
      Assert.True (hasStraight);
    }
    #endregion // HasStraight

    #region HasFlush
    [Fact]
    public void CantFindFlushIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 5, 7, 9, 20 };

      // Act
      bool hasFlush = Game.HasFlush (values);

      // Assert
      Assert.False (hasFlush);
    }
    [Fact]
    public void CanFindFlushIfPresent ()
    {
      // Arrange
      int[] values = { 3, 5, 7, 9, 10 };

      // Act
      bool hasFlush = Game.HasFlush (values);

      // Assert
      Assert.True (hasFlush);
    }
    #endregion // HasStraight

    #region HasFullHouse
    [Fact]
    public void CantFindFullHouseIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 5, 18, 16, 30 };

      // Act
      bool hasFullHouse = Game.HasFullHouse (values);

      // Assert
      Assert.False (hasFullHouse);
    }
    [Fact]
    public void CanFindFullHouseIfPresent ()
    {
      // Arrange
      int[] values = { 3, 5, 18, 16, 31 };

      // Act
      bool hasFullHouse = Game.HasFullHouse (values);

      // Assert
      Assert.True (hasFullHouse);
    }
    #endregion // HasFullHouse

    #region HasFourOfAKind
    [Fact]
    public void CantFindFourOfAKindIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 16, 29, 41, 30 };

      // Act
      bool hasFourOfAKind = Game.HasFourOfAKind (values);

      // Assert
      Assert.False (hasFourOfAKind);
    }
    [Fact]
    public void CanFindFourOfAKindIfPresent ()
    {
      // Arrange
      int[] values = { 3, 16, 29, 42, 30 };

      // Act
      bool hasFourOfAKind = Game.HasFourOfAKind (values);

      // Assert
      Assert.True (hasFourOfAKind);
    }
    #endregion // HasFourOfAKind

    #region HasStraightFlush
    [Fact]
    public void CantFindStraighFlushIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 16, 29, 41, 30 };

      // Act
      bool hasStraightFlush = Game.HasStraightFlush (values);

      // Assert
      Assert.False (hasStraightFlush);
    }
    [Fact]
    public void CanFindStraightFlushIfPresent ()
    {
      // Arrange
      int[] values = { 3, 4, 5, 6, 7 };

      // Act
      bool hasStraightFlush = Game.HasStraightFlush (values);

      // Assert
      Assert.True (hasStraightFlush);
    }
    [Fact]
    public void CanFindStraightFlushIfRoyalFlushPresent ()
    {
      // Arrange
      int[] values = { 25, 22, 23, 21, 24 };

      // Act
      bool hasStraightFlush = Game.HasStraightFlush (values);

      // Assert
      Assert.True (hasStraightFlush);
    }
    #endregion // HasStraightFlush

    #region HasRoyalFlush
    [Fact]
    public void CantFindRoyalFlushIfNonePresent ()
    {
      // Arrange
      int[] values = { 3, 16, 29, 41, 30 };

      // Act
      bool hasRoyalFlush = Game.HasRoyalFlush (values);

      // Assert
      Assert.False (hasRoyalFlush);
    }
    [Fact]
    public void CantFindRoyalFlushIfStraightFlushPresent ()
    {
      // Arrange
      int[] values = { 3, 4, 5, 6, 7 };

      // Act
      bool hasRoyalFlush = Game.HasRoyalFlush (values);

      // Assert
      Assert.False (hasRoyalFlush);
    }
    [Fact]
    public void CanFindRoyalFlushIfPresent ()
    {
      // Arrange
      int[] values = { 25, 22, 23, 13, 24 };

      // Act
      bool hasRoyalFlush = Game.HasRoyalFlush (values);

      // Assert
      Assert.True (hasRoyalFlush);
    }
    #endregion // HasStraightFlush
    
  }
}
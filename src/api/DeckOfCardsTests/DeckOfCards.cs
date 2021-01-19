using DeckOfCards.Services;
using Xunit;

namespace DeckOfCardsTests
{
    public class DeckOfCards
    {
        private readonly DeckService _deckService;

        public DeckOfCards()
        {
            _deckService = new DeckService();
        }

        [Fact]
        public void ShouldReturnFullListOfCards()
        {
            // Arrange


            // Act
            var deck = _deckService
                .BuildStandardDeck()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Equal(52, deck.Cards.Count);
        }

        [Fact]
        public void ShouldShuffledDeck()
        {
            // Arrange
            var deck = _deckService
                .BuildStandardDeck()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            var shuffledDeck = _deckService
                .BuildStandardDeck()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            // Act
            _deckService
                .ShuffleCards(shuffledDeck)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            // Assert [It's possible that these cards maybe the same so this isn't a great test]
            Assert.NotEqual(deck.Cards[0], shuffledDeck.Cards[0]);
        }
    }
}

using DeckOfCards.Models;
using System.Threading.Tasks;

namespace DeckOfCards.Interfaces
{
    public interface IDeckService
    {
        /// <summary>
        /// Creates a standard 52 card deck (not suffled)
        /// </summary>
        /// <returns>The list of cards in order</returns>
        Task<Deck> BuildStandardDeck();

        // <summary>
        /// Implements the Fisher Yates Shuffle as this appears
        /// to be the efficient method of randomly selecting cards
        /// source: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        /// <param name="deck">The deck that will be shuffled</param>
        Task ShuffleCards(Deck deck);
    }
}

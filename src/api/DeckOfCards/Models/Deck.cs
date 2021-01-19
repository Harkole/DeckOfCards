using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards.Models
{
    public class Deck
    {
        /// <summary>
        /// A list of cards
        /// </summary>
        public List<Card> Cards { get; set; } = Enumerable.Empty<Card>().ToList();
    }
}

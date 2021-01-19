using System.Collections.Generic;

namespace DeckOfCards.Models
{
    public class Card
    {
        /// <summary>
        /// Provides the playing suites: Hearts, Diamonds, Clubs and Spades
        /// </summary>
        public enum SuitType { Hearts, Diamonds, Clubs, Spades };

        /// <summary>
        /// Provides the face value of the card, Aces are high
        /// </summary>
        public enum FaceType { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

        /// <summary>
        /// Holds the card type and value
        /// </summary>
        public KeyValuePair<SuitType, FaceType> PlayingCard { get; set; }
    }
}

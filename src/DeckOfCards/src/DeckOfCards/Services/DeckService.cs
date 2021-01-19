using DeckOfCards.Interfaces;
using DeckOfCards.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DeckOfCards.Models.Card;

namespace DeckOfCards.Services
{
    public class DeckService : IDeckService
    {
        private static readonly Random _random = new Random();

        /// <inheritdoc />
        public Task<Deck> BuildStandardDeck()
        {
            var deck = new Deck();

            for (int i = 0; i < 52; i++)
            {
                // Establish the suite from where we are in the deck
                var cardSuite = (SuitType)Math.Floor((decimal)i / 13);

                // Estbalish a card value from postion in the deck, add two to align to the card values
                var cardValue = (FaceType)(i % 13 + 2);

                // Create the card object and add it to the deck
                var card = new KeyValuePair<SuitType, FaceType>(cardSuite, cardValue);
                deck.Cards.Add(new Card { PlayingCard = card });
            }

            // Return the built deck
            return Task.FromResult(deck);
        }

        /// <inheritdoc />
        public Task ShuffleCards(Deck deck)
        {
            // Get the cards to keep things simple to read
            var cards = deck.Cards;

            // The deck size should always be 52 be allow for future changes
            var deckSize = deck.Cards.Count;

            for (int i = 0; i < (deckSize - 1); i++)
            {
                // Get some random index position
                var randomValue = i + _random.Next(deckSize - i);

                // Switch the cards around in the list
                var temp = cards[randomValue];
                cards[randomValue] = cards[i];
                cards[i] = temp;
            }

            // The Deck has been shuffled
            return Task.CompletedTask;
        }
    }
}

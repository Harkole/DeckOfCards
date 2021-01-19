using DeckOfCards.Interfaces;
using DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DeckOfCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly ILogger<DeckController> _logger;
        private readonly IDeckService _service;

        public DeckController(ILogger<DeckController> logger, IDeckService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Returns the standard deck in order
        /// </summary>
        /// <returns>Unshuffled deck of 52 cards</returns>
        [HttpGet]
        public async Task<IActionResult> GetOrderedDeck()
        {
            // Fetch the standard ordered deck of 52 cards
            var deck = await _service
                .BuildStandardDeck()
                .ConfigureAwait(false);

            // return the deck
            return Ok(deck);
        }

        /// <summary>
        /// Shuffles the provided deck of cards as long as there are 52 cards remaining
        /// the provided deck may already have been shuffled
        /// </summary>
        /// <param name="deck">The deck of cards to shuffle</param>
        /// <returns>A deck of cards that have been randomly shuffled</returns>
        [HttpPost]
        public async Task<IActionResult> ShuffleDeck([FromBody]Deck deck)
        {
            // We only shuffle if we've got a deck of 52 cards
            if (null == deck || 52 != deck.Cards.Count)
            {
                _logger.LogWarning("Attempted to shuffle a deck containing less than 52 cards/No cards");
                return BadRequest("Invalid deck, the deck must contain 52 cards");
            }

            // Shuffle the deck
            await _service
                .ShuffleCards(deck)
                .ConfigureAwait(false);

            // Return the unordered deck
            return Ok(deck);
        }
    }
}

using System;
using System.Collections.Generic;

namespace SayedHa.Cards.Shared {

    public interface IDeck {
        List<ICard> Cards { get; }

        /// <summary>
        /// Randomizes the list of cards
        /// </summary>
        void Shuffle();
        /// <summary>
        /// Moves to the next card, and returns that card.
        /// </summary>
        /// <returns>next card</returns>
        ICard MoveNextCard();
        /// <summary>
        /// Moves to the previous card, and returns that card.
        /// </summary>
        /// <returns>next card</returns>
        ICard MovePreviousCard();
    }

    public class Deck : IDeck {
        public Deck() {
            Cards = GetAllCards();
        }

        private int _index = 0;
        public List<ICard> Cards { get; private set; }

        public void Shuffle() {
            // reset the index
            throw new NotImplementedException();
        }

        public ICard MoveNextCard() {
            _index = (++_index % (Cards.Count));

            throw new NotImplementedException();
        }

        public ICard MovePreviousCard() {
            throw new NotImplementedException();
        }

        protected internal List<ICard> GetAllCards() {
            var cards = new List<ICard>();

            foreach (var suit in GetAllSuits()) {
                for (var i = 2; i <= 10; i++) {
                    cards.Add(new Card(suit, i.ToString()));
                }
                foreach (var name in GetAllNamedCardNames()) {
                    cards.Add(new Card(suit, name));
                }
            }

            return cards;
        }

        protected internal List<Suit> GetAllSuits() {
            return new List<Suit> {
                Suit.Club,
                Suit.Diamond,
                Suit.Heart,
                Suit.Spade
            };
        }

        protected internal List<string> GetAllNamedCardNames() {
            return new List<string> {
                "J",
                "Q",
                "K",
                "A"
            };
        }
    }
}

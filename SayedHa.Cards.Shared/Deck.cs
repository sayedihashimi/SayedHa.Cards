using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SayedHa.Cards.Shared.Extensions;

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
        /// <summary>
        /// Returns the current card
        /// </summary>
        /// <returns>current card</returns>
        ICard GetCurrentCard();
    }

    public class Deck : IDeck {
        public Deck() {
            Cards = GetAllCards();
        }

        // internal for testing purposes
        internal int _index = 0;
        internal List<int> _indexList;
        internal List<ICard> _cards;
        public List<ICard> Cards {
            get { return _cards; }
            private set {
                _cards = value;
                _index = 0;
                _indexList = new List<int>();
                if (_cards != null) {
                    for (var i = 0; i < _cards.Count; i++) {
                        _indexList.Add(i);
                    }
                }
            }
        }

        public void Shuffle() {
            // reset the index
            _index = 0;
            _indexList.Shuffle();
        }

        public ICard GetCurrentCard() {
            return GetCardForIndex(_index);
        }

        public ICard MoveNextCard() {
            _index = (++_index % (Cards.Count));
            return GetCardForIndex(_index);
        }

        public ICard MovePreviousCard() {
            _index = (--_index % (Cards.Count));
            return GetCardForIndex(_index);
        }

        private ICard GetCardForIndex(int index) {
            return _cards[_indexList[index]];
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

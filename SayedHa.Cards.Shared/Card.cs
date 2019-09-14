using System;
using System.Diagnostics;

namespace SayedHa.Cards.Shared {

    public interface ICard {
        string Name { get; set; }
        Suit Suit { get; set; }
    }
    [DebuggerDisplay("{Name}.{Suit}")]
    public class Card : ICard {
        public Card(Suit suit, string name) {
            Suit = suit;
            Name = name;
        }
        public string Name { get; set; }
        public Suit Suit { get; set; }
    }
}

using System;
using System.Text;
using SayedHa.Cards.Shared;
using Xunit;

namespace SayedHa.Cards.Test {
    public class TestDeck {
        [Fact]
        public void TestGetAllCards01() {
            var allCards = new Deck().GetAllCards();

            Assert.NotNull(allCards);
            Assert.Equal(52, allCards.Count);
        }
    }
}
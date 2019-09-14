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

        [Fact]
        public void TestGetNextCard01() {
            var deck = new Deck();
            
            // -1 to avoid index out of bounds on last item
            for(var i = 0; i < deck._cards.Count-1; i++) {
                var expectedCard = deck._cards[deck._indexList[deck._index + 1]];
                var currentIndex = deck._index;

                var actualCard = deck.MoveNextCard();
                Assert.Equal(expectedCard, actualCard);
                Assert.Equal(currentIndex + 1, deck._index);
            }
        }

        [Fact]
        public void TestShuffle01() {
            var deck = new Deck();

            // ensure it's not shuffled and then check shuffled
            Assert.Equal(0, deck._indexList[0]);
            Assert.Equal(1, deck._indexList[1]);
            Assert.Equal(10, deck._indexList[10]);

            deck.Shuffle();
            // check 10 and if >=6 are different then that is good
            int numNotEqual = 0;

            for(var i = 0; i < 10; i++) {
                if(i != deck._indexList[i]) {
                    numNotEqual++;
                }
            }

            Assert.True(numNotEqual >= 6, $"Shuffle failed not enough randomization. numNotEqual='{numNotEqual}'");
        }

    }
}
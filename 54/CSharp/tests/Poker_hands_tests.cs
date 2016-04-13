using Xunit;
using Poker.models;

namespace Poker.tests
{
    public class Hand_tests {
        
        [Fact]
        public void Hight_card_loose()
        {
            var result = Round.Judge("8C TS KC 9H 4S 7D 2S 5D 3S AC");
            Assert.True(result == 0);
        }
        
        [Fact]
        public void Hight_card_win()
        {
            var result = Round.Judge("5H 5C 6S 7S KD 2C 3S 8S 8D TD");
            Assert.True(result == 1);
        }
    }
}
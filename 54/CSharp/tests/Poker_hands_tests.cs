using Xunit;
using Poker.models;

namespace Poker.tests
{
    public class Hand_tests {
        
        [Fact]
        public void Hight_card()
        {
            var result = Round.Judge("8C TS KC 9H 4S 7D 2S 5D 3S AC");
            Assert.True(result == 0);
        }
        
        [Fact]
        public void One_pair_vs_ight_card()
        {
            var result = Round.Judge("5H 8C 6S 2S 2D AC KS QS TD JD");
            Assert.True(result == 1);
        }
        
        [Fact]
        public void Two_Pairs_pair_over_one_pair()
        {
            var result = Round.Judge("2C 2S 3S 3D 4D AH AC KS QS JD");
            Assert.True(result == 1);
        }
        
        [Fact]
        public void Three_of_kind_vs_two_pairs()
        {
            var result = Round.Judge("2D 2D 2D 3D 4D AD AC KS KH QC");
            Assert.True(result == 1);
        }
    }
}
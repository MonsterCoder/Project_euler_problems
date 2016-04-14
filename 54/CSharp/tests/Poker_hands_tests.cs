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
        public void One_pair_vs_hight_card()
        {
            var result = Round.Judge("5H 8C 6S 2S 2D AC KS QS TD 9D");
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
            var result = Round.Judge("2S 2D 2K 3D 4D AD AC KS KH QC");
            Assert.True(result == 1);
        }
        
        [Fact]
        public void Straight_vs_three_of_kind()
        {
            var result = Round.Judge("2C 3D 4D 5H 6D AD AC AS KH QC");
            Assert.True(result == 1);
        }
        
        [Fact]
        public void flash_vs_straight()
        {
            var result = Round.Judge("2D 4D 5D 7D 8D AD AC AS KH QC");
            Assert.True(result == 1);
        }
        
        [Fact]
        public void Full_house_vs_flash()
        {
            var result = Round.Judge("2D 2S 2H 3D 3C AD 9D KD 7D 6D");
            Assert.True(result == 1);
        }
        
        [Fact]
        public void Four_of_kind_vs_full_house()
        {
            var result = Round.Judge("2D 2S 2H 2D 3C AD AD KD KC AD");
            Assert.True(result == 1);
        }
    }
}
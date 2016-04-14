
using System;
using System.Collections.Generic;
using System.Linq;
namespace Poker.models
{
    public class Hand {
        readonly IEnumerable<string> _cards = null;
        readonly string name = null;
        IDictionary<char, int>  Mapper = new Dictionary<char, int> {
             {'1',1}, {'2',2}, {'3',3}, {'4',4}, {'5',5}, {'6',6}, {'7',7}, {'8',8}, {'9',9}, {'T',10}, {'J',11}, {'Q',12}, {'K',13}, {'A',14}
        };
        
        public Hand(IEnumerable<string> cards) {
            if ( cards?.Count() != 5 ) {
                throw new Exception();
            }
            
            _cards = cards;
        }
        
        public double Weight {
            get {
                var cards = _cards.GroupBy(c => Mapper[c[0]], c=> 1);
                
                var heigh_card_weight = cards
                                        .Select(c => c.Key * Math.Pow(100, c.Count() ))
                                        .Max();
                                        
                var two_2_pairs_weight =  cards.Count(g => g.Count()==2) * 140000;
                var flush_weight  = IsFlush(_cards) ?  Math.Pow(100, 3) * 14 + 15 +14 : 0;
                var straight_weight  = IsStraight(_cards) ?  Math.Pow(100, 3) * 14 +16 + 15: 0;
                var full_house = cards.Count(g => g.Count()==2) * cards.Count(g => g.Count()==3) * Math.Pow(100, 3) * 14 +17 + 16;
                var straigh_flush = IsFlush(_cards) && IsStraight(_cards) ?  Math.Pow(100, 4) * 14 +14 : 0;
                
                return  heigh_card_weight + two_2_pairs_weight + flush_weight + straight_weight + full_house + straigh_flush;
            }
        }

        private bool IsStraight(IEnumerable<string> cards) {
            var nums = cards.Select(c => Mapper[c[0]]).OrderBy(c => c);
            return nums.Select( n=> n - nums.First()).Sum() == 10;
        }
        
        private bool IsFlush(IEnumerable<string> cards) {
           
            return cards.Select(h => h[1]).Distinct().Count() == 1;
        }
        
    }
}
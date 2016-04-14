
using System;
using System.Collections.Generic;
using System.Linq;
namespace Poker.models
{
    public class Hand {
        readonly IEnumerable<string> _cards = null;
        readonly string name = null;
        IDictionary<char, int>  Mapper = new Dictionary<char, int> {
            {'1',1},
            {'2',2},       
            {'3',3},
            {'4',4},            
            {'5',5},
            {'6',6},    
            {'7',7},
            {'8',8},   
            {'9',9},
            {'T',10},    
            {'J',11},
            {'Q',12}, 
            {'K',13},
            {'A',14}
        };
        
        public Hand(IEnumerable<string> cards) {
            
            if ( cards?.Count() != 5 ) {
                throw new Exception();
            }
            
            _cards = cards;
        }
        
        public double HeighCard {
            get {
                var  cards = _cards.GroupBy(c => Mapper[c[0]], c=> 1);
                var heigh_card_weight = cards.Select(c => c.Key * Math.Pow(100, c.Count() )).Max();
                var two_pairs_special_weight =  cards.Count(g => g.Count()==2) * 140000;
                var straing_special_weight = _cards.Select(h => h[1]).Distinct().Count() == 1 ?  Math.Pow(100, 3) * 14 +14 : 0;

                return  heigh_card_weight + two_pairs_special_weight + straing_special_weight;
                      ;
            }
        }
        
        
        
    }
}
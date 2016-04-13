
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
        
        public int HeighCard {
            get {
                return _cards.GroupBy(c => Mapper[c[0]]).Max(g => g.Key);
            }
        }
        
    }
}
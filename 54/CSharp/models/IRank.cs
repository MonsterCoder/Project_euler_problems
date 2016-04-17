using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.models
{
    public interface IRank
    {
        bool Match(string[] cards);
    } 
    
    public abstract class Rank : IRank {
        protected IDictionary<char, int>  Mapper = new Dictionary<char, int> {
             {'1',1}, {'2',2}, {'3',3}, {'4',4}, {'5',5}, {'6',6}, {'7',7}, {'8',8}, {'9',9}, {'T',10}, {'J',11}, {'Q',12}, {'K',13}, {'A',14}
        };
        
        public abstract  bool Match(string[] cards);
    }
    
    public class Royal_Flush: Straight_Flush {
        public override bool Match(string[] cards) {
            var values = cards.Select(c => Mapper[c[0]]).OrderByDescending(c=>c);
            return base.Match(cards) && values.First() == Mapper['A'];

        }
    }
    
    public class Straight_Flush: Straight {
        public override bool Match(string[] cards) {
            return base.Match(cards) && new Flush().Match(cards);
        }
    }
    
    public class Four_Of_Kinds: Rank {
        public override bool Match(string[] cards) {
            return cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==4) == 1;
        }
    }
    
    public class Full_House: Three_Of_Kinds {
        public override bool Match(string[] cards) {
            return base.Match(cards) && cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==2) == 1;
        }
    }
    
    public class Flush: Rank {
        public override bool Match(string[] cards) {
            return cards.Select(c => c[1]).Distinct().Count() == 1;
        }
    }  
    public class Straight: Rank {
        public override bool Match(string[] cards) {
            var values = cards.Select(c => Mapper[c[0]]).OrderByDescending(c=>c);
            return values.First() * 5 == values.Select((v, idx) => v+idx).Sum();
        }
    }
    
   public class Three_Of_Kinds: Rank {
        public override bool Match(string[] cards) {
            return cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==3) == 1;
        }
   }

   public class Two_Pairs: Rank {
        public override bool Match(string[] cards) {
            return  cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==2) == 2;
        }
   }
   
   public class One_Pair: Rank {
        public override bool Match(string[] cards) {
            var groups = cards.GroupBy(c => Mapper[c[0]], c=> 1);
            return   groups.Count(g => g.Count()==3) == 0 && groups.Count(g => g.Count()==2) == 2;
        }
   }
    
}
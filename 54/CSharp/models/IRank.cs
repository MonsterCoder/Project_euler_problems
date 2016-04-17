using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.models
{
    public interface IRank
    {
        long Score();
    } 
    
    public abstract class Rank : IRank {
        public const int BASE = 225;
        public const int DISTANCE = 6;
        
        protected IDictionary<char, int>  Mapper = new Dictionary<char, int> {
             {'1',1}, {'2',2}, {'3',3}, {'4',4}, {'5',5}, {'6',6}, {'7',7}, {'8',8}, {'9',9}, {'T',10}, {'J',11}, {'Q',12}, {'K',13}, {'A',14}
        };
        
        protected readonly IEnumerable<string> cards = null;
        protected readonly int order = 0;
        
        public Rank(string[] cards, int order) {
             this.cards = cards;
             this.order = order;
        }
        
        protected abstract bool Match();
        
        protected virtual int HighestValue { 
            get {
                return cards.GroupBy(c => Mapper[c[0]], c=> 1).OrderByDescending(c => c.Key * Math.Pow(15, c.Count())).First().Key;
                
            }
        }
        
        protected virtual double Remainder {
            get {
                return 0;
            }
        } 
        
        public virtual long Score() {
            if (Match() == false) {
                return 0;
            }
            
            return Convert.ToInt32(HighestValue * Math.Pow(BASE, order) + Remainder);
        }
    }
    
    public class Royal_Flush: Straight_Flush {
        public Royal_Flush(string[] cards, int order) : base(cards, order) {
            
        }
        
        protected override bool Match() {
            return base.Match() && HighestValue == Mapper['A'];
        }
        
    }
    
    public class Straight_Flush: Straight {
        public Straight_Flush(string[] cards, int order) : base(cards, order) {
            
        }
        
        protected override bool Match() {
            return base.Match() && cards.Select(c => c[1]).Distinct().Count() == 1;
        }
        
    }
    
    public class Four_Of_Kinds: Rank {
        
        public Four_Of_Kinds(string[] cards, int order) : base(cards, order) {
            
        }
        
        protected override bool Match() {
            return cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==4) == 1;
        }
        
        protected override double Remainder {
            get{
                 return cards.GroupBy(c => Mapper[c[0]], c=> 1).Where(g => g.Count()==1).First().Key;
            }
           
        }
    }
    
    public class Full_House: Three_Of_Kinds {
        public Full_House(string[] cards, int order) : base(cards, order) {
            
        }
        protected override bool Match() {
            return base.Match() && cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==2) == 1;
        }
        
       protected override double Remainder { 
           get{
             return cards.GroupBy(c => Mapper[c[0]], c=> 1).Where(g => g.Count()==2).First().Key;
               
           }
       }
    }
    
    public class Flush: Rank {
        
        public Flush(string[] cards, int order):base(cards, order) {
            
        }
        protected override bool Match() {
            return cards.Select(c => c[1]).Distinct().Count() == 1;
        }
        
       protected override double Remainder {
           get {
             return cards.Select(c => Mapper[c[0]]).OrderBy(c => c).Select((c,idx)=> c * Math.Pow(15, idx)).Sum();
               
           }
       }
    }  
    public class Straight: Rank {
       public Straight(string[] cards, int order):base(cards, order)  {
           
       }
       protected override bool Match() {
            return HighestValue * 5 == cards.Select(c => Mapper[c[0]]).Select((v, idx) => v+idx).Sum();
       }
        
       protected override double Remainder {
           get{
              return HighestValue;
           }

       }
    }
    
   public class Three_Of_Kinds: Rank {
       public Three_Of_Kinds(string[] cards, int order):base(cards, order){
           
       }
        protected override bool Match() {
            return cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==3) == 1 && cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==2) == 0;
        }
        
       protected override double Remainder  {
           get{
                return cards.GroupBy(c => Mapper[c[0]], c=> 1).Where(g => g.Count()==1).OrderBy(c => c.Key).Select((c,idx)=> c.Key * Math.Pow(15, idx)).Sum(); 
           }
       }
   }

   public class Two_Pairs: Rank {
       public Two_Pairs(string[] cards, int order):base(cards, order) {
           
       }
        protected override bool Match() {
            return  cards.GroupBy(c => Mapper[c[0]], c=> 1).Count(g => g.Count()==2) == 2;
        }
        
       protected override double Remainder {
           get {
               return cards.GroupBy(c => Mapper[c[0]], c=> 1).Where(g => g.Count()==2).OrderBy(c => c.Key).Select((c,idx)=> c.Key * Math.Pow(15, idx+3)).Sum()
            + cards.GroupBy(c => Mapper[c[0]], c=> 1).Where(g => g.Count()==1).OrderBy(c => c.Key).Select((c,idx)=> c.Key * Math.Pow(15, idx)).Sum();
           }

       }
   }
   
   public class One_Pair: Rank {
       public One_Pair(string[] cards, int order) : base(cards,order) {
           
       }
        protected override bool Match() {
            var groups = cards.GroupBy(c => Mapper[c[0]], c=> 1);
            return   groups.Count(g => g.Count()==3) == 0 && groups.Count(g => g.Count()==2) == 1;
        }
        
        protected override double Remainder {
            get{
                return  cards.GroupBy(c => Mapper[c[0]], c=> 1).Where(g => g.Count()==1).OrderBy(c => c.Key).Select((c,idx)=> c.Key * Math.Pow(15, idx)).Sum();
            }
       }
   }
    
}
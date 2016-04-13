
using System;

namespace PokerHands.models
{
    public class Hand {
        readonly string[] _cards = null;
        readonly string name = null;
        
        public Hand(string[] cards) {
            if ( cards?.Length != 5 ) {
                throw new Exception();
            }
            _cards = cards;
        }
        
    }
}
using System;
using System.Linq;

namespace Poker.models
{
    public class Round {
            
        // return 1 if player wins, otherwise return 0;
        public static int Judge(string hands) {
            var cards = hands.Split(' ');
            var _player1 = new Hand(cards.Take(5));
            var _player2 = new Hand(cards.Skip(5).Take(5));
            
            return _player1.HeighCard > _player2.HeighCard ? 1 : 0;
        }
    }
}
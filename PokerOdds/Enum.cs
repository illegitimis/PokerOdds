using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerOdds
{
    public enum Color : int { Club = 0, Diamond = 1, Spade = 2, Heart = 3 }
    //
    public enum Face : int { Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14 }
    //
    public enum PokerHandType
    {
        StraightFlush
        ,
        FourOfAKind
        ,
        FullHouse
        ,
        Flush
        ,
        Straight
        ,
        ThreeOfAKind
        ,
        TwoPair
        ,
        Pair
        ,
        /// <summary>
        /// kickers
        /// </summary>
        HighCard,        
    }



    #region codeProject
    // 
    enum SUIT { None, Diamonds, Hearts, Clubs, Spades }
    enum RANK
    {
        None, Ace, Two, Three, Four, Five, Six, Seven, Eight,
        Nine, Ten, Jack, Queen, King
    }
    enum POKERSCORE
    {
        None, JacksOrBetter, TwoPair, ThreeOfAKind,
        Straight, Flush, FullHouse, FourOfAKind, StraightFlush,
        RoyalFlush
    }
    #endregion
}

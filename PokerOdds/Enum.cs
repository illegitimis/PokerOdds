using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerOdds
{
    public enum Color : byte { Club = 0, Diamond = 1, Spade = 2, Heart = 3 }
    //
    public enum Face : byte { Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14 }
    //
    public enum PokerHandType : byte
    {
        RoyalFlush = 11 //new
            ,
        StraightFlush = 10
            ,
        SteelWheel = 9// new
        ,
        FourOfAKind = 8
        ,
        FullHouse = 7
        ,
        Flush = 6
        ,
        Straight = 5
            ,
        Wheel = 4// new
        ,
        ThreeOfAKind = 3
        ,
        TwoPair = 2
        ,
        Pair = 1
        ,
        /// <summary>
        /// kickers
        /// </summary>
        HighCard = 0,
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

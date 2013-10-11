using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerOdds
{
    /// <summary>
    /// The first thing to mention is definitely that there are no extra cards. 
    /// Poker hands are evaluated with exactly five cards. 
    /// Sometimes you use all five community cards as your best hand, in which 
    /// case your pocket is useless (bluffing aside, of course). So strike that 
    /// right away: if you can't beat your opponent with five cards, you've lost (or tied).
    /// </summary>
#if DEBUG
    [DebuggerDisplay("{c1}|{c2}|{c3}|{c4}|{c5}")]
#endif
    public class Hand5 : IEnumerable<Card>
    {
        public Card c1 { get; /*private*/ set; }
        public Card c2 { get; set; }
        public Card c3 { get; set; }
        public Card c4 { get; set; }
        public Card c5 { get; set; }

        public Hand5 ()  {}
        // ints must be sorted ?
        public Hand5 (int i1, int i2, int i3, int i4, int i5)  
        {
            c1=i1; c2=i2; c3=i3; c4=i4; c5=i5;
        }
        public Hand5(Card i1, Card i2, Card i3, Card i4, Card i5)
        {
            c1 = i1; c2 = i2; c3 = i3; c4 = i4; c5 = i5;
        }
        IEnumerable<Card> GetPokerHand
        {
            get{
            yield return c1;
            yield return c2;
            yield return c3;
            yield return c4;
            yield return c5;
            }
        }
        //
        IEnumerable<Face> GetFaces() {return GetPokerHand.Select(c => c.Face); } 
        IEnumerable<Color> GetSuits() { return GetPokerHand.Select(c => c.Color); } 
        //
        /// <summary>
    /// The next step is to evaluate the hands. It starts like this:
    ///Does any single player have a STRAIGHT FLUSH? If yes, he is the winner.
    ///Do multiple players have a straight flush? If yes, the winner is the one with the highest card. 
    ///If multiple people share the highest card (obviously in a different suit) they split the pot. 
    ///(Note: Royal flush is excluded because it's just a special straight flush that no one else can beat.)
    ///Does any single player have 4 OF A KIND? If yes, he is the winner.
    ///Do multiple players have 4 of a kind? If yes, the one with the highest 'set of 4' is the winner. 
    ///If multiple players have the highest set of 4 (which is not achievable with a standard poker deck, 
    ///but is with a double deck or community cards), the one with the highest kicker 
    ///(highest card not in the set of 4) is the winner. If this card is the same, they split the pot.
    ///Does any single player have a FULL HOUSE? If yes, he is the winner.
    ///Do multiple players have full houses? If yes, then keeping in mind that a full house is a 3-set and a 2-set,
    ///the player with the highest 3-set wins the pot. If multiple players share the highest 3-set 
    ///(which isn't possible without community cards like in hold 'em, or a double deck) 
    ///then the player with the highest 2-set is the winner. 
    ///If the 2-set and 3-set is the same, those players split the pot.
    ///Does any single player have a FLUSH? If yes, he is the winner.
    ///Do multiple players have a flush? If yes, the player with a flush with the highest unique card is the winner. 
    ///This hand is similar to 'high card' resolution, where each card is effectively a kicker. 
    ///Note that a flush requires the same suit, not just color. While the colors used on the suit are red and black,
    ///two each, there's nothing to that connection. A club is no more similar to a spade than it is to a heart 
    ///- only suit matters. The colors are red and black for historical purposes and so the same deck can be played 
    ///for other games where that might matter. A player who has TS JS QS KS AC has a hand that looks great but 
    ///is really just ace high... :)
    ///Does any single player have a STRAIGHT? If yes, he wins the pot.
    ///Do multiple players have straights? If so, the player with the highest straight wins. 
    ///(a-2-3-4-5 is the lowest straight, while 10-j-q-k-a is the highest straight.) 
    ///If multiple players share the highest straight, they split the pot.
    ///Does any single player have a 3 OF A KIND? If yes, he wins the pot.
    ///Do multiple players have 3 of a kind? If yes, the player with the highest 3-set wins the pot. 
    ///If multiple players have the highest 3-set, the player with the highest kicker wins the pot. 
    ///If multiple players tie for highest 3-set and highest kicker, the player with the next highest 
    ///kicker wins the pot. If the players tie for the highest 3-set, highest kicker, 
    ///and highest second kicker, the players split the pot.
    ///Does any single player have 2-PAIR? If yes, he wins the pot.
    ///Do multiple players have 2-pair? If yes, the player with the highest pair wins the pot. 
    ///If multiple players tie for the highest pair, the player with the second highest pair wins the pot. 
    ///If multiple players tie for both pairs, the player with the highest kicker wins the pot. 
    ///If multiple players tiw for both pairs and the kicker, the players split the pot.
    ///Does any single player have a pair? If yes, he wins the pot.
    ///Do multiple players have A PAIR? If yes, the player with the highest pair win. 
    ///If multiple players have the highest pair, the player with the highest kicker wins. 
    ///Compare second and third kickers as expected to resolve conflicts, or split if all three kickers tie.
    ///At this point, all cards are kickers, so compare the first, second, third, fourth, and if necessary, 
    ///fifth highest cards in order until a winner is resolved, or split the pot if the hands are identical.
    /// </summary>
        public PokerHandType PokerHandType
        {
            get
            {
                if (IsStraightFlush)
                    return PokerHandType.StraightFlush;
                else
                {
                    if (Is4OfAKind)
                        return PokerHandType.FourOfAKind;
                    else
                    {
                        if (IsFullHouse)
                            return PokerHandType.FullHouse;
                        else
                        {
                            if (IsFlush)
                                return PokerHandType.Flush;
                            else
                            {
                                if (IsStraight)
                                    return PokerHandType.Straight;
                                else
                                {
                                    if (Is3OfAKind)
                                        return PokerHandType.ThreeOfAKind;
                                    else
                                    {
                                        if (IsTwoPair)
                                            return PokerOdds.PokerHandType.TwoPair;
                                        else
                                        {
                                            if (IsOnePair)
                                                return PokerOdds.PokerHandType.Pair;
                                            else
                                                return PokerHandType.HighCard;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //
        #region IEnumerable<Card> Members

        public IEnumerator<Card> GetEnumerator() { return GetPokerHand.GetEnumerator(); }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion

        #region poker hand prvt props
        //10
        bool IsOnePair
        {
            get
            {
                return IsPair(c1, c2) ||
                    IsPair(c1, c3) ||
                    IsPair(c1, c4) ||
                    IsPair(c1, c5) ||
                    IsPair(c2, c3) ||
                    IsPair(c2, c4) ||
                    IsPair(c2, c5) ||
                    IsPair(c3, c4) ||
                    IsPair(c3, c5) ||
                    IsPair(c4, c5)
                    ;
            }
        }
        //10
        bool Is3OfAKind
        {
            get
            {
                return IsAll3(c1, c2, c3) ||
                    IsAll3(c1, c2, c4) ||
                    IsAll3(c1, c2, c5) ||
                    IsAll3(c1, c3, c4) ||
                    IsAll3(c1, c3, c5) ||
                    IsAll3(c1, c4, c5) ||
                    IsAll3(c2, c3, c4) ||
                    IsAll3(c2, c3, c5) ||
                    IsAll3(c2, c4, c5) ||
                    IsAll3(c3, c4, c5)
                    ;
            }
        }
        //5
        bool Is4OfAKind
        {
            get
            {
                return IsAll4(c1, c2, c3, c4) ||
                    IsAll4(c1, c2, c3, c5) ||
                    IsAll4(c1, c2, c4, c5) ||
                    IsAll4(c1, c3, c4, c5) ||
                    IsAll4(c5, c2, c3, c4)
                    ;
            }
        }
        //10
        bool IsFullHouse
        {
            get
            {
                return (IsPair(c1, c2) && IsAll3(c3, c4, c5)) ||
             (IsPair(c1, c3) && IsAll3(c2, c4, c5)) ||
             (IsPair(c1, c4) && IsAll3(c2, c3, c5)) ||
             (IsPair(c1, c5) && IsAll3(c3, c4, c2)) ||
             (IsPair(c2, c3) && IsAll3(c1, c4, c5)) ||
             (IsPair(c2, c4) && IsAll3(c3, c1, c5)) ||
             (IsPair(c2, c5) && IsAll3(c3, c4, c1)) ||
             (IsPair(c3, c4) && IsAll3(c1, c2, c5)) ||
             (IsPair(c3, c5) && IsAll3(c1, c4, c2)) ||
             (IsPair(c4, c5) && IsAll3(c1, c2, c3));
            }
        }

        bool IsTwoPair
        {
            get
            {
                return (IsPair(c1, c2) && IsPair(c3, c4, c5)) ||
             (IsPair(c1, c3) && IsPair(c2, c4, c5)) ||
             (IsPair(c1, c4) && IsPair(c2, c3, c5)) ||
             (IsPair(c1, c5) && IsPair(c3, c4, c2)) ||
             (IsPair(c2, c3) && IsPair(c1, c4, c5)) ||
             (IsPair(c2, c4) && IsPair(c3, c1, c5)) ||
             (IsPair(c2, c5) && IsPair(c3, c4, c1)) ||
             (IsPair(c3, c4) && IsPair(c1, c2, c5)) ||
             (IsPair(c3, c5) && IsPair(c1, c4, c2)) ||
             (IsPair(c4, c5) && IsPair(c1, c2, c3));
            }
        }
        //5
        bool IsFlush { get { return IsSuit5(c1, c2, c3, c4, c5); }
        }
        bool IsStraight
        {
            get
            {
                if (!IsOnePair)
                {
                    var seq = GetFaces().Select(f => (int)f);
                    int m = seq.Min();
                    int M = seq.Max();
                    return (M - m == 4);
                }
                else
                    return false;
            }
        }
        bool IsStraightFlush { get { return IsFlush && IsStraight; } } 
        #endregion
        
        #region poker hand static utils
        //---
        private static bool IsPair(Card a, Card b) { return a.Face == b.Face; }
        private static bool IsPair(Card x, Card y, Card z) { return IsPair(x, y) || IsPair(z, x) || IsPair(z, y); }
        private static bool IsAll3(Card x, Card y, Card z) { return IsPair(x, y) && IsPair(y, z); }
        private static bool IsAll4(Card x, Card y, Card z, Card t) { return IsAll3(x, y, z) && IsPair(z, t); }
        //
        private static bool IsSuit(Card x, Card y) { return x.Color == y.Color; }
        private static bool IsSuit3(Card x, Card y, Card z) { return IsSuit(x, y) && IsSuit(y, z); }
        private static bool IsSuit5(Card x, Card y, Card z, Card t, Card u) { return IsSuit3(x, y, z) && IsSuit3(z, t, u); }
        
        #endregion

        /// <summary>
        /// 52 base number with 5 digits, a digit is 0:51
        /// </summary>
        /// <remarks>
        /// intmax    = 2147483647
        /// 52basemax = 380204031 (52^5-1)
        /// </remarks>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var oe = GetPokerHand.OrderBy(c => c.Index);
            return oe.Aggregate(0, (acc, card) => 13 * acc + card.Index);
        }

        //13*x+8 : 13*x+12, x = 0:3 
        //frequency: 4
        public static IEnumerable<Hand5> AllRoyalFlushes ()
        {
            for (int x = 0; x < 4; x++)
            {
                int i1 = 13 * x + 8;
                int i2 = i1+1;
                int i3 = i2 + 1;
                int i4 = i3 + 1;
                int i5 = i4 + 1;
                yield return new Hand5(i1, i2, i3, i4, i5);
            }
        }

        // [0 1 2 3 4] : [8 9 10 11 12] 
        // frequency: 32 
        public static IEnumerable<Hand5> AllStraightFlushes()
        { //up to 8 to avoid rf
            for (int d = 0; d < 8; d++)
            { 
            for (int x = 0; x < 4; x++)
            {
                int i1 = 13 * x + d;
                int i2 = i1 + 1;
                int i3 = i2 + 1;
                int i4 = i3 + 1;
                int i5 = i4 + 1;
                yield return new Hand5(i1, i2, i3, i4, i5);
            }
            }
        }

        // [0 1 2 3 12] <-> [A 2 3 4 5]
        // frequency: 4 
        public static IEnumerable<Hand5> AllSteelWheels()
        {
            for (int x = 0; x < Defines.SUITS_LENGTH; x++)
            {
                int i1 = 13 * x;
                int i2 = i1 + 1;
                int i3 = i2 + 1;
                int i4 = i3 + 1;
                int i5 = i4 + 9;
                yield return new Hand5(i1, i2, i3, i4, i5);
            }
        }

        // 624
        public static IEnumerable<Hand5> Squares()
        {
            // pick 4 of a kind value
            for (int k = 0; k < Defines.RANK_LENGTH; k++)
            {
                int v1 = k;
                int v2 = v1 + Defines.RANK_LENGTH;
                int v3 = v2 + Defines.RANK_LENGTH;
                int v4 = v3 + Defines.RANK_LENGTH;
                //pick the fifth card 
                for (int x = 0; x < Defines.DECK_LENGTH; x++)
                {
                    if (x != v1 && x!=v2 && x!=v3 && x!=v4)
                    yield return new Hand5(v1, v2, v3, v4, x);
                }
            }           
        }

        // fqc: 3744 = 13*12*24
        public static IEnumerable<Hand5> AllFullHouses()
        {
            // pick value with 3 occurences
            for (int a = 0; a < Defines.RANK_LENGTH; a++)
            { // 3 out of 4 (012,013,023,123)
                int a1 = a;
                int a2 = a1 + Defines.RANK_LENGTH;
                int a3 = a2 + Defines.RANK_LENGTH;
                int a4 = a3 + Defines.RANK_LENGTH;
                // pick value with 2 occurences
                for (int b = 0; b < Defines.RANK_LENGTH; b++)
                { // 2 out of 4 = 6
                    if (b == a)
                        continue;
                    int b1 = b;
                    int b2 = b1 + Defines.RANK_LENGTH;
                    int b3 = b2 + Defines.RANK_LENGTH;
                    int b4 = b3 + Defines.RANK_LENGTH;
                    //
                    yield return new Hand5(a1, a2, a3, b1, b2);
                    yield return new Hand5(a1, a2, a3, b1, b3);
                    yield return new Hand5(a1, a2, a3, b1, b4);
                    yield return new Hand5(a1, a2, a3, b2, b3);
                    yield return new Hand5(a1, a2, a3, b2, b4);
                    yield return new Hand5(a1, a2, a3, b3, b4);
                    //
                    yield return new Hand5(a1, a2, a4, b1, b2);
                    yield return new Hand5(a1, a2, a4, b1, b3);
                    yield return new Hand5(a1, a2, a4, b1, b4);
                    yield return new Hand5(a1, a2, a4, b2, b3);
                    yield return new Hand5(a1, a2, a4, b2, b4);
                    yield return new Hand5(a1, a2, a4, b3, b4);
                    //
                    yield return new Hand5(a1, a3, a4, b1, b2);
                    yield return new Hand5(a1, a3, a4, b1, b3);
                    yield return new Hand5(a1, a3, a4, b1, b4);
                    yield return new Hand5(a1, a3, a4, b2, b3);
                    yield return new Hand5(a1, a3, a4, b2, b4);
                    yield return new Hand5(a1, a3, a4, b3, b4);
                    //
                    yield return new Hand5(a2, a3, a4, b1, b2);
                    yield return new Hand5(a2, a3, a4, b1, b3);
                    yield return new Hand5(a2, a3, a4, b1, b4);
                    yield return new Hand5(a2, a3, a4, b2, b3);
                    yield return new Hand5(a2, a3, a4, b2, b4);
                    yield return new Hand5(a2, a3, a4, b3, b4);
                }
            }
        }

        // 5108
        public static IEnumerable<Hand5> AllFlushes()
        {
            // pick color
            for (int k = 0; k < Defines.SUITS_LENGTH; k++)
            {
                for (int a = 0; a < Defines.RANK_LENGTH-4; a++)
                {
                    for (int b = a+1; b < Defines.RANK_LENGTH - 3; b++)
                    {
                        for (int c = b + 1; c < Defines.RANK_LENGTH - 2; c++)
                        {
                            for (int d = c + 1; d < Defines.RANK_LENGTH - 1; d++)
                            {
                                for (int e = d + 1; e < Defines.RANK_LENGTH; e++)
                                {
                                    if (e-a>4 && !(a==0 && b==1 && c==2 && d==3 && e==12))
                                        yield return new Hand5(13 * k + a, 13 * k + b, 13 * k + c, 13 * k + d, 13 * k + e);
                                }
                            }
                        }
                    }
                }                
            }
        }

        //9180
        public static IEnumerable<Hand5> AllStraights()
        {   //starting digit
            // up to 9 means max smallest card is 10
            for (int d = 0; d < 9; d++)
            { // loop on each suit
                for (int x = 0; x < Defines.SUITS_LENGTH; x++)
                    for (int y = 0; y < Defines.SUITS_LENGTH; y++)
                        for (int z = 0; z < Defines.SUITS_LENGTH; z++)
                            for (int t = 0; t < Defines.SUITS_LENGTH; t++)
                                for (int u = 0; u < Defines.SUITS_LENGTH; u++)
                {
                    int i1 = 13 * x + d;
                    int i2 = 13 * y + d+1;
                    int i3 = 13*z + d+2;
                    int i4 = 13*t + d+3;
                    int i5 = 13*u + d+4;
                    if (!(x==y && y==z && z==t && t==u))
                        yield return new Hand5(i1, i2, i3, i4, i5);
                }
            }
        }
        //1020
        public static IEnumerable<Hand5> AllWheels()
        {
            for (int x = 0; x < Defines.SUITS_LENGTH; x++)
                for (int y = 0; y < Defines.SUITS_LENGTH; y++)
                    for (int z = 0; z < Defines.SUITS_LENGTH; z++)
                        for (int t = 0; t < Defines.SUITS_LENGTH; t++)
                            for (int u = 0; u < Defines.SUITS_LENGTH; u++)
                            {
                                int i1 = 13 * x;
                                int i2 = 13 * y + 1;
                                int i3 = 13 * z + 2;
                                int i4 = 13 * t + 3;
                                int i5 = 13 * u + 12;
                                if (!(x == y && y == z && z == t && t == u))
                                    yield return new Hand5(i1, i2, i3, i4, i5);
                            }
        }

        // fqc: 54,912
        public static IEnumerable<Hand5> All3OfAKind()
        {
            // pick value with 3 occurences
            for (int a = 0; a < Defines.RANK_LENGTH; a++)
            { // 3 out of 4 (012,013,023,123)
                int a1 = a;
                int a2 = a1 + Defines.RANK_LENGTH;
                int a3 = a2 + Defines.RANK_LENGTH;
                int a4 = a3 + Defines.RANK_LENGTH;
                // pick the other 2 values
                for (int b = 0; b < Defines.DECK_LENGTH-1; b++)
                {
                    if (b == a1 || b == a2 || b == a3 || b == a4)
                        continue;
                    for (int c = b+1; c < Defines.DECK_LENGTH; c++)
                    {
                        if (c == a1 || c == a2 || c == a3 || c == a4 || (c-b)%13==0)
                            continue;
                        //
                        yield return new Hand5(a1, a2, a3, b, c);
                        yield return new Hand5(a1, a2, a4, b, c);
                        yield return new Hand5(a1, a3, a4, b, c);
                        yield return new Hand5(a2, a3, a4, b, c);
                    }
                }
            }
        }

        // fqc: 123,552
        public static IEnumerable<Hand5> All2Pairs()
        {
            // pick smaller pair value
            for (int b = 0; b < Defines.RANK_LENGTH - 1; b++)
            { // get 2 out of 4 possible values
                int v1 = b;
                int v2 = v1+Defines.RANK_LENGTH;
                int v3 = v2 + Defines.RANK_LENGTH;
                int v4 = v3 + Defines.RANK_LENGTH;
                // pick larger pair value
                for (int c = b + 1; c < Defines.RANK_LENGTH; c++)
                {
                    int u1 = c;
                    int u2 = u1 + Defines.RANK_LENGTH;
                    int u3 = u2 + Defines.RANK_LENGTH;
                    int u4 = u3 + Defines.RANK_LENGTH;   
                    // get off card
                    for (int o = 0; o < Defines.DECK_LENGTH; o++)
                    {
                        if (o == v1 || o == v2 || o == v3 || o == v4 ||
                            o == u1 || o == u2 || o == u3 || o == u4)
                            continue;
                        //
                        yield return new Hand5(v1, v2, u1, u2, o);
                        yield return new Hand5(v1, v2, u1, u3, o);
                        yield return new Hand5(v1, v2, u1, u4, o);
                        yield return new Hand5(v1, v2, u2, u3, o);
                        yield return new Hand5(v1, v2, u2, u4, o);
                        yield return new Hand5(v1, v2, u3, u4, o);
                        //
                        yield return new Hand5(v1, v3, u1, u2, o);
                        yield return new Hand5(v1, v3, u1, u3, o);
                        yield return new Hand5(v1, v3, u1, u4, o);
                        yield return new Hand5(v1, v3, u2, u3, o);
                        yield return new Hand5(v1, v3, u2, u4, o);
                        yield return new Hand5(v1, v3, u3, u4, o);
                        //
                        yield return new Hand5(v1, v4, u1, u2, o);
                        yield return new Hand5(v1, v4, u1, u3, o);
                        yield return new Hand5(v1, v4, u1, u4, o);
                        yield return new Hand5(v1, v4, u2, u3, o);
                        yield return new Hand5(v1, v4, u2, u4, o);
                        yield return new Hand5(v1, v4, u3, u4, o);
                        //
                        yield return new Hand5(v2, v3, u1, u2, o);
                        yield return new Hand5(v2, v3, u1, u3, o);
                        yield return new Hand5(v2, v3, u1, u4, o);
                        yield return new Hand5(v2, v3, u2, u3, o);
                        yield return new Hand5(v2, v3, u2, u4, o);
                        yield return new Hand5(v2, v3, u3, u4, o);
                        //
                        yield return new Hand5(v2, v4, u1, u2, o);
                        yield return new Hand5(v2, v4, u1, u3, o);
                        yield return new Hand5(v2, v4, u1, u4, o);
                        yield return new Hand5(v2, v4, u2, u3, o);
                        yield return new Hand5(v2, v4, u2, u4, o);
                        yield return new Hand5(v2, v4, u3, u4, o);
                        //
                        yield return new Hand5(v3, v4, u1, u2, o);
                        yield return new Hand5(v3, v4, u1, u3, o);
                        yield return new Hand5(v3, v4, u1, u4, o);
                        yield return new Hand5(v3, v4, u2, u3, o);
                        yield return new Hand5(v3, v4, u2, u4, o);
                        yield return new Hand5(v3, v4, u3, u4, o);
                    }
                }
            }            
        }

        // fqc:  	1,098,240
        public static IEnumerable<Hand5> All1Pairs()
        {
            // pick pair value
            for (int p = 0; p < Defines.RANK_LENGTH; p++)
            { // get 2 out of 4 possible values
                int v1 = p;
                int v2 = v1 + Defines.RANK_LENGTH;
                int v3 = v2 + Defines.RANK_LENGTH;
                int v4 = v3 + Defines.RANK_LENGTH;
             
                // get off cards
                for (int o1 = 0; o1 < Defines.DECK_LENGTH-2; o1++)
                {
                    if (o1 == v1 || o1 == v2 || o1 == v3 || o1 == v4) continue;
                    for (int o2 = o1+1; o2 < Defines.DECK_LENGTH-1; o2++)
                    {
                        if (o2 == v1 || o2 == v2 || o2 == v3 || o2 == v4 || (o2-o1)%13==0) continue;
                        for (int o3 = o2+1; o3 < Defines.DECK_LENGTH; o3++)
                        {
                            if (o3 == v1 || o3 == v2 || o3 == v3 || o3 == v4 || (o3 - o2) % 13 == 0 || (o3 - o1) % 13 == 0) continue;
                            //
                            yield return new Hand5(v1, v2, o1, o2, o3);
                            yield return new Hand5(v1, v3, o1, o2, o3);
                            yield return new Hand5(v1, v4, o1, o2, o3);
                            yield return new Hand5(v2, v3, o1, o2, o3);
                            yield return new Hand5(v2, v4, o1, o2, o3);
                            yield return new Hand5(v3, v4, o1, o2, o3);
                        }
                    }
                }
                
            }
        }
    }
}

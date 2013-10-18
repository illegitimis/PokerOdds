namespace PokerOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Hand3
    {
        public Card c1 { get; set; }
        public Card c2 { get; set; }
        public Card c3 { get; set; }

        public Hand3 (int i1, int i2, int i3)  { c1=i1; c2=i2; c3=i3; }
        public Hand3(Card i1, Card i2, Card i3) { c1 = i1; c2 = i2; c3 = i3; }

        public static IEnumerable<Hand3> LinqTriplets()
        {
            return LinqTriplets(new FullDeck());
        }

        public static IEnumerable<Hand3> LinqTriplets(IEnumerable<Card> fd)
        {
            var v = from x in fd
                    from y in fd
                    where y.GetHashCode() > x.GetHashCode()
                    from z in fd
                    where z.GetHashCode() > y.GetHashCode()
                    select new Hand3 (x, y, z );
            return v;

        }

        /// <summary>
        /// get distinct couples (omit transpositions), triangular matrix technique
        /// where each card taken from the <paramref name="fd"/> set
        /// </summary>
        /// <remarks> foreach call should proven to be faster than <see cref="LinqTriplets"/> in tests</remarks>
        /// <param name="fd">input card set to choose from</param>
        /// <returns>All distinct triplets out of a given set</returns>
        public static IEnumerable<Hand3> ForeachTriplets(IEnumerable<Card> cards)
        {
            foreach (var x in cards)
            {
                foreach (var y in cards)
                {
                    if (y.GetHashCode() > x.GetHashCode())
                    {
                        foreach (var z in cards)
                        {
                            if (z.GetHashCode() > y.GetHashCode())
                            {
                                yield return new Hand3(x,y,z) ;
                            }
                        }
                    }
                    
                }
            }
        }

    }

    public class Flop : Hand3 {
        public Flop (int i1, int i2, int i3)  : base (i1,i2,i3){}
        public Flop(Card i1, Card i2, Card i3) : base(i1, i2, i3) { }
    }

}

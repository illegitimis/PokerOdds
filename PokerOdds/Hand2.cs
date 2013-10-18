namespace PokerOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Hand2
    {
        public Card c1 { get; set; }
        public Card c2 { get; set; }

        public static IEnumerable<Hand2> LinqDoublets()
        {
            return LinqDoublets(new FullDeck());
        }

        /// <summary>
        /// get distinct couples (omit transpositions), triangular matrix technique
        /// where each card taken from the <paramref name="fd"/> set
        /// </summary>
        /// <remarks> foreach call should proven to be faster than <see cref="LinqDoublets"/> in tests</remarks>
        /// <param name="fd">input card set to choose from</param>
        /// <returns></returns>
        public static IEnumerable<Hand2> LinqDoublets(IEnumerable<Card> fd)
        {
            var v = from x in fd
                        from y in fd
                        where y.GetHashCode() > x.GetHashCode()
                    select new Hand2 { c1 = x, c2 = y };
            return v;

        }
        
        public static IEnumerable<Hand2> ForeachDoublets (IEnumerable<Card> cards)
        {
            foreach (var x in cards)
                foreach (var y in cards)
                    if (y.GetHashCode() > x.GetHashCode())
                        yield return new Hand2() { c1 = x, c2=y };
        }
        
    }

    public class PlayerHand : Hand2{}
}

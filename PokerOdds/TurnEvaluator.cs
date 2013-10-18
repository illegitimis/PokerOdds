using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerOdds
{
    public class TurnEvaluator : IEnumerable <Hand5>
    {
        public Hand5 Hand { get; private set; }
        public Card Turn { get; private set; }

        public TurnEvaluator(Hand5 h, Card t) { Hand = h; Turn = t; }
        public TurnEvaluator(Hand2 prvt, Hand3 flop, Card t) { Hand = new Hand5(prvt,flop); Turn = t; }

        public IEnumerable<Hand5> GetEnumeratorDescending() { return AllHands().OrderByDescending(x => x); }
        public Hand5 Max() { return AllHands().Max(); }

        #region IEnumerable<Hand5> Members

        public IEnumerable<Hand5> AllHands()
        {
            yield return Hand;
            yield return new Hand5(Hand.c1, Hand.c2, Hand.c3, Hand.c4, Turn);
            yield return new Hand5(Hand.c1, Hand.c2, Hand.c3, Hand.c5, Turn);
            yield return new Hand5(Hand.c1, Hand.c2, Hand.c4, Hand.c5, Turn);
            yield return new Hand5(Hand.c1, Hand.c3, Hand.c4, Hand.c5, Turn);
            yield return new Hand5(Hand.c2, Hand.c3, Hand.c4, Hand.c5, Turn);
        }
        public IEnumerator<Hand5> GetEnumerator() { return AllHands().GetEnumerator(); }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }

    public class RiverEvaluator : IEnumerable<Hand5>
    {
        public Hand5 Hand { get; private set; }
        public Card Turn { get; private set; }
        public Card River { get; private set; }
        public TurnEvaluator TurnEvaluator { get; private set; }

        public RiverEvaluator(Hand5 h, Card t, Card r) { Hand = h; Turn = t; River = r; TurnEvaluator = new TurnEvaluator(Hand, Turn); }
        public RiverEvaluator(Hand2 prvt, Hand3 flop, Card t, Card r) { Hand = new Hand5(prvt, flop); Turn = t; River = r; TurnEvaluator = new TurnEvaluator(Hand, Turn); }
        public RiverEvaluator(TurnEvaluator te, Card r) { TurnEvaluator = te; Hand = te.Hand; Turn = te.Turn; River = r; }

        public IEnumerable<Hand5> GetEnumeratorDescending() { return AllHands().OrderByDescending(x => x); }
        public Hand5 Max() { return AllHands().Max(); }

        #region IEnumerable<Hand5> Members

        public IEnumerable<Hand5> AllHands()
        {
            foreach (Hand5 h in TurnEvaluator.AllHands())
            {
                yield return h;
                yield return new Hand5(h.c1, h.c2, h.c3, h.c4, River);
                yield return new Hand5(h.c1, h.c2, h.c3, h.c5, River);
                yield return new Hand5(h.c1, h.c2, h.c4, h.c5, River);
                yield return new Hand5(h.c1, h.c3, h.c4, h.c5, River);
                yield return new Hand5(h.c2, h.c3, h.c4, h.c5, River);
            }
            
        }
        public IEnumerator<Hand5> GetEnumerator() { return AllHands().GetEnumerator(); }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}

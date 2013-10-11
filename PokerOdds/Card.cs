using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerOdds
{
#if DEBUG
    [DebuggerDisplay("{Index}")]
#endif
    public class Card : IEquatable<Card>, IEqualityComparer<Card>
    {
        public Color Color { get; private set; }
        public Face Face { get; private set; }
        public int Index { get; private set; }

        #region life
        public Card(Color color, Face face)
        {
            this.Color = color;
            this.Face = face;
            this.Index = (int)color * 13 + (int)face - 2;
        }

        public Card(int index)
        {
            this.Index = index;
            this.Color = (Color)(index / 13);
            this.Face = (Face)((index % 13) + 2);

        }
        #endregion

        #region IEquatable<Card> Members

        public bool Equals(Card other) { return (this.Color == other.Color && this.Face == other.Face); }

        #endregion

        #region IEqualityComparer<Card> Members

        public bool Equals(Card x, Card y)
        {
            return x.Equals(y);
        }
        /// <summary>
        /// 13 faces(2-14), 4 colors(0-based index), base 13 number
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>0-51 index</returns>
        public int GetHashCode(Card obj) { return this.Index; }

        #endregion

        public static bool operator == (Card one, Card two)
        {
            return one.Equals(two);
        }

        public static bool operator !=(Card one, Card two)
        {
            return ! one.Equals(two);
        }

        public override int GetHashCode() { return GetHashCode(this); }

        public override bool Equals(object obj)
        {
            return obj is Card ? Equals(this, obj as Card) : false;
        }

        public static implicit operator int(Card c) { return c.GetHashCode(); }
        public static implicit operator Card(int i) { return new Card (i); }

        public override string ToString()
        {
            return string.Format("I:{0,-2}C:{1,-6}F:{2,-7}",this.Index,this.Color,this.Face);
        }
    }
}

namespace PokerOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// full deck enumerator
    /// </summary>
    public class FullDeck : IEnumerable<Card>
    {
        /// <summary>
        /// slower than <see cref="GetFullDeckLoop"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<Card> GetFullDeckReflection()
        {
            foreach (var color in Defines.AllColors)
                foreach (var face in Defines.AllFaces)
                    yield return new Card (color, face);                 
        }

        IEnumerable<Card> GetFullDeckLoop()
        {
            for (int i = 0; i < Defines.DECK_LENGTH; i++ )
                yield return new Card(i);
        }

        #region IEnumerable<Card> Members

        public IEnumerator<Card> GetEnumerator()
        {
            return GetFullDeckLoop().GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();            
        }

        #endregion
    }
}

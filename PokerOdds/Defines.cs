using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerOdds
{
    public static class Defines
    {
        static readonly IDictionary<Face, char> FaceAbbreviations;
       
        public static readonly IEnumerable<Color> AllColors = (Color[])Enum.GetValues(typeof(Color));
        public static readonly IEnumerable<Face> AllFaces = (Face[])Enum.GetValues(typeof(Face));

        //
        public const int DECK_LENGTH = 52;
        public const int SUITS_LENGTH = 4;
        public const int RANK_LENGTH = 13;
        //

        public static readonly Card C2 = new Card(Color.Club, Face.Two);
        public static readonly Card C3 = new Card(Color.Club, Face.Three);
        public static readonly Card C4 = new Card(Color.Club, Face.Four);
        public static readonly Card C5 = new Card(Color.Club, Face.Five);
        public static readonly Card C6 = new Card(Color.Club, Face.Six);
        public static readonly Card C7 = new Card(Color.Club, Face.Seven);
        public static readonly Card C8 = new Card(Color.Club, Face.Eight);
        public static readonly Card C9 = new Card(Color.Club, Face.Nine);
        public static readonly Card CT = new Card(Color.Club, Face.Ten);
        public static readonly Card CJ = new Card(Color.Club, Face.Jack);
        public static readonly Card CQ = new Card(Color.Club, Face.Queen);
        public static readonly Card CK = new Card(Color.Club, Face.King);
        public static readonly Card CA = new Card(Color.Club, Face.Ace);
        //
        public static readonly Card D2 = new Card(Color.Diamond, Face.Two);
        public static readonly Card D3 = new Card(Color.Diamond, Face.Three);
        public static readonly Card D4 = new Card(Color.Diamond, Face.Four);
        public static readonly Card D5 = new Card(Color.Diamond, Face.Five);
        public static readonly Card D6 = new Card(Color.Diamond, Face.Six);
        public static readonly Card D7 = new Card(Color.Diamond, Face.Seven);
        public static readonly Card D8 = new Card(Color.Diamond, Face.Eight);
        public static readonly Card D9 = new Card(Color.Diamond, Face.Nine);
        public static readonly Card DT = new Card(Color.Diamond, Face.Ten);
        public static readonly Card DJ = new Card(Color.Diamond, Face.Jack);
        public static readonly Card DQ = new Card(Color.Diamond, Face.Queen);
        public static readonly Card DK = new Card(Color.Diamond, Face.King);
        public static readonly Card DA = new Card(Color.Diamond, Face.Ace);    
        //
        public static readonly Card S2 = new Card(Color.Spade, Face.Two);
        public static readonly Card S3 = new Card(Color.Spade, Face.Three);
        public static readonly Card S4 = new Card(Color.Spade, Face.Four);
        public static readonly Card S5 = new Card(Color.Spade, Face.Five);
        public static readonly Card S6 = new Card(Color.Spade, Face.Six);
        public static readonly Card S7 = new Card(Color.Spade, Face.Seven);
        public static readonly Card S8 = new Card(Color.Spade, Face.Eight);
        public static readonly Card S9 = new Card(Color.Spade, Face.Nine);
        public static readonly Card ST = new Card(Color.Spade, Face.Ten);
        public static readonly Card SJ = new Card(Color.Spade, Face.Jack);
        public static readonly Card SQ = new Card(Color.Spade, Face.Queen);
        public static readonly Card SK = new Card(Color.Spade, Face.King);
        public static readonly Card SA = new Card(Color.Spade, Face.Ace);
        //
        public static readonly Card H2 = new Card(Color.Heart, Face.Two);
        public static readonly Card H3 = new Card(Color.Heart, Face.Three);
        public static readonly Card H4 = new Card(Color.Heart, Face.Four);
        public static readonly Card H5 = new Card(Color.Heart, Face.Five);
        public static readonly Card H6 = new Card(Color.Heart, Face.Six);
        public static readonly Card H7 = new Card(Color.Heart, Face.Seven);
        public static readonly Card H8 = new Card(Color.Heart, Face.Eight);
        public static readonly Card H9 = new Card(Color.Heart, Face.Nine);
        public static readonly Card HT = new Card(Color.Heart, Face.Ten);
        public static readonly Card HJ = new Card(Color.Heart, Face.Jack);
        public static readonly Card HQ = new Card(Color.Heart, Face.Queen);
        public static readonly Card HK = new Card(Color.Heart, Face.King);
        public static readonly Card HA = new Card(Color.Heart, Face.Ace);
        
        //static readonly Card[] AllCards = new Card[]
        //{
        //    new Card () { Color= Color.Club, Face=Face.Two },
        //};
        
        static Defines()
        {
            FaceAbbreviations = new Dictionary<Face, char>()
            {
                {Face.Two,'2'} ,
                {Face.Three,'3'} ,
                {Face.Four,'4'} ,
                {Face.Five,'5'} ,
                {Face.Six,'6'} ,
                {Face.Seven,'7'} ,
                {Face.Eight,'8'} ,
                {Face.Nine,'9'} ,
                {Face.Ten,'T'} ,                
                {Face.Jack,'J'} ,
                {Face.Queen,'Q'} ,
                {Face.King,'K'} ,                
                {Face.Ace,'A'} ,
            };
        }
    }
}

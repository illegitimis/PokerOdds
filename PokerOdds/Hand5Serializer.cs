
namespace PokerOdds
{
    using System.Collections.Generic;
    using System.IO;
    using ProtoBuf;
    using System.Linq;

    /// <summary>
    /// fast binary serialization for content enrichment service data
    /// </summary>
    [ProtoContract]
    public class Hand5SerializableCollection
    {
        #region inner class
        /// <summary>
        /// <see cref="Hand5"/> wrapper with relevant info to serialize
        /// </summary>
        /// <remarks>
        /// DO NOT CHANGE THE ORDER OF PROTOMEMBER ATTRIBUTES!
        /// SHOULD ONE WISH TO ADD A MEMBER SIMPLY APPEND AT THE END
        /// INCREMENTING INDEX 
        /// <example>
        /// if last value is
        /// <code lang="C#">
        /// /// [ProtoMember(18, IsRequired = false)] public decimal[] DecimalListValue { get; set; }
        /// </code>    
        /// then:
        /// <code lang="C#">
        /// [ProtoMember(19, IsRequired = false)] public T YourNewValue { get; set; }
        /// </code>
        /// </example>
        /// </remarks>
        [ProtoContract]
        public sealed class Hand5Serializable
        {
            /// <summary>
            /// required value type
            /// </summary>
            [ProtoMember(1, IsRequired = true)]
            public PokerHandType Type { get; set; }

            /// <summary>
            /// the name of the property is required
            /// </summary>
            [ProtoMember(2, IsRequired = true)]
            public int HashCode { get; set; }
            
            [ProtoMember(3, IsRequired = true)]
            public string StringI { get; set; }

            [ProtoMember(4, IsRequired = true)]
            public string StringA { get; set; }
            
            /// <summary>
            /// rank code 
            /// </summary>
            [ProtoMember(5, IsRequired = false)]
            public int? RankCode { get; set; }
            /// <summary>
            /// rank within current class
            /// NON-REQUIRED TYPES MUST BE ALL NULLABLE!
            /// </summary>
            [ProtoMember(6, IsRequired = false)]
            public int? ClassRank { get; set; }    
       
            public static explicit operator Hand5Serializable (Hand5 h5)
            {
                return new Hand5Serializable()
                {
                    Type = h5.PokerHandType
                   ,
                    HashCode = h5.GetHashCode()
                   ,
                    StringA = h5.ToString("A")
                   ,
                    StringI = h5.ToString("I")
                    ,
                    RankCode = h5.GetRankCode()
                   ,
                    ClassRank = h5.ClassRank
                };
                
            }
        }
        #endregion

        #region exports
        /// <summary>
        /// optional property collection
        /// </summary>
        [ProtoMember(1, IsRequired = false)]
        public Hand5Serializable[] Hands { get; set; }
       
        #endregion

        public static void SerializeHand (string fileName, Hand5Serializable h5s)
        {
            using (var stream = File.Create(fileName))
            {
                Serializer.Serialize<Hand5Serializable>(stream, h5s);
            }
        }

        public static void SerializeHand(string fileName, Hand5 h5)
        {
            SerializeHand(fileName, (Hand5Serializable)h5);
        }

         public static Hand5Serializable DeserializeHand (string fileName)
         {
            using (var file = File.OpenRead(fileName)) 
            {
                return Serializer.Deserialize<Hand5Serializable>(file);
            }
         }

         public static void SerializeHands(string fn, IEnumerable<Hand5> hands)
         {
             var converted = hands.Select(h5 => (Hand5Serializable)h5);
             SerializeHands(fn, converted);
         }

         internal static void SerializeHands(string fn, IEnumerable<Hand5Serializable> srlzhands)
         {
             var h5sc = new Hand5SerializableCollection()
             {
                 Hands = srlzhands.ToArray()
             };
             SerializeHands(fn, h5sc);
         }

         public static void SerializeHands(string fn, Hand5SerializableCollection h5sc)
         {
             using (var stream = File.Create(fn))
             {
                 Serializer.Serialize<Hand5SerializableCollection>(stream, h5sc);
             }
         }

         public static Hand5SerializableCollection DeserializeHands(string fileName)
         {
             using (var file = File.OpenRead(fileName))
             {
                 return Serializer.Deserialize<Hand5SerializableCollection>(file);
             }
         }
    }
}


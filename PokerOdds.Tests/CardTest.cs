using PokerOdds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace PokerOdds.Tests
{
    
    
    /// <summary>
    ///This is a test class for CardTest and is intended
    ///to contain all CardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CardTest
    {

        const char Club = '♣';
        const char Diamond = '♦';
        const char Heart = '♥';
        const char Spade = '♠';

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ToString with no parameters
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Card cardD4 = new Card(Color.Diamond, Face.Four);
            string expected1 = new string(new char[] { '4', Diamond });
            Assert.AreEqual(expected1, cardD4.ToString());
            //
            Card card38 = new Card(38);
            string expected2 = new string(new char[] { 'A', Spade });
            Assert.AreEqual(expected2, card38.ToString());
            //
            string expected3 = new string(new char[] { 'K', Club });
            Assert.AreEqual(expected3, Defines.CK.ToString());            
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringATest()
        {
            Card cardD4 = new Card(Color.Diamond, Face.Four);
            string expected1 = new string(new char[] { '4', Diamond });
            Assert.AreEqual(expected1, cardD4.ToString("A"));
            //
            Card card38 = new Card(38);
            string expected2 = new string(new char[] { 'A', Spade });
            Assert.AreEqual(expected2, card38.ToString("A"));
            //
            string expected3 = new string(new char[] { 'K', Club });
            Assert.AreEqual(expected3, Defines.CK.ToString("A"));
        }

        [TestMethod()]
        public void ToStringITest()
        {
            Card cardD4 = new Card(Color.Diamond, Face.Four);
            string expected1 = "15";
            Assert.AreEqual(expected1, cardD4.ToString("I"));
            //
            Card card38 = new Card(38);
            string expected2 = "38";
            Assert.AreEqual(expected2, card38.ToString("I"));
            //
            string expected3 = "11";
            Assert.AreEqual(expected3, Defines.CK.ToString("I"));
        }

        [TestMethod()]
        public void ToStringVTest()
        {
            Card cardD4 = new Card(Color.Diamond, Face.Four);
            Card card38 = new Card(38);
            //
            string expected1 = "I:15 C:Diamond F: Four";
            string expected2 = "I:38 C:  Spade F:  Ace";            
            string expected3 = "I:11 C:   Club F: King";
            //
            Assert.AreEqual(expected1, cardD4.ToString("V"));
            Assert.AreEqual(expected2, card38.ToString("V"));
            Assert.AreEqual(expected3, Defines.CK.ToString("V"));
        }

        /// <summary>
        ///A test for ToString
        ///<remarks>
        /// index order: CJ d9 s7 h5 hk
        /// face/color order: 5h 7s 9d jc kh
        ///</remarks>
        ///</summary>
        [TestMethod()]
        public void Hand5_ToStringTest()
        {
            Hand5 h = new Hand5(Defines.H5, Defines.HK, Defines.S7, Defines.D9, Defines.CJ);
            string actual = h.ToString();
            string expected = new string(new char[] { '5', Heart, '7', Spade, '9', Diamond, 'J', Club, 'K', Heart });
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void Hand5_ToStringATest()
        {
            Hand5 h = new Hand5(Defines.H5, Defines.S7, Defines.D9, Defines.CJ, Defines.HK);
            string actual = h.ToString("A");
            string expected = new string(new char[] { '5', Heart, '7', Spade, '9', Diamond, 'J', Club, 'K', Heart });
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void Hand5_ToStringHTest()
        {
            Hand5 hSmallest = new Hand5(new Card(0), new Card(1), new Card(2), new Card(3), new Card(4));
            Hand5 hBiggest = new Hand5(new Card(47), new Card(48), new Card(49), new Card(50), new Card(51));
            //
            string actualS = hSmallest.ToString("H");
            string actualB = hBiggest.ToString("H");
            string expectedS = "000146176";
            string expectedB = "350530283";
            //
            Assert.AreEqual(actualS, expectedS);
            Assert.AreEqual(actualB, expectedB);
            //
            Random r = new Random();
            Hand5 hrand = new Hand5(r.Next(51), r.Next(51), r.Next(51), r.Next(51), r.Next(51));
            string actualR = hrand.ToString("H");
            Assert.IsTrue(string.CompareOrdinal ( actualR,expectedS) > 0);
            Assert.IsTrue(string.CompareOrdinal(actualR, expectedB) < 0);
        }

        [TestMethod()]
        public void Hand5_ToStringITest()
        {
            Hand5 h = new Hand5(new Card(20), new Card(30), new Card(50), new Card(40), new Card(10));
            string actual = h.ToString("I");
            string expected = "1020304050";
            Assert.AreEqual(actual, expected);
            //
            h = new Hand5(new Card(2), new Card(3), new Card(5), new Card(4), new Card(1));
            actual = h.ToString("I");
            expected = "0102030405";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void Hand5_serialize()
        {
            Hand5 h = new Hand5(new Card(20), new Card(30), new Card(50), new Card(40), new Card(10));
            string fn = "c1020304050.bin";
            Hand5SerializableCollection.SerializeHand(fn, h);
            FileInfo fi = new FileInfo (fn);
            Assert.IsTrue(fi.Exists && fi.Length > 0);
            //
            h = new Hand5(new Card(2), new Card(3), new Card(5), new Card(4), new Card(1));
            fn = "c0102030405.bin";
            var sa = h.ToString("A");
            var si = h.ToString("I");
            var h5s = new Hand5SerializableCollection.Hand5Serializable()
            {
                HashCode = h.GetHashCode()
                ,
                StringA = sa
                ,
                StringI = si
                ,
                CharA = sa.ToCharArray()
                ,
                CharI = si.ToCharArray()
                ,
                Type = h.PokerHandType
            };
            Hand5SerializableCollection.SerializeHand(fn, h5s);
            fi = new FileInfo(fn);
            Assert.IsTrue(fi.Exists && fi.Length > 0);
        }

        [TestMethod()]
        public void Hand5_deserialize()
        {
            string fn = @".\include\c1020304050.bin";
            var h5s = Hand5SerializableCollection.DeserializeHand (fn);
            Hand5 h = new Hand5(new Card(20), new Card(30), new Card(50), new Card(40), new Card(10));
            Assert.AreEqual(h5s.Type, h.PokerHandType);
            Assert.AreEqual(h5s.HashCode, h.GetHashCode());
            Assert.AreEqual(h5s.StringI, h.ToString("I"));
            Assert.AreEqual(h5s.StringA, h.ToString("A"));
            //
            h = new Hand5(new Card(2), new Card(3), new Card(5), new Card(4), new Card(1));
            fn = @".\include\c0102030405.bin";
            h5s = Hand5SerializableCollection.DeserializeHand(fn);
            Assert.AreEqual(h5s.Type, h.PokerHandType);
            Assert.AreEqual(h5s.HashCode, h.GetHashCode());
            Assert.AreEqual(h5s.StringI, h.ToString("I"));
            Assert.AreEqual(h5s.StringA, h.ToString("A"));
            CollectionAssert.AreEqual(h5s.CharI, h.ToString("I").ToCharArray());
            CollectionAssert.AreEqual(h5s.CharA, h.ToString("A").ToCharArray());
        }

        [TestMethod()]
        public void Hand5Collection_serialize()
        {
            Hand5[] hands = new Hand5[]
            {
                new Hand5(new Card(20), new Card(30), new Card(50), new Card(40), new Card(10))
                ,
                new Hand5(new Card(2), new Card(3), new Card(5), new Card(4), new Card(1))
            };
            string fn = "colection.bin";
            Hand5SerializableCollection.SerializeHands(fn, hands);
            FileInfo fi = new FileInfo(fn);
            Assert.IsTrue(fi.Exists && fi.Length > 0);                    
            //
            fn = "colection2.bin";
            var h5sc = new Hand5SerializableCollection()
            {
                Hands = hands.Select(h => new Hand5SerializableCollection.Hand5Serializable() 
                { Type=h.PokerHandType, HashCode = h.GetHashCode(), StringA = h.ToString("A"), StringI=h.ToString("I")}
                ).ToArray()
            };
            Hand5SerializableCollection.SerializeHands(fn, h5sc);
            fi = new FileInfo(fn);
            Assert.IsTrue(fi.Exists && fi.Length > 0);   
        }

        [TestMethod()]
        public void Hand5Collection_deserialize()
        {
            string fn = @".\include\colection.bin";
            var h5s = Hand5SerializableCollection.DeserializeHands(fn);
            Assert.IsNotNull(h5s);
            Assert.AreEqual(h5s.Hands.Length, 2);
            Assert.AreEqual(h5s.Hands[0].Type, PokerHandType.HighCard);
            Assert.AreEqual(h5s.Hands[1].Type, PokerHandType.StraightFlush);        
            
            //
            
        }
    }
}

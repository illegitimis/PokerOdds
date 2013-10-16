using PokerOdds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PokerOdds.Tests
{
    using PokerOdds;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;   
    
    /// <summary>
    ///This is a test class for Hand5Test and is intended
    ///to contain all Hand5Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Hand5Test
    {

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
        ///A test for /straights
        ///</summary>
        [TestMethod()]
        public void PokerHandTypeTest_NoStraight()
        {
            Hand5 h = new Hand5() { c1 = Defines.C2, c2 = Defines.D3, c3 = Defines.HA, c4 = Defines.S4, c5 = Defines.C5 };
            PokerHandTypeTest(h, PokerHandType.HighCard);
        }

        [TestMethod()]
        public void PokerHandTypeTest_Straight1()
        {
            Hand5 h = new Hand5() { c1 = Defines.C2, c2 = Defines.D3, c3 = Defines.H6, c4 = Defines.S4, c5 = Defines.C5 };
            PokerHandTypeTest(h, PokerHandType.Straight);
        }

        [TestMethod()]
        public void PokerHandTypeTest_Straight2()
        {
            Hand5 h = new Hand5() { c1 = Defines.C7, c2 = Defines.D8, c3 = Defines.H9, c4 = Defines.ST, c5 = Defines.CJ };
            PokerHandTypeTest(h, PokerHandType.Straight);
        }

        [TestMethod()]
        public void PokerHandTypeTest_Straight3()
        {
            Hand5 h = new Hand5() { c1 = Defines.CK, c2 = Defines.DJ, c3 = Defines.HQ, c4 = Defines.S9, c5 = Defines.CT };
            PokerHandTypeTest(h, PokerHandType.Straight);
        }
        ///////////////////////////////
        /// <summary>
        ///A test for 1 pair only
        ///</summary>
        [TestMethod()]
        public void PokerHandTypeTest_1Pair_2()
        {
            Hand5 h = new Hand5() { c1 = Defines.C2, c2 = Defines.D3, c3 = Defines.H6, c4 = Defines.S4, c5 = Defines.C2 };
            PokerHandTypeTest(h, PokerHandType.Pair);
        }
        [TestMethod()]
        public void PokerHandTypeTest_1Pair_3()
        {
            Hand5 h = new Hand5() { c1 = Defines.C2, c2 = Defines.D3, c3 = Defines.H6, c4 = Defines.S4, c5 = Defines.C3 };
            PokerHandTypeTest(h, PokerHandType.Pair);
        }
        [TestMethod()]
        public void PokerHandTypeTest_1Pair_6()
        {
            Hand5 h = new Hand5() { c1 = Defines.C2, c2 = Defines.D6, c3 = Defines.H6, c4 = Defines.S4, c5 = Defines.CT };
            PokerHandTypeTest(h, PokerHandType.Pair);
        }
        [TestMethod()]
        public void PokerHandTypeTest_1Pair_A()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.D3, c3 = Defines.H6, c4 = Defines.S4, c5 = Defines.SA };
            PokerHandTypeTest(h, PokerHandType.Pair);
        }
        /// <summary>
        /// 2 PAIR
        /// </summary>
        [TestMethod]
        public void PokerHandTypeTest_2Pair_36()
        {
            Hand5 h = new Hand5() { c1 = Defines.C3, c2 = Defines.D3, c3 = Defines.H6, c4 = Defines.S6, c5 = Defines.CT };
            PokerHandTypeTest(h, PokerHandType.TwoPair);
        }
        [TestMethod]
        public void PokerHandTypeTest_2Pair_47()
        {
            Hand5 h = new Hand5() { c1 = Defines.C4, c2 = Defines.D4, c3 = Defines.HK, c4 = Defines.S7, c5 = Defines.C7 };
            PokerHandTypeTest(h, PokerHandType.TwoPair);
        }
        [TestMethod]
        public void PokerHandTypeTest_2Pair_9J()
        {
            Hand5 h = new Hand5() { c1 = Defines.C3, c2 = Defines.DJ, c3 = Defines.H9, c4 = Defines.S9, c5 = Defines.CJ };
            PokerHandTypeTest(h, PokerHandType.TwoPair);
        }
        [TestMethod]
        public void PokerHandTypeTest_2Pair_KQ()
        {
            Hand5 h = new Hand5() { c1 = Defines.CK, c2 = Defines.DQ, c3 = Defines.H9, c4 = Defines.SQ, c5 = Defines.HK };
            PokerHandTypeTest(h, PokerHandType.TwoPair);
        }

        /// <summary>
        /// BRELAN
        /// </summary>
        [TestMethod]
        public void PokerHandTypeTest_3Pieces_A()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.DA, c3 = Defines.HA, c4 = Defines.SQ, c5 = Defines.HK };
            PokerHandTypeTest(h, PokerHandType.ThreeOfAKind);
        }
        [TestMethod]
        public void PokerHandTypeTest_3Kind_A()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c4 = Defines.DA, c5 = Defines.HA, c2 = Defines.SQ, c3 = Defines.HK };
            PokerHandTypeTest(h, PokerHandType.ThreeOfAKind);
        }
        [TestMethod]
        public void PokerHandTypeTest_3Pcs_T()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.D3, c3 = Defines.HT, c4 = Defines.ST, c5 = Defines.HT };
            PokerHandTypeTest(h, PokerHandType.ThreeOfAKind);
        }
        [TestMethod]
        public void PokerHandTypeTest_3Pcs_8()
        {
            Hand5 h = new Hand5() { c1 = Defines.C3, c2 = Defines.DT, c3 = Defines.HT, c4 = Defines.ST, c5 = Defines.H8 };
            PokerHandTypeTest(h, PokerHandType.ThreeOfAKind);
        }
        /// <summary>
        /// FULL HOUSE
        /// </summary>
        [TestMethod]
        public void PokerHandTypeTest_FH_1()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.DA, c3 = Defines.HA, c4 = Defines.ST, c5 = Defines.HT };
            PokerHandTypeTest(h, PokerHandType.FullHouse);
        }
        [TestMethod]
        public void PokerHandTypeTest_FH_2()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.DA, c4 = Defines.HA, c3 = Defines.ST, c5 = Defines.HT };
            PokerHandTypeTest(h, PokerHandType.FullHouse);
        }
        [TestMethod]
        public void PokerHandTypeTest_FH_3()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.DT, c3 = Defines.HT, c4 = Defines.SA, c5 = Defines.HA };
            PokerHandTypeTest(h, PokerHandType.FullHouse);
        }
        [TestMethod]
        public void PokerHandTypeTest_FH_4()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.DT, c3 = Defines.HA, c4 = Defines.ST, c5 = Defines.SA };
            PokerHandTypeTest(h, PokerHandType.FullHouse);
        }
        /// <summary>
        /// CAREU
        /// </summary>
        [TestMethod]
        public void PokerHandTypeTest_Square_1()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.DA, c3 = Defines.HA, c4 = Defines.SA, c5 = Defines.HT };
            PokerHandTypeTest(h, PokerHandType.FourOfAKind);
        }
        [TestMethod]
        public void PokerHandTypeTest_Square_2()
        {
            Hand5 h = new Hand5() { c5 = Defines.CA, c2 = Defines.DA, c3 = Defines.HA, c4 = Defines.SA, c1 = Defines.HT };
            PokerHandTypeTest(h, PokerHandType.FourOfAKind);
        }
        [TestMethod]
        public void PokerHandTypeTest_Square_3()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.DA, c5 = Defines.HA, c4 = Defines.SA, c3 = Defines.HT };
            PokerHandTypeTest(h, PokerHandType.FourOfAKind);
        }
        /// <summary>
        /// straight flush
        /// </summary>
        [TestMethod]
        public void PokerHandTypeTest_SF_1()
        {
            Hand5 h = new Hand5() { c1 = Defines.CA, c2 = Defines.CK, c3 = Defines.CQ, c4 = Defines.CJ, c5 = Defines.CT };
            PokerHandTypeTest(h, PokerHandType.StraightFlush);
        }
        [TestMethod]
        public void PokerHandTypeTest_SF_2()
        {
            Hand5 h = new Hand5() { c4 = Defines.CA, c2 = Defines.CK, c3 = Defines.CQ, c1 = Defines.CJ, c5 = Defines.CT };
            PokerHandTypeTest(h, PokerHandType.StraightFlush);
        }
        [TestMethod]
        public void PokerHandTypeTest_SF_3()
        {
            Hand5 h = new Hand5() { c3 = Defines.CA, c2 = Defines.CK, c1 = Defines.CQ, c5 = Defines.CJ, c4 = Defines.CT };
            PokerHandTypeTest(h, PokerHandType.StraightFlush);
        }
        /// <summary>
        /// the call
        /// </summary>
        /// <param name="target"></param>
        /// <param name="expected"></param>
        void PokerHandTypeTest(Hand5 target, PokerHandType expected)
        {
            Assert.AreEqual(expected, target.PokerHandType);
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void HashCodeTest1()
        {
            Hand5 target = new Hand5() { c1 = Defines.C2, c2 = Defines.D4, c3 = Defines.S6, c4 = Defines.H8, c5 = Defines.CT };
            int actual = target.GetHashCode();
            int expected = 45 + 30 * 13 + 15 * 13 * 13 + 8 * 13 * 13 * 13;
            Assert.AreEqual(expected, actual); 
            //

        }
        [TestMethod()]
        public void HashCodeTest2()
        {
            Hand5 target = new Hand5() { c1 = Defines.C2, c2 = Defines.C4, c3 = Defines.C6, c4 = Defines.C8, c5 = Defines.CT };
            int actual = target.GetHashCode();
            int expected = (int)(target.c1.Index * Math.Pow(13, 4) +
                target.c2.Index * Math.Pow(13, 3) +
                target.c3.Index * Math.Pow(13, 2) +
                target.c4.Index * Math.Pow(13, 1) +
                target.c5.Index); 
            Assert.AreEqual(expected, actual);
        }
        //
        [TestMethod()]
        public void RFTest()
        {
            var rfs = Hand5.AllRoyalFlushes();          
            Assert.AreEqual(rfs.Count(), 4);
            foreach (var rf in rfs)
                PokerHandTypeTest(rf, PokerHandType.StraightFlush);
        }

        [TestMethod()]
        public void All_SF_Test()
        {
            var rfs = Hand5.AllStraightFlushes();
            Assert.AreEqual(rfs.Count(), 32);
            foreach (var rf in rfs)
                PokerHandTypeTest(rf, PokerHandType.StraightFlush);
        }

        [TestMethod()]
        public void All_4K_Test()
        {
            var hands = Hand5.Squares();
            Assert.AreEqual(hands.Count(), 624);
            foreach (var h in hands)
                PokerHandTypeTest(h, PokerHandType.FourOfAKind);
        }

        [TestMethod()]
        public void All_FH_Test()
        {
            var hands = Hand5.AllFullHouses();
            Assert.AreEqual(hands.Count(), 3744);
            foreach (var h in hands)
                PokerHandTypeTest(h, PokerHandType.FullHouse);
        }
        [TestMethod()]
        public void All_Flushes_Test()
        {
            var hands = Hand5.AllFlushes();
            Assert.AreEqual(hands.Count(), 5108);
            foreach (var h in hands)
                PokerHandTypeTest(h, PokerHandType.Flush);
        }

        [TestMethod()]
        public void All_StraightsWheels_Test()
        {
            var hands1 = Hand5.AllStraights();
            int cnt1 = hands1.Count();
            var hands2 = Hand5.AllWheels();
            int cnt2 = hands2.Count();
            Assert.AreEqual(cnt1+cnt2, 10200);
            foreach (var h in hands1)
                PokerHandTypeTest(h, PokerHandType.Straight);
            foreach (var h in hands2)
                PokerHandTypeTest(h, PokerHandType.Wheel);
        }

        [TestMethod()]
        public void All_3K_Test()
        {
            var hands = Hand5.All3OfAKind();
            Assert.AreEqual(hands.Count(), 54912);
            foreach (var h in hands)
                PokerHandTypeTest(h, PokerHandType.ThreeOfAKind);
        }
        [TestMethod()]
        public void All_2P_Test()
        {
            var hands = Hand5.All2Pairs();
            Assert.AreEqual(hands.Count(), 123552);
            foreach (var h in hands)
                PokerHandTypeTest(h, PokerHandType.TwoPair);
        }
        [TestMethod()]
        public void All_1P_Test()
        {
            var hands = Hand5.All1Pairs();
            Assert.AreEqual(hands.Count(), 1098240 );
            foreach (var h in hands)
                PokerHandTypeTest(h, PokerHandType.Pair);
        }
        [TestMethod()]
        public void All_HighCards_Test()
        {
            var hands = Hand5.AllHighCards();
            Assert.AreEqual(hands.Count(), 1302540);
            foreach (var h in hands)
                PokerHandTypeTest(h, PokerHandType.HighCard);
        }
        [TestMethod()]
        public void All_PossibleHands_Test()
        {
            var hands = Hand5.AllPossibleHands();
            Assert.AreEqual(hands.Count(), 2598960);            
        }

    }
}

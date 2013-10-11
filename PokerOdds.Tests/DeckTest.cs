using PokerOdds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace PokerOdds.Tests
{
    
    
    /// <summary>
    ///This is a test class for DeckTest and is intended
    ///to contain all DeckTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DeckTest
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
        ///A test for FullDeck
        ///</summary>
        [TestMethod()]
        public void FullDeckTest()
        {
            var actual = new FullDeck();
            Assert.AreEqual(actual.Count(), 52);
            Assert.AreEqual(actual.First(), Defines.C2);
            Assert.AreEqual(actual.Reverse().First() , Defines.HA);            
        }

        /// <summary>
        ///A test for Deck Constructor
        ///</summary>
        [TestMethod()]
        public void DeckConstructorTest()
        {
            var target = new FullDeck();
            var cards = target as IEnumerable<Card>;
            Assert.IsNotNull(cards);
            Assert.AreEqual(cards.Count(), 52);
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            IEnumerator<Card> fullDeckEnum = (new FullDeck()).GetEnumerator();
            bool b = fullDeckEnum.MoveNext();
            Assert.IsTrue(b);
            Assert.AreEqual(fullDeckEnum.Current, Defines.C2);
            while (fullDeckEnum.MoveNext()) { }
            Assert.AreEqual(fullDeckEnum.Current, Defines.HA);    
        }
               
#if SPEED_TEST
         /// <summary>
        ///A test for GetEnumerator speed
        ///</summary>
        [TestMethod()]
        public void EnumeratorSpeedTest()
        {
            for (int k = 0; k < 5;k++ )
                EnumeratorSpeed();
        }

        private static void EnumeratorSpeed()
        {
            var fd = new FullDeck();
            var sw = Stopwatch.StartNew();
            Assert.AreEqual(fd.GetFullDeckLoop().Count(), 52);
            sw.Stop();
            Debug.WriteLine("Loop: {0}", sw.ElapsedTicks);
            sw = Stopwatch.StartNew();
            Assert.AreEqual(fd.GetFullDeckReflection().Count(), 52);
            sw.Stop();
            Debug.WriteLine("Enumvalues: {0}", sw.ElapsedTicks);
            
        }
#endif

    }
}

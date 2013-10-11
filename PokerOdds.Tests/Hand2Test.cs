using PokerOdds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace PokerOdds.Tests
{
    
    
    /// <summary>
    ///This is a test class for Hand2Test and is intended
    ///to contain all Hand2Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Hand2Test
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
        ///A test for GetUniqueTuples
        ///</summary>
        [TestMethod()]
        public void UniqueCouplesTest()
        {
            UniqueCouples();
            UniqueCouples();
            UniqueCouples();
            UniqueCouples();
            UniqueCouples();
        }

        [TestMethod()]
        public void UniqueTripletsTest()
        {
            UniqueTriplets();
            UniqueTriplets();
            UniqueTriplets();
            UniqueTriplets();
            UniqueTriplets();
        }

        private static void UniqueCouples()
        {
            var fd = new FullDeck();
            int cnt = 26 * 51;
            int actual = 0;
            //
            var sw = Stopwatch.StartNew();
            actual = Hand2.LinqDoublets().Count();
            sw.Stop();
            Assert.AreEqual(actual, cnt);
            Debug.WriteLine("linq: {0}", sw.ElapsedTicks);
            //
            sw = Stopwatch.StartNew();
            actual = Hand2.ForeachDoublets(fd).Count();
            sw.Stop();
            Assert.AreEqual(actual, cnt);
            Debug.WriteLine("foreachX2: {0}", sw.ElapsedTicks);
            
            //
            //var ints = fd.Select(c => c.GetHashCode());
            //sw = Stopwatch.StartNew();
            //actual = Hand2.ZipDoublets(fd).Count();
            //sw.Stop();
            //Assert.AreEqual(actual, cnt);
            //Debug.WriteLine("zip: {0}", sw.ElapsedTicks);
        }

        private static void UniqueTriplets()
        {
            var fd = new FullDeck();
            int cnt = 26 * 17 * 50;
            int actual = 0;
            //
            var sw = Stopwatch.StartNew();
            actual = Hand3.LinqTriplets().Count();
            sw.Stop();
            Assert.AreEqual(actual, cnt);
            Debug.WriteLine("linq: {0}", sw.ElapsedTicks);
            //
            sw = Stopwatch.StartNew();
            actual = Hand3.ForeachTriplets(fd).Count();
            sw.Stop();
            Assert.AreEqual(actual, cnt);
            Debug.WriteLine("foreachX3: {0}", sw.ElapsedTicks);

            //
            //var ints = fd.Select(c => c.GetHashCode());
            //sw = Stopwatch.StartNew();
            //actual = Hand2.ZipDoublets(fd).Count();
            //sw.Stop();
            //Assert.AreEqual(actual, cnt);
            //Debug.WriteLine("zip: {0}", sw.ElapsedTicks);
        }
    }
}

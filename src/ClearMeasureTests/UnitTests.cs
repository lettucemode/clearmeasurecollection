using ClearMeasureLibrary;
using System.Text;

namespace ClearMeasureTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void RikkiAndBobby()
        {
            var n1 = "Rikki";
            var n2 = "Bobby";
            var dict = new Dictionary<int, string>()
            {
                { 3, n1 },
                { 5, n2 },
            };
            var collection = new ClearMeasureCollection(100, dict);
            Assert.IsTrue(collection[1] == "1");
            Assert.IsTrue(collection[3] == n1);
            Assert.IsTrue(collection[5] == n2);
            Assert.IsTrue(collection[15] == $"{n1}{n2}");
            Assert.IsTrue(collection[25] == n2);
            Assert.IsTrue(collection[45] == $"{n1}{n2}");
        }

        [TestMethod]
        public void UpperBoundIsInclusive()
        {
            var dict = new Dictionary<int, string>()
            {
                { 5, "Something" },
            };
            var collection = new ClearMeasureCollection(100, dict);
            Assert.IsTrue(collection[1] == "1");
            Assert.IsTrue(collection[100] == "Something");

            var dict2 = new Dictionary<int, string>()
            {
                { 5, "Something, again" },
            };
            var collection2 = new ClearMeasureCollection(10000, dict2);
            Assert.IsTrue(collection2[1] == "1");
            Assert.IsTrue(collection2[10000] == "Something, again");
        }

        [TestMethod]
        public void NoOutOfMemoryExceptionForIntMaxUpperBound()
        {
            OutOfMemoryException? oom = default;
            try
            {
                var n1 = "Once more,";
                var n2 = " with feeling";
                var n3 = "a string";
                var dict = new Dictionary<int, string>()
                {
                    { 5, n1 },
                    { 7, n2 },
                    { 78419155, n3 },
                };
                var collection = new ClearMeasureCollection(int.MaxValue, dict);
                Assert.IsTrue(collection[1] == "1");
                Assert.IsTrue(collection[100] == n1);
                Assert.IsTrue(collection[700] == $"{n1}{n2}");
                Assert.IsTrue(collection[78419155] == $"{n1}{n3}");
                Assert.IsTrue(collection[int.MaxValue] == $"{int.MaxValue}");

                for (long i = 2140000000; i < (long)int.MaxValue + 1; i++)
                {
                    var thing = collection[(int)i];
                }
            }
            catch (OutOfMemoryException ex)
            {
                oom = ex;
            }
            Assert.IsNull(oom);
        }

        [TestMethod]
        public void LotsOfOverlappingRulesToStressStringConcat()
        {
            try
            {
                var dict = new Dictionary<int, string>()
                {
                    { 2, "two" },
                    { 4, "two" },
                    { 8, "two" },
                    { 16, "two" },
                    { 32, "two" },
                    { 64, "two" },
                    { 128, "two" },
                    { 256, "two" },
                    { 512, "two" },
                    { 1024, "two" },
                    { 2048, "two" },
                    { 4096, "two" },
                    { 8192, "two" },
                    { 16384, "two" },
                    { 32768, "two" },
                    { 65536, "two" },
                };
                var collection = new ClearMeasureCollection(5000, dict);
                Assert.IsTrue(collection[1] == "1");
                for (var k = 0; k < 10000; k++)
                {
                    for (var i = 1; i <= 16; i++)
                    {
                        Assert.IsTrue(collection[(int)Math.Pow(2, i)] == string.Join("", Enumerable.Repeat("two", i)));
                    }
                }
            }
            catch (OutOfMemoryException ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
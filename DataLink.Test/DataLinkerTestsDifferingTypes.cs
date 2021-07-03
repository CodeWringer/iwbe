using System;
using Xunit;
using DataLink;
using System.Linq;
using System.Collections.Generic;

namespace DataLink.Test
{
    public class DataLinkerTestsDifferingTypes
    {
        [Fact]
        public void TestAddSingle()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable2();

            testable.Add(linkable1, linkable2);
            Assert.Contains(linkable2, testable.GetLinksOf(linkable1));
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2));
        }

        [Fact]
        public void TestAddMultiple()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable1 = new TestLinkable1();
            var linkable2a = new TestLinkable2();
            var linkable2b = new TestLinkable2();
            var linkable2c = new TestLinkable2();

            testable.Add(linkable1, linkable2a);
            testable.Add(linkable1, linkable2b);
            testable.Add(linkable1, linkable2c);

            Assert.Contains(linkable2a, testable.GetLinksOf(linkable1));
            Assert.Contains(linkable2b, testable.GetLinksOf(linkable1));
            Assert.Contains(linkable2c, testable.GetLinksOf(linkable1));

            Assert.Contains(linkable1, testable.GetLinksOf(linkable2a));
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2b));
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2c));
        }

        [Fact]
        public void TestAddRemoveSingle()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable2();

            testable.Add(linkable1, linkable2);
            Assert.Contains(linkable2, testable.GetLinksOf(linkable1));
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2));

            testable.Remove(linkable1, linkable2);
            Assert.True(testable.GetLinksOf(linkable1) == null);
            Assert.True(testable.GetLinksOf(linkable2) == null);
        }

        [Fact]
        public void TestAddRemoveMultiple()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable1 = new TestLinkable1();

            var linkable2a = new TestLinkable2();
            var linkable2b = new TestLinkable2();
            var linkable2c = new TestLinkable2();

            testable.Add(linkable1, linkable2a);
            testable.Add(linkable1, linkable2b);
            testable.Add(linkable1, linkable2c);

            Assert.Contains(linkable2a, testable.GetLinksOf(linkable1));
            Assert.Contains(linkable2b, testable.GetLinksOf(linkable1));
            Assert.Contains(linkable2c, testable.GetLinksOf(linkable1));

            Assert.Contains(linkable1, testable.GetLinksOf(linkable2a));
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2b));
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2c));

            testable.Remove(linkable1, linkable2b);

            Assert.True(testable.GetLinksOf(linkable1).Count() == 2);
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2a));
            Assert.True(testable.GetLinksOf(linkable2b) == null);
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2c));

            Assert.True(testable.Remove(linkable1, linkable2b) == false);
        }

        [Fact]
        public void TestAddRemoveAll1()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable1 = new TestLinkable1();

            var linkable2a = new TestLinkable2();
            var linkable2b = new TestLinkable2();
            var linkable2c = new TestLinkable2();

            testable.Add(linkable1, linkable2a);
            testable.Add(linkable1, linkable2b);
            testable.Add(linkable1, linkable2c);

            var linksOf = testable.GetLinksOf(linkable1);
            Assert.True(linksOf.Count() == 3);

            testable.Remove(linkable1);

            Assert.True(testable.GetLinksOf(linkable1) == null);
            Assert.True(testable.GetLinksOf(linkable2a) == null);
            Assert.True(testable.GetLinksOf(linkable2b) == null);
            Assert.True(testable.GetLinksOf(linkable2c) == null);
        }

        [Fact]
        public void TestAddRemoveAll2()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable2 = new TestLinkable2();

            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();
            var linkable1c = new TestLinkable1();

            testable.Add(linkable1a, linkable2);
            testable.Add(linkable1b, linkable2);
            testable.Add(linkable1c, linkable2);

            var linksOf = testable.GetLinksOf(linkable2);
            Assert.True(linksOf.Count() == 3);

            testable.Remove(linkable2);
            Assert.True(testable.GetLinksOf(linkable2) == null);
            Assert.True(testable.GetLinksOf(linkable1a) == null);
            Assert.True(testable.GetLinksOf(linkable1b) == null);
            Assert.True(testable.GetLinksOf(linkable1c) == null);
        }

        [Fact]
        public void TestGetAllLinksByFirst()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();

            var linkable2a = new TestLinkable2();
            var linkable2b = new TestLinkable2();
            var linkable2c = new TestLinkable2();

            testable.Add(linkable1a, linkable2a);
            testable.Add(linkable1a, linkable2b);
            testable.Add(linkable1a, linkable2c);

            testable.Add(linkable1b, linkable2c);

            IEnumerable<KeyValuePair<TestLinkable1, IEnumerable<TestLinkable2>>> linksOf = testable.GetAllLinksByFirst();
            foreach (var kv in linksOf)
            {
                if (kv.Key == linkable1a)
                {
                    Assert.Contains(linkable2a, kv.Value);
                    Assert.Contains(linkable2b, kv.Value);
                    Assert.Contains(linkable2c, kv.Value);
                }
                if (kv.Key == linkable1b)
                {
                    Assert.Contains(linkable2c, kv.Value);
                }
            }
        }

        [Fact]
        public void TestGetAllLinksBySecond()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();

            var linkable2a = new TestLinkable2();
            var linkable2b = new TestLinkable2();
            var linkable2c = new TestLinkable2();

            testable.Add(linkable1a, linkable2a);
            testable.Add(linkable1a, linkable2b);
            testable.Add(linkable1a, linkable2c);

            testable.Add(linkable1b, linkable2c);

            IEnumerable<KeyValuePair<TestLinkable2, IEnumerable<TestLinkable1>>> linksOf = testable.GetAllLinksBySecond();
            foreach (var kv in linksOf)
            {
                if (kv.Key == linkable2a)
                {
                    Assert.Contains(linkable1a, kv.Value);
                }
                if (kv.Key == linkable2b)
                {
                    Assert.Contains(linkable1a, kv.Value);
                }
                if (kv.Key == linkable2c)
                {
                    Assert.Contains(linkable1a, kv.Value);
                    Assert.Contains(linkable1b, kv.Value);
                }
            }
        }

        [Fact]
        public void TestContains()
        {
            var testable = new DataLinker<TestLinkable1, TestLinkable2>();
            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable2();
            testable.Add(linkable1, linkable2);

            Assert.True(testable.Contains(linkable1));
            Assert.True(testable.Contains(linkable2));
        }
    }
}

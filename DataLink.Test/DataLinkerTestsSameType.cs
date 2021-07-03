using System;
using Xunit;
using DataLink;
using System.Linq;
using System.Collections.Generic;

namespace DataLink.Test
{
    public class DataLinkerTestsSameType
    {
        [Fact]
        public void TestAddSingle()
        {
            var testable = new DataLinker<TestLinkable1>();
            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable1();

            testable.Add(linkable1, linkable2);
            Assert.Contains(linkable2, testable.GetLinksOf(linkable1));
            Assert.Contains(linkable1, testable.GetLinksOf(linkable2));
        }

        [Fact]
        public void TestAddMultiple()
        {
            var testable = new DataLinker<TestLinkable1>();
            var linkable1 = new TestLinkable1();
            var linkable2a = new TestLinkable1();
            var linkable2b = new TestLinkable1();
            var linkable2c = new TestLinkable1();

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
            var testable = new DataLinker<TestLinkable1>();
            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable1();

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
            var testable = new DataLinker<TestLinkable1>();
            var linkable1 = new TestLinkable1();

            var linkable2a = new TestLinkable1();
            var linkable2b = new TestLinkable1();
            var linkable2c = new TestLinkable1();

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
            var testable = new DataLinker<TestLinkable1>();
            var linkable1 = new TestLinkable1();

            var linkable2a = new TestLinkable1();
            var linkable2b = new TestLinkable1();
            var linkable2c = new TestLinkable1();

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
            var testable = new DataLinker<TestLinkable1>();
            var linkable1 = new TestLinkable1();

            var linkable2a = new TestLinkable1();
            var linkable2b = new TestLinkable1();
            var linkable2c = new TestLinkable1();

            testable.Add(linkable1, linkable2a);
            testable.Add(linkable1, linkable2b);
            testable.Add(linkable1, linkable2c);

            var linksOf = testable.GetLinksOf(linkable1);
            Assert.True(linksOf.Count() == 3);

            testable.Remove(linkable2b);

            Assert.True(testable.GetLinksOf(linkable2b) == null);
            Assert.True(testable.GetLinksOf(linkable1) != null);
            Assert.True(testable.GetLinksOf(linkable2a) != null);
            Assert.True(testable.GetLinksOf(linkable2c) != null);

            Assert.True(testable.GetLinksOf(linkable1).Count() == 2);
            Assert.True(testable.GetLinksOf(linkable2a).Count() == 1);
            Assert.True(testable.GetLinksOf(linkable2c).Count() == 1);
        }
    }
}

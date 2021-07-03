using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DataLink.Test
{
    public class HierarchyDataLinkerTests
    {
        [Fact]
        public void TestAddDifferentTypes()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable2>();

            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable2();

            Assert.True(null == testable.GetChildrenOf(linkable1));
            Assert.True(null == testable.GetParentOf(linkable2));

            testable.Add(linkable1, linkable2);

            Assert.Contains(linkable2, testable.GetChildrenOf(linkable1));
            Assert.True(linkable1 == testable.GetParentOf(linkable2));
        }

        [Fact]
        public void TestAddDifferentTypesTwice()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable2>();

            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable2();

            Assert.True(null == testable.GetChildrenOf(linkable1));
            Assert.True(null == testable.GetParentOf(linkable2));

            testable.Add(linkable1, linkable2);

            Assert.Contains(linkable2, testable.GetChildrenOf(linkable1));
            Assert.True(testable.GetChildrenOf(linkable1).Count() == 1);
            Assert.True(linkable1 == testable.GetParentOf(linkable2));

            testable.Add(linkable1, linkable2);

            Assert.True(testable.GetChildrenOf(linkable1).Count() == 1);
        }

        [Fact]
        public void TestAddParentToSelf()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable1>();

            var linkable1 = new TestLinkable1();

            Assert.Throws<System.ArgumentException>(() => { testable.Add(linkable1, linkable1); });
        }

        [Fact]
        public void TestAddDifferentTypesDifferentParent()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable2>();

            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();

            var linkable2 = new TestLinkable2();

            Assert.True(null == testable.GetChildrenOf(linkable1a));
            Assert.True(null == testable.GetParentOf(linkable2));

            Assert.True(null == testable.GetChildrenOf(linkable1b));
            Assert.True(null == testable.GetParentOf(linkable2));

            testable.Add(linkable1a, linkable2);

            Assert.Contains(linkable2, testable.GetChildrenOf(linkable1a));
            Assert.True(linkable1a == testable.GetParentOf(linkable2));
            Assert.True(null == testable.GetChildrenOf(linkable1b));

            testable.Add(linkable1b, linkable2);

            Assert.Contains(linkable2, testable.GetChildrenOf(linkable1b));
            Assert.True(linkable1b == testable.GetParentOf(linkable2));
            Assert.True(null == testable.GetChildrenOf(linkable1a));
        }

        [Fact]
        public void TestAddSameTypes()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable1>();

            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();

            Assert.True(null == testable.GetChildrenOf(linkable1a));
            Assert.True(null == testable.GetParentOf(linkable1b));

            testable.Add(linkable1a, linkable1b);

            Assert.Contains(linkable1b, testable.GetChildrenOf(linkable1a));
            Assert.True(linkable1a == testable.GetParentOf(linkable1b));
        }

        [Fact]
        public void TestAddSameTypesTwice()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable1>();

            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();

            Assert.True(null == testable.GetChildrenOf(linkable1a));
            Assert.True(null == testable.GetParentOf(linkable1b));

            testable.Add(linkable1a, linkable1b);

            Assert.Contains(linkable1b, testable.GetChildrenOf(linkable1a));
            Assert.True(testable.GetChildrenOf(linkable1a).Count() == 1);
            Assert.True(linkable1a == testable.GetParentOf(linkable1b));

            testable.Add(linkable1a, linkable1b);

            Assert.True(testable.GetChildrenOf(linkable1a).Count() == 1);
        }

        [Fact]
        public void TestAddSameTypesDifferentParent()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable1>();

            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();

            var linkable1c = new TestLinkable1();

            Assert.True(null == testable.GetChildrenOf(linkable1a));
            Assert.True(null == testable.GetParentOf(linkable1c));

            Assert.True(null == testable.GetChildrenOf(linkable1b));
            Assert.True(null == testable.GetParentOf(linkable1c));

            testable.Add(linkable1a, linkable1c);

            Assert.Contains(linkable1c, testable.GetChildrenOf(linkable1a));
            Assert.True(linkable1a == testable.GetParentOf(linkable1c));
            Assert.True(null == testable.GetChildrenOf(linkable1b));

            testable.Add(linkable1b, linkable1c);

            Assert.Contains(linkable1c, testable.GetChildrenOf(linkable1b));
            Assert.True(linkable1b == testable.GetParentOf(linkable1c));
            Assert.True(null == testable.GetChildrenOf(linkable1a));
        }

        [Fact]
        public void TestRemoveDifferentTypesSingle()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable2>();

            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable2();

            Assert.True(null == testable.GetChildrenOf(linkable1));
            Assert.True(null == testable.GetParentOf(linkable2));

            testable.Add(linkable1, linkable2);

            Assert.Contains(linkable2, testable.GetChildrenOf(linkable1));
            Assert.True(linkable1 == testable.GetParentOf(linkable2));

            Assert.True(testable.RemoveChild(linkable2));

            Assert.True(null == testable.GetChildrenOf(linkable1));
            Assert.True(null == testable.GetParentOf(linkable2));
        }

        [Fact]
        public void TestRemoveSameTypesSingle()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable1>();

            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();

            Assert.True(null == testable.GetChildrenOf(linkable1a));
            Assert.True(null == testable.GetParentOf(linkable1b));

            testable.Add(linkable1a, linkable1b);

            Assert.Contains(linkable1b, testable.GetChildrenOf(linkable1a));
            Assert.True(linkable1a == testable.GetParentOf(linkable1b));

            Assert.True(testable.RemoveChild(child: linkable1b));

            Assert.True(null == testable.GetChildrenOf(linkable1a));
            Assert.True(null == testable.GetParentOf(linkable1b));
        }

        [Fact]
        public void TestRemoveDifferentTypesSingle2()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable2>();

            var linkable1 = new TestLinkable1();
            var linkable2a = new TestLinkable2();
            var linkable2b = new TestLinkable2();
            var linkable2c = new TestLinkable2();

            Assert.True(null == testable.GetChildrenOf(linkable1));
            Assert.True(null == testable.GetParentOf(linkable2a));
            Assert.True(null == testable.GetParentOf(linkable2b));
            Assert.True(null == testable.GetParentOf(linkable2c));

            testable.Add(linkable1, linkable2a);
            testable.Add(linkable1, linkable2b);
            testable.Add(linkable1, linkable2c);

            Assert.Contains(linkable2a, testable.GetChildrenOf(linkable1));
            Assert.Contains(linkable2b, testable.GetChildrenOf(linkable1));
            Assert.Contains(linkable2c, testable.GetChildrenOf(linkable1));

            Assert.True(linkable1 == testable.GetParentOf(linkable2a));
            Assert.True(linkable1 == testable.GetParentOf(linkable2b));
            Assert.True(linkable1 == testable.GetParentOf(linkable2c));

            Assert.True(testable.RemoveChild(linkable2b));

            Assert.True(testable.GetChildrenOf(linkable1).Count() == 2);

            Assert.True(linkable1 == testable.GetParentOf(linkable2a));
            Assert.True(null == testable.GetParentOf(linkable2b));
            Assert.True(linkable1 == testable.GetParentOf(linkable2c));

            Assert.Contains(linkable2a, testable.GetChildrenOf(linkable1));
            Assert.Contains(linkable2c, testable.GetChildrenOf(linkable1));
        }

        [Fact]
        public void TestHasKeyDifferentType()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable2>();
            var linkable1 = new TestLinkable1();
            var linkable2 = new TestLinkable2();

            testable.Add(linkable1, linkable2);

            Assert.True(testable.ContainsParent(linkable1));
            Assert.True(testable.ContainsChild(linkable2));
        }

        [Fact]
        public void TestHasKeySameType()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable1>();
            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();

            testable.Add(linkable1a, linkable1b);

            Assert.True(testable.ContainsChild(linkable1b));
            Assert.True(testable.ContainsParent(linkable1a));
        }

        [Fact]
        public void TestGetAllLinks()
        {
            var testable = new HierarchyDataLinker<TestLinkable1, TestLinkable1>();
            var linkable1a = new TestLinkable1();
            var linkable1b = new TestLinkable1();
            var linkable1c = new TestLinkable1();
            var linkable1d = new TestLinkable1();

            testable.Add(linkable1a, linkable1b);
            testable.Add(linkable1a, linkable1c);
            testable.Add(linkable1a, linkable1d);

            var links = testable.GetAllLinks();

            Assert.True(links.Count() == 1);
            Assert.True(links.ElementAt(0).Key == linkable1a);
            Assert.Contains(linkable1b, links.ElementAt(0).Value);
            Assert.Contains(linkable1c, links.ElementAt(0).Value);
            Assert.Contains(linkable1d, links.ElementAt(0).Value);
        }
    }
}

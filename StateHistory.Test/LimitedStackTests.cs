using StateHistory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreSystem.Test
{
    public class LimitedStackTests
    {
        [Fact]
        public void TestPush()
        {
            var testable = new LimitedStack<int>(3);

            Assert.True(testable.Count == 0);

            testable.Push(0);
            testable.Push(1);
            testable.Push(2);

            Assert.True(testable.Count == 3);
            Assert.True(testable.Peek() == 2);

            testable.Push(3);

            Assert.True(testable.Count == 3);
            Assert.True(testable.Peek() == 3);
        }

        [Fact]
        public void TestPop()
        {
            var testable = new LimitedStack<int>(3);

            Assert.True(testable.Count == 0);

            testable.Push(0);
            testable.Push(1);
            testable.Push(2);

            Assert.True(testable.Count == 3);
            Assert.True(testable.Peek() == 2);

            testable.Pop();

            Assert.True(testable.Count == 2);
            Assert.True(testable.Peek() == 1);
        }

        [Fact]
        public void TestChangeMax()
        {
            var testable = new LimitedStack<int>(10);

            Assert.True(testable.Count == 0);

            for (int i = 0; i < 10; i++)
            {
                testable.Push(i);
            }

            Assert.True(testable.Count == 10);
            Assert.True(testable.Peek() == 9);

            testable.MaxEntryCount = 4;

            Assert.True(testable.Count == 4);
            Assert.True(testable.Peek() == 9);

            testable.MaxEntryCount = 10;

            Assert.True(testable.Count == 4);
            Assert.True(testable.Peek() == 9);
        }

        [Fact]
        public void TestChangeMax2()
        {
            var testable = new LimitedStack<int>(13);

            Assert.True(testable.Count == 0);

            for (int i = 0; i < 13; i++)
            {
                testable.Push(i);
            }

            Assert.True(testable.Count == 13);
            Assert.True(testable.Peek() == 12);

            testable.MaxEntryCount = 6;

            Assert.True(testable.Count == 6);
            Assert.True(testable.Peek() == 12);

            testable.MaxEntryCount = 10;

            Assert.True(testable.Count == 6);
            Assert.True(testable.Peek() == 12);
        }

        [Fact]
        public void TestInitialValues()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            var testable = new LimitedStack<int>(list, 10);

            Assert.True(testable.Count == 10);
            Assert.True(testable.Peek() == 9);
        }

        [Fact]
        public void TestInitialTooManyValues()
        {
            var list = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(i);
            }

            var testable = new LimitedStack<int>(list, 10);

            Assert.True(testable.Count == 10);
            Assert.True(testable.Peek() == 19);
        }

        [Fact]
        public void TestClear()
        {
            var testable = new LimitedStack<int>(10);

            Assert.True(testable.Count == 0);

            for (int i = 0; i < 10; i++)
            {
                testable.Push(i);
            }

            Assert.True(testable.Count == 10);

            testable.Clear();

            Assert.True(testable.Count == 0);
        }

        [Fact]
        public void TestContains()
        {
            var testable = new LimitedStack<int>(10);

            Assert.True(testable.Count == 0);

            for (int i = 0; i < 10; i++)
            {
                testable.Push(i);
            }

            Assert.Contains(4, testable);
        }

        [Fact]
        public void TestTryPeek()
        {
            var testable = new LimitedStack<int>(10);

            Assert.True(testable.Count == 0);

            int result = -1;
            Assert.True(testable.TryPeek(out result) == false);

            Assert.True(result == 0);
        }

        [Fact]
        public void TestTryPop()
        {
            var testable = new LimitedStack<int>(10);

            Assert.True(testable.Count == 0);

            int result = -1;
            Assert.True(testable.TryPop(out result) == false);

            Assert.True(result == 0);
        }
    }
}

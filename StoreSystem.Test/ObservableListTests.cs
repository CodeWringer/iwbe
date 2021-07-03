using System;
using Xunit;

namespace StoreSystem.Test
{
    public class ObservableListTests
    {
        [Fact]
        public void TestAdd()
        {
            var testable = new ObservableList<int>();

            Assert.True(testable.Count == 0);

            testable.Add(1);
            Assert.True(testable.Count == 1);

            testable.Add(1);
            Assert.True(testable.Count == 2);
        }

        [Fact]
        public void TestRemove()
        {
            var testable = new ObservableList<int>();

            Assert.True(testable.Count == 0);

            testable.Add(1);
            Assert.True(testable.Count == 1);

            testable.Add(1);
            Assert.True(testable.Count == 2);

            Assert.True(testable.Remove(1));
            Assert.True(testable.Count == 1);

            Assert.True(testable.Remove(1));
            Assert.True(testable.Count == 0);
        }

        [Fact]
        public void TestInsert()
        {
            var testable = new ObservableList<int>();

            Assert.True(testable.Count == 0);

            testable.Add(0);
            Assert.True(testable.Count == 1);
            Assert.True(testable[0] == 0);

            testable.Insert(0, 1);
            Assert.True(testable.Count == 2);
            Assert.True(testable[0] == 1);
        }

        [Fact]
        public void TestRemoveAt()
        {
            var testable = new ObservableList<int>();

            Assert.True(testable.Count == 0);

            testable.Add(0);
            Assert.True(testable.Count == 1);

            testable.Add(1);
            Assert.True(testable.Count == 2);

            Assert.True(testable[0] == 0);
            testable.RemoveAt(0);
            Assert.True(testable.Count == 1);
            Assert.True(testable[0] == 1);
        }

        [Fact]
        public void TestClear()
        {
            var testable = new ObservableList<int>();

            Assert.True(testable.Count == 0);

            testable.Add(1);
            Assert.True(testable.Count == 1);

            testable.Add(1);
            Assert.True(testable.Count == 2);

            testable.Clear();
            Assert.True(testable.Count == 0);
        }

        [Fact]
        public void TestContains()
        {
            var testable = new ObservableList<int>();

            Assert.True(testable.Count == 0);

            testable.Add(1);
            Assert.True(testable.Count == 1);

            testable.Add(2);
            Assert.True(testable.Count == 2);

            Assert.Contains(2, testable);
            Assert.Contains(1, testable);
            Assert.DoesNotContain(999, testable);
        }

        [Fact]
        public void TestIndexOf()
        {
            var testable = new ObservableList<int>();

            Assert.True(testable.Count == 0);

            testable.Add(0);
            Assert.True(testable.Count == 1);

            testable.Add(1);
            Assert.True(testable.Count == 2);

            Assert.True(testable.IndexOf(0) == 0);
            Assert.True(testable.IndexOf(1) == 1);
        }

        [Fact]
        public void TestReplace()
        {
            var testable = new ObservableList<int>();
            testable.Add(0);
            testable.Add(1);
            testable.Add(2);

            Assert.Equal(1, testable[1]);
            testable.Replace(1, 99);
            Assert.Equal(99, testable[1]);
        }

        [Fact]
        public void TestReplaceAt()
        {
            var testable = new ObservableList<int>();
            testable.Add(0);
            testable.Add(1);
            testable.Add(2);

            Assert.Equal(1, testable[1]);
            testable.ReplaceAt(1, 99);
            Assert.Equal(99, testable[1]);
        }

        [Fact]
        public void TestSort()
        {
            var testable = new ObservableList<int>();

            testable.Add(5);
            testable.Add(1);
            testable.Add(3);

            Assert.Equal(5, testable[0]);
            Assert.Equal(1, testable[1]);
            Assert.Equal(3, testable[2]);

            testable.Sort();

            Assert.Equal(1, testable[0]);
            Assert.Equal(3, testable[1]);
            Assert.Equal(5, testable[2]);
        }

        [Fact]
        public void TestEventsAdd()
        {
            var testable = new ObservableList<int>();
            testable.ItemAdding += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 0);
                Assert.Equal(0, change.Item);
                Assert.Equal(0, change.Index);
            };
            testable.ItemAdded += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 1);
                Assert.Equal(0, change.Item);
                Assert.Equal(0, change.Index);
            };
            testable.Add(0);
        }

        [Fact]
        public void TestEventsAdd2()
        {
            var testable = new ObservableList<int>();
            testable.Add(0);
            testable.Add(1);
            testable.ItemAdding += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 2);
                Assert.Equal(2, change.Item);
                Assert.Equal(2, change.Index);
            };
            testable.ItemAdded += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(2, change.Item);
                Assert.Equal(2, change.Index);
            };
            testable.Add(2);
        }

        [Fact]
        public void TestEventsRemove()
        {
            var testable = new ObservableList<int>();
            testable.Add(0);
            testable.Add(1);
            testable.ItemRemoving += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 2);
                Assert.Contains(0, testable);
                Assert.Contains(1, testable);
            };
            testable.ItemRemoved += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 1);
                Assert.DoesNotContain(0, testable);
                Assert.Contains(1, testable);
            };
            testable.Remove(0);
        }

        [Fact]
        public void TestEventsRemoveAt()
        {
            var testable = new ObservableList<int>();
            testable.Add(0);
            testable.Add(1);
            testable.ItemRemoving += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 2);
                Assert.Contains(0, testable);
                Assert.Contains(1, testable);
                Assert.Equal(0, testable[0]);
                Assert.Equal(1, testable[1]);
            };
            testable.ItemRemoved += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 1);
                Assert.DoesNotContain(0, testable);
                Assert.Contains(1, testable);
                Assert.Equal(1, testable[0]);
            };
            testable.RemoveAt(0);
        }

        [Fact]
        public void TestEventsReplace()
        {
            var testable = new ObservableList<int>();
            testable.Add(0);
            testable.Add(1);
            testable.Add(2);
            testable.ItemReplacing += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(0, testable[0]);
                Assert.Equal(1, testable[1]);
                Assert.Equal(2, testable[2]);
            };
            testable.ItemReplaced += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(0, testable[0]);
                Assert.Equal(99, testable[1]);
                Assert.Equal(2, testable[2]);
            };
            testable.Replace(1, 99);
        }

        [Fact]
        public void TestEventsReplaceAt()
        {
            var testable = new ObservableList<int>();
            testable.Add(0);
            testable.Add(1);
            testable.Add(2);
            testable.ItemReplacing += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(0, testable[0]);
                Assert.Equal(1, testable[1]);
                Assert.Equal(2, testable[2]);
            };
            testable.ItemReplaced += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(0, testable[0]);
                Assert.Equal(99, testable[1]);
                Assert.Equal(2, testable[2]);
            };
            testable.ReplaceAt(1, 99);
        }

        [Fact]
        public void TestEventsMove()
        {
            var testable = new ObservableList<int>();
            testable.Add(0);
            testable.Add(1);
            testable.Add(2);
            testable.ItemMoving += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(0, testable[0]);
                Assert.Equal(1, testable[1]);
                Assert.Equal(2, testable[2]);
            };
            testable.ItemMoved += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(2, testable[0]);
                Assert.Equal(0, testable[1]);
                Assert.Equal(1, testable[2]);
            };
            testable.Move(2, 0);
        }

        [Fact]
        public void TestEventsSort()
        {
            var testable = new ObservableList<int>();

            testable.Add(5);
            testable.Add(1);
            testable.Add(3);
            testable.ItemsSorting += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(5, testable[0]);
                Assert.Equal(1, testable[1]);
                Assert.Equal(3, testable[2]);
            };
            testable.ItemsSorted += (observable, change) =>
            {
                Assert.Equal(observable, testable);
                Assert.True(testable.Count == 3);
                Assert.Equal(1, testable[0]);
                Assert.Equal(3, testable[1]);
                Assert.Equal(5, testable[2]);
            };
            testable.Sort();
        }
    }
}

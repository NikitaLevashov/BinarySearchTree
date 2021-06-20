using NUnit.Framework;
using System;

namespace BinarySearchTree.Tests
{
    public class Tests
    {
        [Test]
        public void BinaryTreeTests_CreateWithNullCompare_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new BinarySearchTree<int>(new int[] { 1 }, null));

        [Test]
        public void BinaryTreeTests_CreateWithNullCompareAndCollection_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new BinarySearchTree<int>(null, null));

        #region Int32 Tests
        [Test]
        public void BinaryTreeTests_ContainsInt_ReturnTrue()
        {
            var array = new int[] { 1, 2, 3, 4 };
            var tree = new BinarySearchTree<int>(array);
            Assert.IsTrue(tree.Contains(4));
        }

        [Test]
        public void BinaryTreeTests_AddInt_ReturnTrue()
        {
            var array = new int[] { 1, 2, 3, 4 };
            var tree = new BinarySearchTree<int>(array);
            tree.Add(5);
            Assert.IsTrue(tree.Contains(5));
        }

        [Test]
        public void BinaryTreeTests_IntPreOrderTraversal_ReturnCollection()
        {
            var array = new int[] { 4, 2, 1, 3, 5, 7, 8, 6 };
            var tree = new BinarySearchTree<int>(array);
            var actual = new int[array.Length];
            var expected = new int[] { 4, 2, 1, 3, 5, 7, 6, 8 };
            int i = 0;
            foreach (var item in tree.PreOrderTraversal())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinaryTreeTests_IntPostOrderTraversal_ReturnCollection()
        {
            var array = new int[] { 4, 2, 1, 3, 5, 7, 8, 6 };
            var tree = new BinarySearchTree<int>(array);
            var actual = new int[array.Length];
            var expected = new int[] { 1, 3, 2, 6, 8, 7, 5, 4 };
            int i = 0;
            foreach (var item in tree.PostOrderTraversal())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinaryTreeTests_IntInOrderTraversal_ReturnCollection()
        {
            var array = new int[] { 4, 2, 1, 3, 5, 7, 8, 6 };
            var tree = new BinarySearchTree<int>(array);
            var actual = new int[array.Length];
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int i = 0;
            foreach (var item in tree.InOrderTraversal())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinaryTreeTests_IntInOrderTraversalWithIntCompare_ReturnCollection()
        {
            var array = new int[] { 3, 1, 2, 4, 5, 7, 6, 8 };
            var tree = new BinarySearchTree<int>(array, new IntegerComparer());
            var actual = new int[array.Length];
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int i = 0;
            foreach (var item in tree.InOrderTraversal())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tests_ContainsString_ReturnTrue()
        {
            var array = new string[] { "asdasd", "helasdlo", "dfgdfgg", "r" };
            var tree = new BinarySearchTree<string>(array);
            Assert.IsTrue(tree.Contains("r"));
        }

        [Test]
        public void Tests_AddString_ReturnTrue()
        {
            var array = new string[] { "asdasd", "asdsadsad", "jkhjkh", "asdasd" };
            var tree = new BinarySearchTree<string>(array);
            tree.Add("e");
            Assert.IsTrue(tree.Contains("e"));
        }

        [Test]
        public void Tests_StringPreOrderTraversal_ReturnCollection()
        {
            var array = new string[] { "cde", "bc", "abc", "d", "efghi", "fghjkl" };
            var tree = new BinarySearchTree<string>(array);
            var actual = new string[array.Length];
            var expected = new string[] { "cde", "bc", "abc", "d", "efghi", "fghjkl" };
            int i = 0;
            foreach (var item in tree.PreOrderTraversal())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tests_StringPostOrderTraversal_ReturnCollection()
        {
            var array = new string[] { "cde", "bc", "abc", "d", "efghj", "fghjkl" };
            var tree = new BinarySearchTree<string>(array);
            var actual = new string[array.Length];
            var expected = new string[] { "abc", "bc", "fghjkl", "efghj", "d", "cde" };
            int i = 0;
            foreach (var item in tree.PostOrderTraversal())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tests_StringInOrderTraversal_ReturnCollection()
        {
            var array = new string[] { "cde", "bc", "abc", "d", "efghj", "fghjkl" };
            var tree = new BinarySearchTree<string>(array);
            var actual = new string[array.Length];
            var expected = new string[] { "abc", "bc", "cde", "d", "efghj", "fghjkl" };
            int i = 0;
            foreach (var item in tree.InOrderTraversal())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tests_IntInOrderTraversalWithStringCompare_ReturnCollection()
        {
            var array = new string[] { "bc", "abc", "d", "efghj", "fghjkl" };
            var tree = new BinarySearchTree<string>(array, new StringComparer());
            var actual = new string[array.Length];
            var expected = new string[] { "d", "bc", "abc", "efghj", "fghjkl" };
            int i = 0;
            foreach (var item in tree.InOrderTraversal())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }
        #endregion

        [Test]
        public void Tests_BooksInOrderTraversal_ReturnCollection()
        {
            int[] actualIDarray = new int[4];
            int[] expected = { 200, 300, 400, 600 };
            var books = new Book[]
            {
                new Book(200),
                new Book(300),
                new Book(400),
                new Book(600),
            };
            var tree = new BinarySearchTree<Book>(books);
            int i = 0;
            foreach (var item in tree.InOrderTraversal())
            {
                actualIDarray[i++] = item.Pages;
            }
            Assert.AreEqual(expected, actualIDarray);
        }

        [Test]
        public void Tests_BooksInOrderTraversalWithComparer_ReturnCollection()
        {
            string[] actualTitleArray = new string[4];
            string[] expected = { "Book2", "Book3", "Book4", "Book6" };
            var books = new Book[]
            {
                new Book(3.0, "Book3"),
                new Book(2.0, "Book2"), 
                new Book(4.0, "Book4"), 
                new Book (6.0, "Book6")
            };
            var tree = new BinarySearchTree<Book>(books, new ComparePrice());
            int i = 0;

            foreach (var item in tree.InOrderTraversal())
            {
                actualTitleArray[i++] = item.Title;
            }
            Assert.AreEqual(expected, actualTitleArray);
        }

        [Test]
        public void Tests_BooksPostOrderTraversalWithComparer_ReturnCollection()
        {
            string[] actualTitleArray = new string[4];
            string[] expected = { "Book2", "Book6", "Book4", "Book3" };
            var books = new Book[]
            {
                new Book(3.0, "Book3"),
                new Book(2.0, "Book2"),
                new Book(4.0, "Book4"),
                new Book (6.0, "Book6")
            };
            var tree = new BinarySearchTree<Book>(books, new ComparePrice());
            int i = 0;

            foreach (var item in tree.PostOrderTraversal())
            {
                actualTitleArray[i++] = item.Title;
            }
            Assert.AreEqual(expected, actualTitleArray);
        }

        [Test]
        public void Tests_BooksPreOrderTraversalWithComparer_ReturnCollection()
        {
            string[] actualTitleArray = new string[4];
            string[] expected = { "Book3", "Book2", "Book4", "Book6" };
            var books = new Book[]
            {
                new Book(3.0, "Book3"),
                new Book(2.0, "Book2"),
                new Book(4.0, "Book4"),
                new Book (6.0, "Book6")
            };
            var tree = new BinarySearchTree<Book>(books, new ComparePrice());
            int i = 0;

            foreach (var item in tree.PreOrderTraversal())
            {
                actualTitleArray[i++] = item.Title;
            }
            Assert.AreEqual(expected, actualTitleArray);
        }

        [Test]
        public void Tests_TimessPostOrderWithComparer_ReturnCollection()
        {
            var times = new Time[]
            {
                new Time(2, 40),
                new Time(3, 40),
                new Time(4, 55)
            };
            var tree = new BinarySearchTree<Time>(times, new TimeComparer());
            var actual = new Time[3];
            int i = 0;
            foreach (var item in tree.PostOrderTraversal())
            {
                actual[i++] = item;
            }
            var expected = new Time[]
            {
                new Time(4, 55),
                new Time(3, 40),
                new Time(2, 40)
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tests_TimessPreOrderWithComparer_ReturnCollection()
        {
            var times = new Time[]
            {
                new Time(2, 40),
                new Time(3, 40),
                new Time(4, 55)
            };
            var tree = new BinarySearchTree<Time>(times, new TimeComparer());
            var actual = new Time[3];
            int i = 0;
            foreach (var item in tree.PreOrderTraversal())
            {
                actual[i++] = item;
            }
            var expected = new Time[]
            {
                new Time(2, 40),
                new Time(3, 40),
                new Time(4, 55)
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tests_TimessInOrderWithComparer_ReturnCollection()
        {
            var times = new Time[]
            {
                new Time(2, 40),
                new Time(3, 40),
                new Time(4, 55)
            };
            var tree = new BinarySearchTree<Time>(times, new TimeComparer());
            var actual = new Time[3];
            int i = 0;
            foreach (var item in tree.InOrderTraversal())
            {
                actual[i++] = item;
            }
            var expected = new Time[]
            {
                new Time(2, 40),
                new Time(3, 40),
                new Time(4, 55)
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
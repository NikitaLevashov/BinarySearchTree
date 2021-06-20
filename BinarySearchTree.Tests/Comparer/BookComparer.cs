using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    public class CompareAuthor : IComparer<Book>
    {
        /// <summary>
        /// Method compare by Author
        /// </summary>
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook == null && secondBook != null)
            {
                return -1;
            }
            if (firstBook != null && secondBook == null)
            {
                return 1;
            }
            if (firstBook == null && secondBook == null)
            {
                return 0;
            }

            return string.CompareOrdinal(firstBook.Author, secondBook.Author);
        }
    }

    /// <summary>
    /// Compare by price
    /// </summary>
    public class ComparePrice : IComparer<Book>
    {
        /// <summary>
        /// Method compare by Price
        /// </summary>
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook != null && secondBook == null)
            {
                return 1;
            }
            if (firstBook == null && secondBook == null)
            {
                return 0;
            }
            if (firstBook.Price > secondBook.Price)
            {
                return 1;
            }
            if (firstBook.Price == secondBook.Price)
            {
                return 0;
            }

            return -1;
        }
    }

    /// <summary>
    /// Method compare by Pages
    /// </summary>
    public class ComparePages : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook != null && secondBook == null)
            {
                return 1;
            }
            if (firstBook == null && secondBook == null)
            {
                return 0;
            }
            if (firstBook.Pages > secondBook.Pages)
            {
                return 1;
            }
            if (firstBook.Pages == secondBook.Pages)
            {
                return 0;
            }

            return -1;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Implementing Binary Search Tree
    /// </summary>
    /// <typeparam name="T">type parameter</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private IComparer<T> comparer;

        private Node<T> root;

        /// <summary>
        /// Constructor for binary search class
        /// </summary>
        public BinarySearchTree()
        {
            comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Constructor for binary search class
        /// </summary>
        /// <param name="comparer">class for implementations of the IComparer<T> generic interface</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        /// <summary>
        /// Constructor for binary search class
        /// </summary>
        /// <param name="sourceCollection">collection of elements for binary search tree</param>
        /// <param name="comparer">class for implementations of the IComparer<T> generic interface</param>
        public BinarySearchTree(IEnumerable<T> sourceCollection, IComparer<T> comparer)
        {
            if (sourceCollection == null)
            {
                throw new ArgumentNullException(nameof(sourceCollection));
            }

            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));

            foreach (T item in sourceCollection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Constructor for binary search class
        /// </summary>
        /// <param name="sourceCollection">collection of elements for binary search tree</param>
        public BinarySearchTree(IEnumerable<T> sourceCollection) : this(sourceCollection, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Add element to the tree
        /// </summary>
        /// <param name="element">element for add</param>
        public void Add(T element)
        {
            root = Insert(root, element);
        }

        /// <summary>
        /// Determines whether an element is contained in the tree
        /// </summary>
        /// <param name="value">element to define</param>
        /// <returns>true, if the element in the tree</returns>
        public bool Contains(T value)
        {
            return Contains(root, value);
        }

        /// <summary>
        /// Preorder traversal
        /// </summary>
        /// <returns>collection of the elements</returns>
        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrder(root);
        }

        /// <summary>
        /// Postorder traversal.
        /// </summary>
        /// <returns>collection of the elements<returns>
        public IEnumerable<T> PostOrderTraversal()
        {
            return PostOrder(root);
        }

        /// <summary>
        /// Inorder traversal.
        /// </summary>
        /// <returns>collection of the elements<returns>
        public IEnumerable<T> InOrderTraversal()
        {
            return InOrder(root);
        }

        /// <summary>
        /// Returns an enumerator.
        /// </summary>
        /// <returns>enumerator that iterates</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder(root).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator.
        /// </summary>
        /// <returns>enumerator that iterates</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        /// <summary>
        /// Method Insert.
        /// </summary>
        /// <param name="node">node.</param>
        /// <param name="value">value.</param>
        /// <returns></returns>
        private Node<T> Insert(Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
                return node;
            }

            int comparison = comparer.Compare(value, node.Value);

            if (comparison < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        /// <summary>
        /// Method Contain
        /// </summary>
        /// <param name="node">node.</param>
        /// <param name="value">value.</param>
        /// <returns></returns>
        private bool Contains(Node<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            int comparison = comparer.Compare(value, node.Value);

            if (comparison == 0)
            {
                return true;
            }

            if (comparison < 0)
            {
                return Contains(node.Left, value);
            }
            else
            {
                return Contains(node.Right, value);
            }
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;
            if (node.Left != null)
            {
                foreach (var item in PreOrder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in PreOrder(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var item in InOrder(node.Left))
                {
                    yield return item;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var item in InOrder(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var item in PostOrder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in PostOrder(node.Right))
                {
                    yield return item;
                }
            }

            yield return node.Value;
        }

        /// <summary>
        /// Node.
        /// </summary>
        private class Node<T>
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; private set; }

            public Node<T> Right { get; set; }

            public Node<T> Left { get; set; }
        }
    }
}

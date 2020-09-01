using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Teacher
{

    /* AVLTree class
     * This implementation of an AVL Tree (self-balancing binary search tree)
     * along with its parent classes BinTree and BSTree I produced as part of previous work. 
     * I originally used these for a forms project that aimed to achieve efficient retrieval of company information,
     * I felt it might be interesting to re-implement these tree implementations for a different concept.
     * 
     * Useful description of the AVL Tree algorithm: https://www.tutorialspoint.com/data_structures_algorithms/avl_tree_algorithm.htm
     * */

    class AVLTree<T> : BSTree<T> where T : IComparable
    {


        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right != null)
            {
                if (tree.Right.BalanceFactor > 0)
                    rotateRight(ref tree.Right);
                Node<T> oldroot = tree;
                Node<T> newroot = oldroot.Right;
                oldroot.Right = newroot.Left;
                newroot.Left = oldroot;
                tree = newroot;
            }


        }

        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left != null)
            {
                if (tree.Left.BalanceFactor < 0)
                    rotateLeft(ref tree.Left);
                Node<T> oldroot = tree;
                Node<T> newroot = oldroot.Left;
                oldroot.Left = newroot.Right;
                newroot.Right = oldroot;
                tree = newroot;
            }

        }

        //Insert new item
        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);
            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);
            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
            tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);

            if (tree.BalanceFactor <= -2)
                rotateLeft(ref tree);
            if (tree.BalanceFactor >= 2)
                rotateRight(ref tree);

        }
        //Check for least item in tree
        new public T leastItem()
        {
            return leastItem(root);
        }
        private T leastItem(Node<T> tree)
        {
            //T Temp;

            if (tree.Left == null)
            {
                return tree.Data;
            }

            else if (tree.Left != null)
            {
                return leastItem(tree.Left);
            }

            return tree.Data;
        }


        new public void removeItem(T item)
        {
            removeItem(item, ref root);
        }

        //Remove from AVL tree
        private void removeItem(T item, ref Node<T> tree)
        {

            //If empty 
            if (tree == null)
            {
                return;
            }

            ////If no such item
            //if (!this.Contains(item))
            //{
            //    return;
            //}
            else
            {

                //if no children
                if (tree.Left == null && tree.Right == null)
                {
                    tree = null;
                    return;

                }
                //if one child
                else if (tree.Left == null && tree.Right != null)
                {

                    tree = tree.Right;

                }
                else if (tree.Right == null && tree.Left != null)
                {

                    tree = tree.Left;
                }

                //if two children
                else if (tree.Right != null && tree.Left != null)
                {

                    T newRoot = leastItem(tree.Right);
                    tree.Data = newRoot;
                    removeItem(tree.Data, ref tree.Right);

                    tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);
                    if (tree.BalanceFactor <= -2)
                        rotateLeft(ref tree);
                    else if (tree.BalanceFactor >= 2)
                        rotateRight(ref tree);

                }
            }

        }
    }
}

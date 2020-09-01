using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Teacher
{
    /* Parent class for AVLTree - note the addition of 'retrieve' method based on contains, and a getallnodes method*/
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T item)
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
        }

        public int Max(int x, int y)
        {
            if (x > y)
            { return x; }
            else if (y > x)
            { return y; }
            else if (y == x)
            {
                return x;
            }
            else
            { return x; }
        }

        public int Height()
        {
            return Height(root);
        }
        protected int Height(Node<T> root)
        //Return the max level of the tree
        {

            if (root == null)
            { return 0; }
            else
            {
                return 1 + Max(Height(root.Left), Height(root.Right));
            }


        }

        //This method returns an unordered linkedlist containing all the nodes within the tree
        public LinkedList<T> GetAllNodes()
        {
            LinkedList<T> nodes = new LinkedList<T>();
            return GetAllNodes(root, nodes);
        }
        private LinkedList<T> GetAllNodes(Node<T> root, LinkedList<T> nodes)
        {
            
                if (root == null)
                { }

                else if (root.Left != null)
                {
                    nodes.AddFirst(root.Left.Data);
                    GetAllNodes(root.Left, nodes);
                }

                if (root.Right != null)
                {
                    nodes.AddLast(root.Right.Data);
                    GetAllNodes(root.Right, nodes);
                }
            
            return nodes;

        }

        public int Count()
        {
            return Count(root);
        }

        private int Count(Node<T> root)
        //Return the number of nodes in the tree
        {
            int counter = 0;

            if (root == null)
            { return 0; }

            else if (root.Left != null)
            {
                counter += Count(root.Left);

            }

            if (root.Right != null)
            {
                counter += Count(root.Right);

            }
            return 1 + counter;
        }

        /*Method to allow user to update an object. This requires that the object's key (data used by compareto)
        remains the same. This method is therefore only useful for objects with at least two parameters*/
        public void Update(T item)
        {
            Update(item, ref root);
        }
        
        private void Update(T item, ref Node<T> root)
        {
            if (root == null)
            {
                Console.WriteLine("No such object to replace");
                return;
            }

            else if (item.CompareTo(root.Data) < 0)
            {
                Update(item, ref root.Left);
            }

            else if (item.CompareTo(root.Data) > 0)
            {
                Update(item, ref root.Right);

            }
            //If object found
            else if (item.CompareTo(root.Data) == 0)
            {
                //replace root.data with method parameter item
                root.Data = item;
                return;
            }
            
        }

        public Boolean Contains(T item)
        {
            return Contains(item, ref root);
        }

        private Boolean Contains(T item, ref Node<T> root)
        //Return true if the item is contained in the BSTree, false       //otherwise.
        {

            if (root == null)
            {
                return false;
            }
            else  if (item.CompareTo(root.Data) < 0)
            {
                return Contains(item, ref root.Left);
            }

            else if (item.CompareTo(root.Data) > 0)
            {
                return Contains(item, ref root.Right);

            }
            else if (item.CompareTo(root.Data) == 0)
            {
                return true;
            }
            return false;
        }

        //This method returns the item in the tree with the same key (parameter used by CompareTo)
        public T Retrieve(T item)
        {
            return Retrieve(item, ref root);
        }

        private T Retrieve(T item, ref Node<T> root)
        //Find item in tree and return      //otherwise.
        {
            if (root == null)
            {
                return item;
            }
            if (item.CompareTo(root.Data) == 0)
            {
                return root.Data;
            }
            if (item.CompareTo(root.Data) < 0)
            {
                return Retrieve(item, ref root.Left);
            }

            else if (item.CompareTo(root.Data) > 0)
            {
                return Retrieve(item, ref root.Right);

            }
            return default(T);
        }




        public T leastItem()
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

        public void removeItem(T item)
        {
            removeItem(item, ref root);
        }

        private void removeItem(T item, ref Node<T> tree)
        {

            //if null 
            if (tree == null)
            {
                
            }

            else
            {
                //go left
                if (item.CompareTo(tree.Data) < 0)
                { removeItem(item, ref tree.Left); }
                //go right
                else if (item.CompareTo(tree.Data) > 0)
                { removeItem(item, ref tree.Right); }

                //if no children
                if (tree.Left == null && tree.Right == null)
                {
                    tree = null;
                }
                //if one child
                else if (tree.Left == null)
                    {

                    tree = tree.Right;
                    }

                    else if (tree.Right == null)
                    {
                        
                        tree = tree.Left;
                    }
                //if two children
                    else
                    {

                    T newRoot = leastItem(tree.Right);
                    tree.Data = newRoot;
                    removeItem(tree.Data, ref tree.Right.Left);
                    }
                }
                }

             
            }

        }
    


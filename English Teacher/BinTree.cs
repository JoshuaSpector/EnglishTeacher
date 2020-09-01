using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Teacher
{
    class BinTree<T> where T : IComparable
    {
        protected Node<T> root;
        public BinTree()  //creates an empty tree
        {
            root = null;
        }
        public BinTree(Node<T> node)  //creates a tree with node as the root
        {
            root = node;
        }

        public void InOrder(ref string buffer)
        {
            inOrder(root, ref buffer);
        }

        public void preOrder(ref string buffer)
        {
            preOrder(root, ref buffer);
        }

        public void postOrder(ref string buffer)
        {
            postOrder(root, ref buffer);
        }


        private void inOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                inOrder(tree.Left, ref buffer);
                buffer += tree.Data.ToString() + ",";
                inOrder(tree.Right, ref buffer);
            }
        }

        //This method returns an unordered linkedlist containing all the nodes within the tree
        public LinkedList<T> getNodes(LinkedList<T> list)
        {
            return getNodes(root, list);
        }
        private LinkedList<T> getNodes(Node<T> tree, LinkedList<T> list)
        {
            if (tree != null)
            {
                
                if (tree.Left != null)
                {

                    if (list.Contains(tree.Data) == false)
                    {
                        list.AddFirst(tree.Data);
                    }
                    getNodes(tree.Left, list);
                    
                }

                if (tree.Right != null)
                {
                    if (list.Contains(tree.Data) == false)
                    {
                        list.AddFirst(tree.Data);
                    }
                    getNodes(tree.Right, list);

                }
                if (list.Contains(tree.Data) == false)
                {
                    list.AddFirst(tree.Data);
                }
                return list;
            }
            return null;
        }



        private void preOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                buffer += tree.Data.ToString() + ",";
                preOrder(tree.Left, ref buffer);
                preOrder(tree.Right, ref buffer);
            }
        }


        private void postOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                postOrder(tree.Left, ref buffer);
                postOrder(tree.Right, ref buffer);
                buffer += tree.Data.ToString() + ",";
            }
        }



    }

}

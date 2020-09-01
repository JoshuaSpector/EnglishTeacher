using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Teacher
{
  
        class Node<T> where T : IComparable
        /*This class defines a node
         * for the Binary Tree implementations
         */
        {
            private T data;
            private int balanceFactor = 0;
            public Node<T> Left, Right;

            public Node(T item)
            {
                data = item;
                Left = null;
                Right = null;
            }
            public T Data
            {
                set { data = value; }
                get { return data; }
            }


          //Balance factor is used by the AVL tree to ensure it remains even and minimises depth
          public int BalanceFactor
             {
            set { balanceFactor = value; }
            get { return balanceFactor; }
        }

        }

    
}

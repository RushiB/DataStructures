using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinearDataStrucs
    {
        /*
         * https://www.geeksforgeeks.org/overview-of-data-structures-set-1-linear-data-structures/
            Array
            Linked List 
            Stack
            Queue
         */

        //TODO
        /*  Linked List 
            Stack
            Queue
         */

        /// <summary>
        /// linked list has a Head
        /// 
        /// each node has value and pointer to next node
        /// note - next node pointer would be null for last node (for non circular linked list)
        /// </summary>


        public class node
        {
            int value;
            node nextNode = null;

            // constructor
            public node(int val)
            {
                value = val;
            }

            public int GetValue()
            {
                return value;
            }

            public node GetNextNode()
            {
                return nextNode;
            }
            
            public void SetNextNode(ref node next)
            {
                nextNode = next;
            }
        }

        public class ALinkedList
        {
            private node head;

            public node GetHeadNode()
            {
                return head;
            }

            // TODO - creation and insertion

            public ALinkedList()
            {
                head = null;
            }
             
            public void AddNode(int x)
            {
                var newNode = new node(x);
                var temp = head;

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    while (temp != null)
                    {
                        if (temp.GetNextNode() == null)
                        {
                            temp.SetNextNode(ref newNode);
                            break;
                        }
                        else
                        {
                            temp = temp.GetNextNode();
                        }
                    }
                }
            }

        }

        public void TraverseList(node headNode)
        {
            if (headNode == null)
            {
                Console.WriteLine("LL is empty!");
            }
            else
            {
                int count = 0;
                node temp = headNode;
                while (temp != null)
                {
                    Console.WriteLine($"Inside node#{count} with value = {temp.GetValue()}");
                    count++;
                    temp = temp.GetNextNode();
                }
            }

        }


        public void TestLinkedList()
        {
            ALinkedList myLl = new ALinkedList();
            myLl.AddNode(1);
            myLl.AddNode(2);
            myLl.AddNode(3);
            myLl.AddNode(4);

            TraverseList(myLl.GetHeadNode());
            
        }
    }
}

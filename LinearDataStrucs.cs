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
        /*  
            Stack
            Queue
         */

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

            public void SetValue(int newVal)
            {
                value = newVal;
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

        // Linked list - to do variations:
        //      - circular linked list
        //      - and circular doubly linked list

        #region LinkedList
        /// <summary>
        /// linked list has a Head
        /// 
        /// each node has value and pointer to next node
        /// note - next node pointer would be null for last node (for non circular linked list)
        /// </summary>

        public class ALinkedList
        {
            private node head;

            public node GetHeadNode()
            {
                return head;
            }

            public void SetHeadNode(ref node newHead)
            {
                head = newHead;
            }

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

        public void DeleteNodeWithVal(int val, ALinkedList list1)
        {
            Console.WriteLine($"Delete node with value {val}");

            if (list1 != null)
            {
                node currNode = list1.GetHeadNode();
                while (currNode != null)
                {
                    node nextNode = currNode.GetNextNode();
                    if (currNode.GetValue() == val)
                    {
                        if (nextNode != null)
                        {
                            currNode.SetValue(nextNode.GetValue());
                            node z = nextNode.GetNextNode();
                            currNode.SetNextNode(ref z);
                            break;
                        }
                    }
                    else
                    {
                        currNode = nextNode;
                    }
                }
            }
            else //temp = null
            {
                Console.WriteLine("Linked list is empty, cannot remove the given val as it does not exist!");
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

            DeleteNodeWithVal(3, myLl);

            TraverseList(myLl.GetHeadNode());
        }

        #endregion


        #region Doubly LL

        class nodeDuo : node // DoubleLinked
        {
            public nodeDuo nextNode = null;
            public nodeDuo prevNode = null;

            public nodeDuo(int val) : base(val)
            {
                SetValue(val);
            }
        }

        class DoubleLinkedList
        {
            nodeDuo head = null;
            //nodeDuo tail = null;

            public void AddNode(int x)
            {
                nodeDuo newNode = new nodeDuo(x);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    nodeDuo currNode = head;

                    while(currNode != null)
                    {
                        if (currNode.nextNode == null)
                        {
                            currNode.nextNode = newNode;
                            newNode.prevNode = currNode;
                            break;
                        }
                        else
                        {
                            currNode = currNode.nextNode;
                        }
                    }
                }
            }

            public void DeleteNode(int x)
            {
                if(head == null)
                {
                    Console.WriteLine("LL is empty!");
                }
                else
                {
                    var currNode = head;

                    while(currNode != null)
                    {
                        if (currNode.GetValue() == x)
                        {
                            var nextNode = currNode.nextNode;
                            var prevNode = currNode.prevNode;

                            // first and last nodes prev and next nodes might not be there!
                            if(prevNode != null)
                            {
                                prevNode.nextNode = nextNode;
                            }
                            else
                            {
                                // we are deleting head, so update head node
                                head = nextNode;
                            }
                            if (nextNode != null)
                            {
                                nextNode.prevNode = prevNode;
                            }
                             
                            Console.WriteLine($"Found a node with value {x} and deleted it.");
                        }
                        currNode = currNode.nextNode;
                    }
                }
            
            }

            public void TraverseList()
            {
                nodeDuo currNode = head;
                nodeDuo lastNode = null;

                Console.WriteLine("Traversing top to bottom:");
                while (currNode != null)
                {
                    Console.WriteLine($"current node value = {currNode.GetValue()}");
                    lastNode = currNode;
                    currNode = currNode.nextNode;
                }

                Console.WriteLine("Traversing bottom to top:");
                currNode = lastNode;

                while (currNode != null)
                {
                    Console.WriteLine($"current node value = {currNode.GetValue()}");

                    currNode = currNode.prevNode;
                }
            }

        }

        public void TestDoubleLL()
        {
            var myLl = new DoubleLinkedList();
            myLl.AddNode(1);
            myLl.AddNode(2);
            myLl.AddNode(3);
            myLl.AddNode(10);
            myLl.AddNode(10);
            myLl.AddNode(4);

            myLl.TraverseList();

            myLl.DeleteNode(10); //1 //3 //4
            myLl.TraverseList();
        }

        #endregion



        #region Stacks

        // can be implemented using array and LinkedList


        // impl using LL
        class AStack : ALinkedList
        {
            node initialNode = null; // initial node = head of LL = bottom of stack
            node top = null;

            public node GetTopOfStack()
            {
                // top of stack would be last node added to the list
                if (initialNode == null)
                {
                    initialNode = GetHeadNode();
                }
                // check head again if null
                if (initialNode == null)
                {
                    // this means list is empty and tail will also be null
                    top = null;
                }
                else
                {
                    node temp = initialNode.GetNextNode();
                    if (temp == null)
                    {
                        top = initialNode;
                    }
                    else
                    {
                        while (temp != null)
                        {
                            if (temp.GetNextNode() != null)
                            {
                                temp = temp.GetNextNode();
                            }
                            else
                            {
                                break;
                            }
                        }
                        
                        top = temp;
                    }
                }

                return top;
            }

            public void Push(int n)
            {
                //AddNode(n);
                top = GetTopOfStack();
                if (top == null)
                {
                    // todo
                }
                else
                {

                }

            }

            public node Pop()
            {
                node temp = null;




                return temp;
            }

        }



        #endregion



        #region le

        #endregion


    }
}

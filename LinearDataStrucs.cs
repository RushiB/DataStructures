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

        // todo - update add node to use tail node (instead of having to go through full list all time!

        class DoubleLinkedList
        {
            public nodeDuo head = null;
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

            public void TraverseList() //int direction = 0)
            {
                nodeDuo currNode = head;
                nodeDuo lastNode = null;
                /*
                // (direction== 0) // default do it both directions
                bool topToBottom = true;
                bool bottomToTop = true;

                if (direction == 1) 
                {
                    bottomToTop = true;
                    topToBottom = false;
                }
                else if (direction == -1)
                {
                    bottomToTop = false;
                    topToBottom = true;
                }
                */
                if (currNode == null)
                {
                    Console.WriteLine("LL is empty!");
                }
                else
                {
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

        #region Stacks - with LL

        // can be implemented using array and LinkedList


        // impl using LL
        class AStack : DoubleLinkedList
        {
            //nodeDuo initialNode = null; // initial node = head of LL = bottom of stack
            public nodeDuo top = null;
            public nodeDuo bottom = null;

            // same as peek
            public int GetTopOfStack()
            {
                return top.GetValue();
            }

            public void Push(int n)
            {
                nodeDuo newNode = new nodeDuo(n);

                if (bottom == null)
                {
                    bottom = newNode;
                    top = bottom;
                }
                else
                {
                    nodeDuo currNode = top;
                    
                    currNode.nextNode = newNode;
                    newNode.prevNode = currNode;

                    top = newNode;
                }
            }

            public int Pop()
            {
                // remove top and return
                nodeDuo poppedNode = top;

                if (top == null)
                {
                    Console.WriteLine("Stack is empty! returning null.");
                }
                else
                {
                    var prevNode = top.prevNode;

                    if (prevNode == null)
                    {
                        // this means we have only single node in stack
                        // stack will be empty now
                        poppedNode = bottom;

                        top = null;
                        bottom = null;
                    }
                    else
                    {
                        prevNode.nextNode = null;
                        top = prevNode;
                    }
                }

                return poppedNode.GetValue();
            }

            public new void TraverseList()
            {
                head = bottom;
                ((DoubleLinkedList)this).TraverseList();
            }

        }

        public void TestMyStack()
        {
            var myStack = new AStack();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(10);
            myStack.Push(4);
            myStack.Push(10);
            myStack.Push(5);

            myStack.TraverseList();

            myStack.DeleteNode(10); //1 //3 //4
            myStack.TraverseList();

            var y = myStack.Pop();
            Console.WriteLine($"\n\nPopped-item = {y}");

            var x = myStack.GetTopOfStack();
            Console.WriteLine($"\n\nTopOfStack = {x}");
            
            myStack.TraverseList();
        }


        #endregion

        //TODO
        #region stack with array

        class AStackArray
        {
            nodeDuo[] list = {};

            public void AddNode(int x)
            {
                if (list.Length == 0)
                {
                    //TODO
                    //list.Add(new nodeDuo(x));
                }
            }


        }


        #endregion



        #region Queue

        class Queue : DoubleLinkedList
        {
            nodeDuo first = null;
            nodeDuo last = null;

            public void enqueue(int x)
            {
                nodeDuo newNode = new nodeDuo(x);

                if(first == null && last == null)
                {
                    first = newNode;
                    last = first;
                }
                else if (first != null || last != null) 
                {
                    last.nextNode       = newNode;
                    newNode.prevNode    = last;
                    last                = newNode;
                }
                else if ((first == null || last != null)|| (first != null || last == null))
                {
                    // this shud not happen
                    Console.WriteLine("WARNING!");
                }
            }

            public int dequeue()
            {
                int returnVal = int.MinValue;

                if (first == null && last == null)
                {
                    Console.WriteLine();
                    return int.MinValue;
                    //throw new Exception("deque called on an empty queue!");
                }
                else
                {
                    // breaking when empty - fix it
                    returnVal = first.GetValue();

                    first = first.nextNode;

                    if (first != null)
                    {
                        first.prevNode = null;
                    }
                }

                return returnVal;
            }

            public bool isEmpty()
            {
                return (first == null && last == null);
            }

            public new void TraverseList()
            {
                head = first;
                ((DoubleLinkedList)this).TraverseList();
            }

        }

        public void TestMyQue()
        {
            var myQue = new Queue();
            myQue.enqueue(1);
            myQue.enqueue(2);
            myQue.enqueue(3);
            //myQue.enqueue(10);
            //myQue.enqueue(4);
            //myQue.enqueue(10);
            //myQue.enqueue(5);
            //myQue.enqueue(6);

            myQue.TraverseList();

            var y = myQue.dequeue();
            Console.WriteLine($"\n\n dequeued-item = {y}");
            myQue.TraverseList();

            y = myQue.dequeue();
            Console.WriteLine($"\n\n dequeued-item = {y}");
            myQue.TraverseList();
            
            y = myQue.dequeue();
            Console.WriteLine($"\n\n dequeued-item = {y}");
            myQue.TraverseList();

        }

        #endregion


    }
}

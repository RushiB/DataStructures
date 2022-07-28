﻿using System;
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

            public node GetNextNode()
            {
                return nextNode;
            }
            
            public void SetNextNode(node next)
            {
                nextNode = next;
            }
        }

        public class ALinkedList
        {
            node head;

            // TODO - creation and insertion

            public ALinkedList()
            {
                head = null;
            }

            //TODO - test if it works!!
            public void AddNode(int x)
            {
                var newNode = new node(x);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    var temp = head.GetNextNode();
                    while(temp != null)
                    {
                        temp = temp.GetNextNode();
                    }

                    temp.SetNextNode(newNode);
                }
            }

        }


    }
}

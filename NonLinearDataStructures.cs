﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace DataStructures
{
    public class NonLinearDataStructures
    {
        // todo
        // binary tree
        //   - traversal, add, delt

        // n-ary tree


        public class node
        {
            public int value;
            public node[] children = { null, null };

            // constructor
            public node(int val)
            {
                value = val;
            }
        }


        class Tree
        {
            node root = null;

            
            public void AddNode(int x)
            {
                var newNode = new node(x);

                if (root == null)
                {
                    root = newNode;
                }
                else
                {
                    var currNode = root;

                    while(currNode != null)
                    {
                        if (currNode.value > x)
                        {
                            if (currNode.children[0] == null)
                            {
                                currNode.children[0] = newNode;
                                break;
                            }
                            else
                            {
                                currNode = currNode.children[0];
                            }
                        }
                        else
                        {
                            if (currNode.children[1] == null)
                            {
                                currNode.children[1] = newNode;
                                break;
                            }
                            else
                            {
                                currNode = currNode.children[1];
                            }
                        }

                    }

                }
            }

        
        
        
        }

        public void TestTree()
        {
            var tree = new Tree();
            tree.AddNode(50);
            tree.AddNode(27);
            tree.AddNode(61);
            
            tree.AddNode(45);
            tree.AddNode(19);
            
            //tree.AddNode(72);
            //tree.AddNode(56);
            //tree.AddNode(58);
            //tree.AddNode(52);
            //tree.AddNode(47);


        }




    }
}

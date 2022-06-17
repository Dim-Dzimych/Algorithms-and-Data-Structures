using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
        }
    }

    public class Node
    {
        public Node Next;
        public int Value;
        public Node(int value)
        {
            Value = value;
        }
    }

    public class LinkedList
    {
        private Node Head;
        private Node Tail;

        public void AddLast(int data)
        {
            var node = new Node(data);
            if (Tail == null) // haven't node, add to tail 
            { 
                Tail = node;
                Head = Tail;
            }
            else // from our node create link to next node as new and new node make Tail
            {
                Tail.Next = node;
                Tail = node;
            }
        }

        public void AddFirst(int data)
        {
            Node node = new Node(data);
            if (Head == null) // no node, make first node as Head = Tail
            {
                Head = Tail = node;
                return;
            }

            if (Head != null) // have one or more node
            {
                node.Next = Head; // from new node make link to Head, than new node call Head;
                Head = node;
            }
        }

        public void Remove(int data)
        {
            var currentNode = Head;
            Node previousNode = null;
            while (currentNode != null)
            {
                if (currentNode.Value == data
                    && currentNode.Value == data) // have found node for removing
                {
                    if (Head == currentNode) // if first node is head
                    {
                        Head = currentNode.Next;
                        currentNode = null;
                        break;
                    }
                    previousNode.Next = currentNode.Next; // delete node between
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        public void Print()
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}

// AddLast/First - O(1)
// Remove - O(1)
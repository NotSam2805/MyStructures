using System;
using System.Collections.Generic;
using System.Text;

namespace MyStructures
{
    class DoubleLinkedList<T> : LinkedList<T>
    {
        public DoubleLinkedList(T firstNode) : base(firstNode)
        {
            nodes[0].pointers[1] = 0;
        }

        private void TraverseBack(Node<T> findNode, Node<T> startNode)
        {
            indexes = new Stack<int>(nodes.Length);
            int currentIndex = startNode.pointers[1];
            bool found = false;
            while (!found)
            {
                indexes.Push(currentIndex);
                if (nodes[currentIndex] == findNode)
                {
                    found = true;
                }
                else
                {
                    currentIndex = nodes[currentIndex].pointers[1];
                }
            }
        }

        private void TraverseBack(int places, int startPoint)
        {
            indexes = new Stack<int>(nodes.Length);
            int currentIndex = startPoint;
            int count = 0;
            while (count <= places)
            {
                indexes.Push(currentIndex);
                currentIndex = nodes[currentIndex].pointers[1];
                count++;
            }
        }

        public override void Add(T newNode)
        {
            base.Add(newNode);
            Traverse(newNode);
            nodes[indexes.Pop()].pointers[1] = indexes.Pop();
        }

        public override void Delete(T deletedNode)
        {
            Traverse(deletedNode);
            int oldPointer0 = nodes[indexes.Peek()].pointers[0];
            int oldPointer1 = nodes[indexes.Pop()].pointers[1];
            nodes[indexes.Pop()].pointers[0] = oldPointer0;
            nodes[oldPointer0].pointers[1] = oldPointer1;
        }
    }
}

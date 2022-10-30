using System;
using System.Collections.Generic;
using System.Text;

namespace MyStructures
{
    class Queue<T>
    {
        private T[] queue;
        private int tail;
        private int head;
        private int size;

        public Queue(int size_)
        {
            size = size_;
            queue = new T[size];
            head = 0;
            tail = 0;
        }

        public void Enqueue(T data)
        {
            if (((tail + 1) % size) == head)
            {
                Console.WriteLine("Queue is full");
            }
            else
            {
                queue[tail] = data;
                tail = (tail + 1) % size;
            }
        }

        public T Dequeue()
        {
            if (head == tail)
            {
                Console.WriteLine("Queue is empty");
                return queue[head];
            }
            else
            {
                int oldHead = head;
                head = (head + 1) % size;
                return queue[oldHead];
            }
        }

        public T Peek()
        {
            return queue[head];
        }

        public T Peek(int index)
        {
            return queue[index];
        }
    }
}

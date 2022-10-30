using System;
using System.Collections.Generic;
using System.Text;

namespace MyStructures
{
    class Stack<T>
    {
        private T[] stack;
        private int top;
        public readonly int size;

        public Stack(int size_)
        {
            size = size_;
            top = 0;
            stack = new T[size];
        }

        public void Push(T data)
        {
            if (top == size)
            {
                Console.WriteLine("Stack is full");
            }
            else
            {
                stack[top] = data;
                top += 1;
            }
        }

        public T Pop()
        {
            if (top == 0)
            {
                Console.WriteLine("Stack is empty");
                return stack[top];
            }
            else
            {
                top -= 1;
                return stack[top + 1];
            }
        }

        public T Peek()
        {
            return stack[top];
        }

        public T Peek(int index)
        {
            return stack[index];
        }
    }
}

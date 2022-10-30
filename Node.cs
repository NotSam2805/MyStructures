using System;
using System.Collections.Generic;
using System.Text;

namespace MyStructures
{
    class Node<T>
    {
        public T data;
        public int[] pointers;

        public Node(T _data, int[] _pointers)
        {
            data = _data;
            pointers = _pointers;
        }
    }
}

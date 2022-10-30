namespace MyStructures
{
    class LinkedList<T>
    {
        protected Node<T>[] nodes;
        protected Stack<int> indexes;

        public LinkedList(T firstNode)
        {
            nodes = new Node<T>[2];
            nodes[0] = new Node<T>(firstNode, new int[2]);
            nodes[0].pointers[0] = 1;
            indexes = new Stack<int>(nodes.Length);
        }

        protected void Traverse(T findNode)
        {
            indexes = new Stack<int>(nodes.Length);
            int currentIndex = 0;
            bool found = false;
            while (!found)
            {
                indexes.Push(currentIndex);
                if (nodes[currentIndex].data.Equals(findNode))
                {
                    found = true;
                }
                else
                {
                    currentIndex = nodes[currentIndex].pointers[0];
                }
            }
        }

        protected void Traverse(Node<T> findNode)
        {
            indexes = new Stack<int>(nodes.Length);
            int currentIndex = 0;
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
                    currentIndex = nodes[currentIndex].pointers[0];
                }
            }
        }

        protected void Traverse(int nodeNum)
        {
            int count = 0;
            int currentIndex = 0;
            indexes = new Stack<int>(nodes.Length);
            while (count <= nodeNum)
            {
                indexes.Push(currentIndex);
                currentIndex = nodes[currentIndex].pointers[0];
                count++;
            }
        }

        public virtual void Add(T newNode)
        {
            Node<T>[] oldNodes = nodes;
            nodes = new Node<T>[oldNodes.Length + 1];

            for (int i = 0; i < oldNodes.Length; i++)
            {
                nodes[i] = oldNodes[i];
            }

            Node<T> addNode = new Node<T>(newNode, new int[2]);
            Traverse(null);
            int addNodeIndex = indexes.Pop();
            nodes[addNodeIndex] = addNode;
            nodes[addNodeIndex].pointers[0] = oldNodes.Length;
            nodes[indexes.Pop()].pointers[0] = addNodeIndex;
        }

        public virtual void Delete(T deletedNode)
        {
            Traverse(deletedNode);
            int oldPointer = nodes[indexes.Pop()].pointers[0];
            nodes[indexes.Pop()].pointers[0] = oldPointer;
        }

        public virtual void Insert(T newNode, T nodeBefore)
        {

            Node<T>[] oldNodes = nodes;
            nodes = new Node<T>[oldNodes.Length + 1];

            for (int i = 0; i < oldNodes.Length; i++)
            {
                nodes[i] = oldNodes[i];
            }

            Traverse(nodeBefore);
            int nodeB4Index = indexes.Pop();
            Node<T> addNode = new Node<T>(newNode, new int[2]);
            addNode.pointers[0] = nodes[nodeB4Index].pointers[0];
            nodes[oldNodes.Length] = addNode;
            nodes[nodeB4Index].pointers[0] = oldNodes.Length;
        }

        public virtual T GetNode(int place)
        {
            Traverse(place);
            return nodes[indexes.Pop()].data;
        }

        public virtual string PrintNodes()
        {
            string print = "";
            Traverse(null);
            Stack<int> reverseIndex = new Stack<int>(indexes.size);

            for(int i = 0; i < indexes.size; i++)
            {
                reverseIndex.Push(indexes.Pop());
            }

            for(int i = 0; i < reverseIndex.size; i++)
            {
                print += nodes[reverseIndex.Pop()].data.ToString();
            }

            return print;
        }
    }
}

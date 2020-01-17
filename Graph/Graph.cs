using System;
using System.Collections.Generic;
using System.Text;

namespace _15012020_graph
{
    public class Node
    {
        public NodeIterator Iterator;
        public List<Node> Links;
        public int Data;
        public bool Visited = false;

        public void AllChildrenVisitedEvent()
        {
            // Событие, которое вызывается, если все потомки данного узла посещены, либо, если у него нет потомков
            Console.WriteLine(String.Format("node with data [{0}] registered event\n", Data));
        }

        public Node(int pData)
        {           
            Data = pData;
            Links = new List<Node>();
            Iterator = new NodeIterator(this);
        }

        public int Count
        {
            get { return Links.Count; }
            protected set { }
        }

        public Node this[int index]
        {
            get { return Links[index]; }
            set { Links.Insert(index, value); }
        }

        public void Add(Node child)
        {
            Links.Add(child);
        }

        public void Print()
        {
            string links = "";

            foreach (Node node in Links)
            {
                links += node.Data.ToString() + " ";
            }

            Console.WriteLine(String.Format("node with data [{0}] has links: [{1}]\n", Data, links));
        }
    }

    public class Graph
    {
        public Node Start;

        protected static int _counter = 0;

        public Graph()
        {
            Start = new Node(_counter);
            _counter += 1;
        }

        public Node Add(Node parent)
        {
            Node node = new Node(_counter);
            _counter += 1;
            parent.Add(node);
            return node;
        }
    }
}

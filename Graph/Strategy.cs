using System;
using System.Collections.Generic;
using System.Text;

namespace _15012020_graph
{

    public interface IStrategy
    {
        public void Process(Graph graph);
    }

    public class DeepCrawl : IStrategy
    {
        public void Deep(Node pNode)
        {
            pNode.Visited = true;
            Console.WriteLine(String.Format("node with data [{0}] visited",pNode.Data));
            //pNode.Print();

            NodeIterator iterator = pNode.Iterator;
            iterator.Reset();

            while (iterator.IsDone() == false)
            {
                Node node = iterator.Next() as Node;

                if (node.Visited == false)
                {
                    Deep(node);
                }
            }

        }

        public void Reset(Node pNode)
        {
            pNode.Visited = false;
            
            NodeIterator iterator = pNode.Iterator;
            iterator.Reset();

            while (iterator.IsDone() == false)
            {
                Node node = iterator.Next() as Node;

                if (node.Visited == true)
                {
                    Reset(node);
                }
            }

        }

        public void Process(Graph graph)
        {
            Deep(graph.Start);

            // Сбросим состояние
            Reset(graph.Start);
        }
    }

    public class BreadthCrawl : IStrategy
    {
        Queue<Node> q = new Queue<Node>();

        public void BFS(Node pNode)
        {
            pNode.Visited = true;
            q.Enqueue(pNode);

            Node node;

            while (q.Count != 0)
            {
                node = q.Dequeue();
                Console.WriteLine(String.Format("node with data [{0}] visited", node.Data));

                NodeIterator iterator = node.Iterator;
                iterator.Reset();

                while (iterator.IsDone() == false)
                {
                    Node next_node = iterator.Next() as Node;

                    if (next_node.Visited == false) { 
                        next_node.Visited = true;
                        q.Enqueue(next_node);
                    }
                }
            }
        }

        public void Process(Graph graph)
        {
            BFS(graph.Start);
        }
    }
}

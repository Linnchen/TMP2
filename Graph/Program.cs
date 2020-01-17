using System;

namespace _15012020_graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            Node node;
            Node inner_node;
            Node double_inner_node;
            // Соорудим пример графа
            node = graph.Add(graph.Start);
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    double_inner_node = graph.Add(inner_node);
                    double_inner_node.Add(node);
            
            node.Add(double_inner_node);
            
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    graph.Add(inner_node);
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    graph.Add(inner_node);

            node = graph.Add(graph.Start);
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    graph.Add(inner_node);
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    graph.Add(inner_node);
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    graph.Add(inner_node);

            node = graph.Add(graph.Start);
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    graph.Add(inner_node);
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    graph.Add(inner_node);
                inner_node = graph.Add(node);
                    graph.Add(inner_node);
                    graph.Add(inner_node);

            
            Console.WriteLine("В глубину");

            // Обход в глубину 
            IStrategy deep = new DeepCrawl();
            deep.Process(graph);

            Console.WriteLine("В ширину");

            // Обход в ширину
            IStrategy breadtр = new BreadthCrawl();
            breadtр.Process(graph);


        }
    }
}

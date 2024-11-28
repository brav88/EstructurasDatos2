using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EstructurasDatos2
{
	internal class StartGraph
	{
		public void Start()
		{
			int opt;
			string vopt = string.Empty;
			Graph graph = new Graph();

			do
			{
				Console.WriteLine("What do you want to do in the Graph?");
				Console.WriteLine("1. Add Node");
				Console.WriteLine("2. Add Edge");
				Console.WriteLine("3. Remove Edge");
				Console.WriteLine("4. Print");
				Console.WriteLine("9. Exit");

				do
				{
					Console.WriteLine("Please choose an option with a number");
					vopt = Console.ReadLine();
				} while (!int.TryParse(vopt, out opt));

				if (opt == 1)
				{
					Console.WriteLine("Value:");
					int num = Convert.ToInt16(Console.ReadLine());

					graph.AddNode(num);
				}

				if (opt == 2)
				{
					Console.WriteLine("Value1:");
					int num1 = Convert.ToInt16(Console.ReadLine());

					Console.WriteLine("Value2:");
					int num2 = Convert.ToInt16(Console.ReadLine());

					graph.AddEdge(num1, num2);
				}

				if (opt == 3)
				{
					Console.WriteLine("Value1:");
					int num1 = Convert.ToInt16(Console.ReadLine());

					Console.WriteLine("Value2:");
					int num2 = Convert.ToInt16(Console.ReadLine());

					graph.RemoveEdge(num1, num2);
				}

				if (opt == 4)
				{
					graph.PrintGraphVisual();
				}

			} while (opt != 9);

			Console.ReadLine();
		}
	}

	internal class Graph
	{
		List<GraphNode> nodes;		

		public Graph() 
		{
			nodes = new List<GraphNode>();
		}

		public void AddNode(int value)
		{
			if(FindNode(value) == null)
			{
				GraphNode node = new GraphNode(value);
				nodes.Add(node);
				Console.WriteLine("Node included in the Graph");
			}
			else
			{
				Console.WriteLine("Node already exists");
			}			
		}

		public void AddEdge(int value1, int value2)
		{
			GraphNode node1 = FindNode(value1);
			GraphNode node2 = FindNode(value2);

			if(node1 != null && node2 != null)
			{
				if(!node1.Adjacents.Contains(node2) && !node2.Adjacents.Contains(node1))
				{
					node1.Adjacents.Add(node2);
					node2.Adjacents.Add(node1);
				}
			}
		}

		public void RemoveEdge(int value1, int value2)
		{
			GraphNode node1 = FindNode(value1);
			GraphNode node2 = FindNode(value2);

			if (node1 != null && node2 != null)
			{
				if (node1.Adjacents.Contains(node2) && node2.Adjacents.Contains(node1))
				{
					node1.Adjacents.Remove(node2);
					node2.Adjacents.Remove(node1);
				}
			}
		}

		public void PrintGraph()
		{
			Console.WriteLine("Graph************************************");
			foreach (GraphNode node in nodes)
			{				
				Console.WriteLine("Node " + node.Value + " has this adjacent list:");
				foreach (GraphNode nodeAdj in node.Adjacents)
				{					
					Console.WriteLine(nodeAdj.Value);
				}
			}
		}

		public void PrintGraphVisual()
		{
			Console.WriteLine("Graph:");

			HashSet<int> printedEdges = new HashSet<int>();

			foreach (var node in nodes)
			{
				Console.Write($"Node {node.Value}: ");

				foreach (var adj in node.Adjacents)
				{
					int edgeHash = GenerateEdgeHash(node.Value, adj.Value);
					
					if (!printedEdges.Contains(edgeHash))
					{
						Console.Write($"→ {adj.Value} ");
						printedEdges.Add(edgeHash);
					}
				}

				Console.WriteLine();
			}
		}

		private int GenerateEdgeHash(int value1, int value2)
		{
			
			return Math.Min(value1, value2) * 1000000 + Math.Max(value1, value2);
		}

		public GraphNode FindNode(int value)
		{
			return nodes.Find(n => n.Value == value);
		}
	}	
}

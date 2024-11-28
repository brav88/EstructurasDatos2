using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
	internal class StartWeightedGraph
	{
		public void Start()
		{
			int opt;
			string vopt = string.Empty;
			WeightedGraph graph = new WeightedGraph();

			do
			{
				Console.WriteLine("What do you want to do in the Graph?");
				Console.WriteLine("1. Add Node");
				Console.WriteLine("2. Add Edge");
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

					Console.WriteLine("Weight:");
					int weight = Convert.ToInt16(Console.ReadLine());

					graph.AddEdge(num1, num2, weight);
				}


				if (opt == 4)
				{
					graph.PrintGraph();
				}

			} while (opt != 9);

			Console.ReadLine();
		}
	}

	internal class WeightedGraph
	{
		List<WeightedNode> nodes;

		public WeightedGraph()
		{
			nodes = new List<WeightedNode>();
		}

		public void AddNode(int value)
		{
			if (FindNode(value) == null)
			{
				WeightedNode node = new WeightedNode(value);
				nodes.Add(node);
				Console.WriteLine("Node included in the Graph");
			}
			else
			{
				Console.WriteLine("Node already exists");
			}
		}

		public void AddEdge(int value1, int value2, int weight)
		{
			WeightedNode node1 = FindNode(value1);
			WeightedNode node2 = FindNode(value2);

			if (node1 != null && node2 != null)
			{
				node1.Neighbors.Add(new Edge(node2, weight));
				node2.Neighbors.Add(new Edge(node1, weight));
			}
		}

		public void PrintGraph()
		{
			Console.WriteLine("Graph************************************");
			foreach (WeightedNode node in nodes)
			{
				Console.WriteLine("Node " + node.Value);
				foreach (Edge neighbor in node.Neighbors)
				{
					Console.WriteLine("-->(" + neighbor.Destination.Value + ", Weight: " + neighbor.Weight + ")");
				}
			}
		}

		public WeightedNode FindNode(int value)
		{
			return nodes.Find(n => n.Value == value);
		}
	}
}

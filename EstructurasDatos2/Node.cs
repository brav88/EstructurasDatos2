using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
	internal class Node
	{
		public int Value;
		public Node Next;

		public Node(int _Value)
		{
			this.Value = _Value;
		}
	}

	internal class NodeP
	{
		public string Name;
		public string LastName;
		public NodeP Next;

		public NodeP(string _Name, string _LastName)
		{
			this.Name = _Name;
			this.LastName = _LastName;
		}
	}

	internal class NodeQueue
	{
		public string Name;
		public decimal Price;
		public NodeQueue Next;

		public NodeQueue(string _Name, decimal _Price)
		{
			this.Name = _Name;
			this.Price = _Price;
		}
	}

	internal class NodeDL
	{
		public string Brand;
		public string Model;
		public NodeDL Next;
		public NodeDL Previous;		

		public NodeDL(string _Brand, string _Model)
		{
			Brand = _Brand;
			Model = _Model;	
		}
	}

	internal class TreeNode
	{
		public int Value;
		public TreeNode Left;
		public TreeNode Right;

		public TreeNode(int _Value)
		{
			this.Value = _Value;
			Left = null; 
			Right = null;
		}
	}

	internal class GraphNode
	{
		public int Value;
		public List<GraphNode> Adjacents;		

		public GraphNode(int _Value)
		{
			this.Value = _Value;
			this.Adjacents = new List<GraphNode>();
		}
	}

	internal class WeightedNode
	{
		public string Value;
		public List<Edge> Neighbors;

		public WeightedNode(string _Value)
		{
			this.Value = _Value;
			this.Neighbors = new List<Edge>();
		}
	}

	internal class Edge
	{
		public WeightedNode Destination;
		public int Weight;

		public Edge(WeightedNode _Destination, int _Weight)
		{
			this.Destination = _Destination;
			this.Weight = _Weight;	
		}
	}

}

using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public class BSTNode
	{
		public int NodeKey; // ключ узла
		public BSTNode Parent; // родитель или null для корня
		public BSTNode LeftChild; // левый потомок
		public BSTNode RightChild; // правый потомок	
		public int Level; // глубина узла

		public BSTNode(int key, BSTNode parent)
		{
			NodeKey = key;
			Parent = parent;
			LeftChild = null;
			RightChild = null;
		}
	}


	public class BalancedBST
	{
		public BSTNode Root; // корень дерева

		public BalancedBST()
		{
			Root = null;
		}

		public void GenerateTree(int[] a)
		{
			// создаём дерево с нуля из неотсортированного массива a
			// ...
			Array.Sort(a);
			Root = F(null, a,-1);

		}

		public bool IsBalanced(BSTNode root_node)
		{
			Node(root_node);
			bool isBalanced = true;
			void Node(BSTNode node)
			{
				if (node.LeftChild != null)
                {
					if (!(node.LeftChild.NodeKey < node.NodeKey)) isBalanced = false;
					Node(node.LeftChild);
                }
				if (node.RightChild != null)
                {
					if (!(node.RightChild.NodeKey > node.NodeKey)) isBalanced = false;
					Node(node.RightChild);
				}
			}
			if (isBalanced == false) return false;

			List<BSTNode> list = new List<BSTNode>();
			AddList(root_node);
			void AddList (BSTNode node)
            {
				if (node != null) list.Add(node);
				if (node.LeftChild != null) AddList(node.LeftChild);
				if (node.RightChild != null) AddList(node.RightChild);
			}
			List<int> listLevel = new List<int>();
			foreach (var item in list)
            {
				if (item.LeftChild == null && item.RightChild == null) listLevel.Add(item.Level);
            }
			listLevel.Sort();
			int min = listLevel[0];
			int max = listLevel[listLevel.Count - 1];
			if (Math.Abs(max - min) >= 2) return false;
			return true; // сбалансировано ли дерево с корнем root_node
		}
		BSTNode F(BSTNode node, int[] array,int lev)
        {
			if (array.Length == 0)
			{
				return null;
			}
			int index = array.Length / 2;
			BSTNode bSTNode = new BSTNode(array[index], node);
			bSTNode.Level = lev + 1;
			int[] arrayLeft = new int[index];
			int[] arrayRight = new int[index];
			Array.Copy(array, 0, arrayLeft, 0, index);
			Array.Copy(array, index + 1, arrayRight, 0, index);
			bSTNode.LeftChild = F(bSTNode, arrayLeft,bSTNode.Level);
			bSTNode.RightChild = F(bSTNode, arrayRight, bSTNode.Level);

			return bSTNode;
        }

	}
}

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
			int lh; // для высоты левого поддерева
			int rh; // для высоты правого поддерева
			/*Если дерево пусто, вернуть true */

			if (root_node == null)
			{
				return true;
			}
			/*Получить высоту левого и правого поддеревьев */

			lh = height(root_node.LeftChild);
			rh = height(root_node.RightChild);

			if (Math.Abs(lh - rh) <= 1 && IsBalanced(root_node.LeftChild) && IsBalanced(root_node.RightChild))
			{
				return true;
			}
			/*Если мы достигаем здесь, то дерево не сбалансировано по высоте */

			return false; // сбалансировано ли дерево с корнем root_node
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
			bSTNode.LeftChild = F(bSTNode, arrayLeft, bSTNode.Level);
			bSTNode.RightChild = F(bSTNode, arrayRight, bSTNode.Level);

			return bSTNode;
		}
		public int height(BSTNode node)
		{
			/*базовое дерево пусто */

			if (node == null)
			{
				return 0;
			}
			/*Если дерево не пустое, то высота = 1 + максимум слева
		   высота и правая высота */

			return 1 + Math.Max(height(node.LeftChild), height(node.RightChild));
		}

	}
}

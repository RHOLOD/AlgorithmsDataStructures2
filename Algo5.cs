using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public static class BalancedBST
	{
		public static int[] GenerateBBSTArray(int[] a)
		{
			Array.Sort(a);
			int length = a.Length;
			int[] array = new int[length];
			Generate(a, 0);

			void Generate(int[] b, int intexRoot)
			{
				if(b.Length != 0)
                {
					int index = b.Length / 2;
					array[intexRoot] = b[index];
					int[] arrayLeft = new int[index];
					int[] arrayRight = new int[index];
					Array.Copy(b, 0, arrayLeft, 0, index);
					Array.Copy(b, index+1, arrayRight, 0, index);
					Generate(arrayLeft, intexRoot * 2 + 1);
					Generate(arrayRight, intexRoot * 2 + 2);
				}
			}

			return array;
		}

	}
}
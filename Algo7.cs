using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public class Heap
	{

		public int[] HeapArray; // хранит неотрицательные числа-ключи

		public Heap() { HeapArray = null; }

		public void MakeHeap(int[] a, int depth)
		{
			// создаём массив кучи HeapArray из заданного
			// размер массива выбираем на основе глубины depth
			// ...
			int tree_size = 0;
			int level = 1;
			for (int i = 0; i <= depth; i++)
			{
				tree_size = tree_size + level;
				level = level * 2;
			}
			HeapArray = new int[tree_size];
			for (int i = 0; i < a.Length; i++)
            {
				AddItem(a[i]);
            }	

		}

		public int GetMax()
		{
			// вернуть значение корня и перестроить кучу
			if (HeapArray != null)
            {				
				int rootTree = HeapArray[0];
				for (int i = 1; i < HeapArray.Length; i++)
                {
					if (HeapArray[i] == 0)
                    {
						HeapArray[0] = HeapArray[i - 1];
						HeapArray[i - 1] = 0;
						SiftingDown(0);
						return rootTree;

					}
                }


			}
			return -1; // если куча пуста
		}

		public bool Add(int key)
		{
			// добавляем новый элемент key в кучу и перестраиваем её
			
			return AddItem(key); // если куча вся заполнена
		}
		public bool AddItem(int key)
        {
			for (int i = 0; i < HeapArray.Length; i++)
            {
				if (HeapArray[i] == 0)
                {
					HeapArray[i] = key;
					SiftingUp(i);
					return true;
				}
            }
			return false;
		}
		public void SiftingUp(int i)
        {
			int indexParent = (i - 1) / 2;
			if (indexParent >= 0)
			{
				if (HeapArray[indexParent] < HeapArray[i])
				{
					int item = HeapArray[i];
					HeapArray[i] = HeapArray[indexParent];
					HeapArray[indexParent] = item;
					SiftingUp(indexParent);
				}
			}
		}
		public bool SiftingDown(int i)
        {
			int indexLeft = 2 * i + 1;
			int indexRight = 2 * i + 2;
			if (indexLeft < HeapArray.Length)
            {
				if (HeapArray[indexRight] > HeapArray[indexLeft])
				{
					if(HeapArray[i] < HeapArray[indexRight])
                    {
						int item = HeapArray[i];
						HeapArray[i] = HeapArray[indexRight];
						HeapArray[indexRight] = item;
						SiftingDown(indexRight);
						return true;
					}
				}
				else if (HeapArray[indexRight] < HeapArray[indexLeft])
				{
					if (HeapArray[i] < HeapArray[indexLeft])
                    {
						int item = HeapArray[i];
						HeapArray[i] = HeapArray[indexLeft];
						HeapArray[indexLeft] = item;
						SiftingDown(indexLeft);
						return true;
					}
				}
			}
			return false;
		}
	}
}

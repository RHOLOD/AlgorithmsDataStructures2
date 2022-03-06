using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            // правильно рассчитайте размер массива для дерева глубины depth:           
            int tree_size = 0;
            int level = 1;
            for (int i = 1; i <= depth; i++) 
            {               
                tree_size = tree_size + level;
                level = level * 2;
            }

            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            // ищем в массиве индекс ключа
            int count = Tree.Length;
            int? index = Find(0,key,count);
            if (index != null) return index;
            return null; // не найден
        }

        public int AddKey(int key)
        {
            // добавляем ключ в массив
            int count = Tree.Length;
            int? index = Find(0, key, count);
            if (index != null)
            {
                int i = Math.Abs((int)index);
                Tree[i] = key;
                return i;
            } 
            return -1;
            // индекс добавленного/существующего ключа или -1 если не удалось
        }
        int? Find(int index, int key,int count)
        {
            if (index >= count) return null;
            if (Tree[index] == key) return index;
            else if (Tree[index] == null) return -index;
            else if (Tree[index] > key) return Find(2 * index + 1, key, count);
            else return Find(2 * index + 2, key, count);
        }
    }
}
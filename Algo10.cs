using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        // ...
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;       
        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];
        }

        public void AddVertex(T value)
        {
            // ваш код добавления новой вершины 
            // с значением value 
            // в свободную позицию массива vertex
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex<T>(value);
                    break;
                }
            }
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            vertex[v] = null;

            for (int i = 0; i < max_vertex; i++)
            {
                m_adjacency[i, v] = 0;
            }
            for (int i = 0; i < max_vertex; i++)
            {
                m_adjacency[v, i] = 0;
            }

            // ваш код удаления вершины со всеми её рёбрами
        }

        public bool IsEdge(int v1, int v2)
        {
            if (m_adjacency[v1, v2] == 1) return true;
            // true если есть ребро между вершинами v1 и v2
            return false;
        }

        public void AddEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
            // добавление ребра между вершинами v1 и v2
        }

        public void RemoveEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
            // удаление ребра между вершинами v1 и v2
        }
        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            // Узлы задаются позициями в списке vertex.
            // Возвращается список узлов -- путь из VFrom в VTo.
            // Список пустой, если пути нету.
            for (int i = 0; i < max_vertex; i++)
            {
                vertex[i].Hit = false;
            }
            List<Vertex<T>> list = new List<Vertex<T>>();
            if (VFrom > max_vertex || VTo > max_vertex) return list;
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
      

            bool FindingPath (int nodeFrom)
            {
                stack.Push(vertex[nodeFrom]);
                vertex[nodeFrom].Hit = true;
                for (int i = 0; i < max_vertex; i++)
                {
                    if ((m_adjacency[nodeFrom, i] == 1) && (i == VTo))
                    {
                        stack.Push(vertex[VTo]);
                        vertex[VTo].Hit = true;
                        return true;
                    }                    
                }
                for (int i = 0; i < max_vertex; i++)
                {
                    if ((m_adjacency[nodeFrom, i] == 1) && vertex[i].Hit == false)
                    {
                        vertex[i].Hit = true;
                        stack.Push(vertex[i]);                                               
                        if (FindingPath(i)) return true;
                        else
                        {
                            stack.Pop();         
                        }
                    }
                }
                return false;
            }
            if (FindingPath(VFrom))
            {
                while(stack.Count != 0)
                {
                    list.Add(stack.Pop());
                }
                list.Reverse();
            }
            return list;
        }

    }
}
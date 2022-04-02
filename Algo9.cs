using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }
        public List<T> EvenTrees()
        {
            List<T> list = new List<T>();            
            return list;
            // ...
        }
        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            SimpleTreeNode<T> item = SearchNode(Root, ParentNode);
            NewChild.Parent = ParentNode;
            if (item != null)
            {
                if (item.Children == null)
                {
                    List<SimpleTreeNode<T>> list = new List<SimpleTreeNode<T>>();
                    list.Add(NewChild);
                    item.Children = list;
                }
                else
                {
                    item.Children.Add(NewChild);
                }
            }
            // ваш код добавления нового дочернего узла существующему ParentNode
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            SimpleTreeNode<T> item = SearchNode(Root, NodeToDelete);
            if (item != null)
            {
                item = SearchNode(Root, item.Parent);
                List<SimpleTreeNode<T>> list = new List<SimpleTreeNode<T>>();
                foreach (var element in item.Children)
                {
                    if (!element.Equals(NodeToDelete))
                    {
                        list.Add(element);
                    }
                }
                if (list.Count == 0)
                {
                    item.Children = null;
                }
                else
                {
                    item.Children = list;
                }
            }
            // ваш код удаления существующего узла NodeToDelete
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            if (Root != null && Root.NodeValue != null)
            {
                List<SimpleTreeNode<T>> list = new List<SimpleTreeNode<T>>();
                list.Add(Root);
                Bypass(Root);
                void Bypass(SimpleTreeNode<T> node)
                {
                    if (node.Children != null)
                    {
                        foreach (var item in node.Children)
                        {
                            list.Add(item);
                            Bypass(item);
                        }
                    }
                }
                return list;
            }
            // ваш код выдачи всех узлов дерева в определённом порядке
            return null;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            List<SimpleTreeNode<T>> list = GetAllNodes();
            List<SimpleTreeNode<T>> listValue = new List<SimpleTreeNode<T>>();
            foreach (var item in list)
            {
                if (item.NodeValue.Equals(val))
                {
                    listValue.Add(item);
                }
            }
            // ваш код поиска узлов по значению
            return listValue;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            SimpleTreeNode<T> node = SearchNode(Root, OriginalNode);
            SimpleTreeNode<T> nodeNewParent = SearchNode(Root, NewParent);
            if (node != null && nodeNewParent != null)
            {
                DeleteNode(OriginalNode);
                AddChild(NewParent, node);
            }
            // ваш код перемещения узла вместе с его поддеревом -- 
            // в качестве дочернего для узла NewParent
        }

        public int Count()
        {
            List<SimpleTreeNode<T>> list = GetAllNodes();

            int count = list.Count;
            // количество всех узлов в дереве
            return count;
        }

        public int LeafCount()
        {
            List<SimpleTreeNode<T>> list = GetAllNodes();
            List<SimpleTreeNode<T>> listLeaf = new List<SimpleTreeNode<T>>();
            foreach (var item in list)
            {
                if (item.Children == null)
                {
                    listLeaf.Add(item);
                }
            }
            int count = listLeaf.Count;
            // количество листьев в дереве
            return count;
        }
        public SimpleTreeNode<T> SearchNode(SimpleTreeNode<T> node, SimpleTreeNode<T> searched)
        {
            SimpleTreeNode<T> result = null;
            if (node.Equals(searched))
            {
                result = node;
            }
            else if (node.Children != null)
            {
                foreach (var item in node.Children)
                {
                    result = SearchNode(item, searched);
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
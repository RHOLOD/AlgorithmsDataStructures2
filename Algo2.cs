using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTFind<T> bSTFind = Seach(Root, key);
            // ищем в дереве узел и сопутствующую информацию по ключу

            if (bSTFind.NodeHasKey == true) return bSTFind;
            else return null;
        }

        public bool AddKeyValue(int key, T val)
        {
            BSTFind<T> bSTFind = Seach(Root,key);

            if (bSTFind.NodeHasKey == true)
            {
                return false; // если ключ уже есть
            }
            else
            {
                BSTNode<T> bSTNode = new BSTNode<T>(key, val, bSTFind.Node);
                if (bSTFind.ToLeft == true)
                {                    
                    bSTFind.Node.LeftChild = bSTNode;
                }
                else
                {
                    bSTFind.Node.RightChild = bSTNode;
                }
                return true;
            }
            // добавляем ключ-значение в дерево            
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (FromNode == null) return null;
            BSTNode<T> SeachMax(BSTNode<T> node)
            {
                if ( node.RightChild == null) return node;
                else
                {
                    return SeachMax(node.RightChild);
                }
            }
            BSTNode<T> SeachMin(BSTNode<T> node)
            {
                if (node.LeftChild == null) return node;
                else
                {
                    return SeachMin(node.LeftChild);
                }
            }
            if (FindMax == true)
            {
                return SeachMax(FromNode);
            }
            else
            {
                return SeachMin(FromNode);
            }
            // ищем максимальный/минимальный ключ в поддереве
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            BSTFind<T> bSTFind = Seach(Root,key);
            if (bSTFind.NodeHasKey == true)
            {
                if (bSTFind.Node.LeftChild == null && bSTFind.Node.RightChild == null) 
                {
                    BSTFind<T> bSTFindParent = Seach(Root,bSTFind.Node.Parent.NodeKey);
                    if (bSTFindParent.Node.LeftChild == null)
                    {
                        bSTFindParent.Node.RightChild = null;
                    }
                    else
                    {
                        if (bSTFindParent.Node.LeftChild.NodeKey == bSTFind.Node.NodeKey)
                        {
                            bSTFindParent.Node.LeftChild = null;
                        }
                        else
                        {
                            bSTFindParent.Node.RightChild = null;
                        }
                    }

                }
                else
                {
                    if (bSTFind.Node.LeftChild != null && bSTFind.Node.RightChild == null)
                    {
                        BSTNode<T> bSTNodeParent = bSTFind.Node.Parent;
                        BSTNode<T> bSTNodeLeftChild = bSTFind.Node.LeftChild;
                        bSTNodeLeftChild.Parent = bSTNodeParent;
                        if (bSTNodeParent.RightChild == bSTFind.Node) bSTNodeParent.RightChild = bSTNodeLeftChild;
                        if (bSTNodeParent.LeftChild == bSTFind.Node) bSTNodeParent.LeftChild = bSTNodeLeftChild;

                    }
                    else if (bSTFind.Node.LeftChild == null && bSTFind.Node.RightChild != null)
                    {
                        BSTNode<T> bSTNodeParent = bSTFind.Node.Parent;
                        BSTNode<T> bSTNodeRightChild = bSTFind.Node.RightChild;
                        bSTNodeRightChild.Parent = bSTNodeParent;
                        if (bSTNodeParent.RightChild == bSTFind.Node) bSTNodeParent.RightChild = bSTNodeRightChild;
                        if (bSTNodeParent.LeftChild == bSTFind.Node) bSTNodeParent.LeftChild = bSTNodeRightChild;
                    }
                    else if (bSTFind.Node.LeftChild != null && bSTFind.Node.RightChild != null)
                    {
                        if (bSTFind.Node.RightChild.LeftChild == null)
                        {
                            BSTNode<T> bSTNodeParent = bSTFind.Node.Parent;
                            BSTNode<T> bSTNodeRightChild = bSTFind.Node.RightChild;
                            BSTNode<T> bSTNodeLeftChild = bSTFind.Node.LeftChild;
                            bSTNodeRightChild.Parent = bSTNodeParent;
                            bSTNodeLeftChild.Parent = bSTNodeRightChild;
                            bSTNodeRightChild.LeftChild = bSTNodeLeftChild;
                            if (bSTNodeParent.RightChild == bSTFind.Node) bSTNodeParent.RightChild = bSTNodeRightChild;
                            if (bSTNodeParent.LeftChild == bSTFind.Node) bSTNodeParent.LeftChild = bSTNodeRightChild;
                        }
                        else if (bSTFind.Node.RightChild.LeftChild != null)
                        {
                            BSTNode<T> bSTNodeParent = bSTFind.Node.Parent;
                            BSTNode<T> bSTNodeRightChild = bSTFind.Node.RightChild;
                            BSTNode<T> bSTNodeLeftChild = bSTFind.Node.LeftChild;
                            bSTNodeRightChild.Parent = bSTNodeParent;
                            if (bSTNodeParent.RightChild == bSTFind.Node) bSTNodeParent.RightChild = bSTNodeRightChild;
                            if (bSTNodeParent.LeftChild == bSTFind.Node) bSTNodeParent.LeftChild = bSTNodeRightChild;
                            AddNode(bSTNodeRightChild, bSTNodeLeftChild);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false; // если узел не найден
            }
        }

        public int Count()
        {
            Dictionary<BSTNode<T>, int> dictionary = new Dictionary<BSTNode<T>, int>();

            Enumeration(Root);

            void Enumeration(BSTNode<T> node)
            {
                if (node != null) dictionary.Add(node, node.NodeKey);
                if (node.LeftChild != null) Enumeration(node.LeftChild);
                if (node.RightChild != null) Enumeration(node.RightChild);
            }
            int count = 0;

            foreach (var d in dictionary)
            {
                count++;
            }

            return count; // количество узлов в дереве
        }
        private BSTFind<T> Seach(BSTNode<T> node, int key)
        {
            BSTFind<T> bSTFind = new BSTFind<T>();
            if (node.NodeKey == key)
            {
                bSTFind.Node = node;
                bSTFind.NodeHasKey = true;
            }
            else
            {
                if (node.NodeKey < key)
                {
                    if (node.RightChild == null)
                    {
                        bSTFind.Node = node;
                    }
                    else
                    {
                        bSTFind = Seach(node.RightChild, key);
                    }
                }
                else
                {
                    if (node.LeftChild == null)
                    {
                        bSTFind.Node = node;
                        bSTFind.ToLeft = true;
                    }
                    else
                    {
                        bSTFind = Seach(node.LeftChild, key);
                    }
                }
            }
            return bSTFind;            
        }
        private void AddNode (BSTNode<T> fromNode, BSTNode<T> nodeAdd)
        {
            BSTFind<T> bSTFind = Seach(fromNode, nodeAdd.NodeKey);
            if (bSTFind.ToLeft == true)
            {
                bSTFind.Node.LeftChild = nodeAdd;
            }
            else
            {
                bSTFind.Node.RightChild = nodeAdd;
            }
            //SearchNode            
        }

    }

}
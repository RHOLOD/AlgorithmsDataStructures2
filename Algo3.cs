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
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        //public BSTNode Parent; // родитель или null для корня
        //public BSTNode LeftChild; // левый потомок
        //public BSTNode RightChild; // правый потомок	

        public BSTNode(int key)
        //public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            //Parent = parent;
            //LeftChild = null;
            //RightChild = null;
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
            if (Root == null)
            {
                BSTFind<T> bSTFind1 = new BSTFind<T>();
                return bSTFind1;
            }
            BSTFind<T> bSTFind = Seach(Root, key);
            // ищем в дереве узел и сопутствующую информацию по ключу
            
            return bSTFind;
        }

        public bool AddKeyValue(int key, T val)
        {
            BSTFind<T> bSTFind = Seach(Root, key);

            if (bSTFind.NodeHasKey == true)
            {
                return false; // если ключ уже есть
            }
            else
            {
                BSTNode<T> bSTNode = new BSTNode<T>(key, val, bSTFind.Node);
                if (bSTFind.Node == null)
                {
                    Root = bSTNode;
                }
                else
                {
                    if (bSTFind.ToLeft == true)
                    {
                        bSTFind.Node.LeftChild = bSTNode;
                    }
                    else
                    {
                        bSTFind.Node.RightChild = bSTNode;
                    }
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
                if (node.RightChild == null) return node;
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
            BSTFind<T> bSTFind = Seach(Root, key);
            if (bSTFind.NodeHasKey == true)
            {
                if (bSTFind.Node.Parent == null)
                {
                    Root = null;
                    return true;
                }
                if (bSTFind.Node.LeftChild == null && bSTFind.Node.RightChild == null)
                {
                    BSTFind<T> bSTFindParent = Seach(Root, bSTFind.Node.Parent.NodeKey);
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
                        if (bSTNodeParent.RightChild.NodeKey == bSTFind.Node.NodeKey) bSTNodeParent.RightChild = bSTNodeLeftChild;
                        if (bSTNodeParent.LeftChild.NodeKey == bSTFind.Node.NodeKey) bSTNodeParent.LeftChild = bSTNodeLeftChild;

                    }
                    else if (bSTFind.Node.LeftChild == null && bSTFind.Node.RightChild != null)
                    {
                        BSTNode<T> bSTNodeParent = bSTFind.Node.Parent;
                        BSTNode<T> bSTNodeRightChild = bSTFind.Node.RightChild;
                        bSTNodeRightChild.Parent = bSTNodeParent;
                        if (bSTNodeParent.RightChild != null && bSTNodeParent.LeftChild != null)
                        {
                            if (bSTNodeParent.RightChild.NodeKey == bSTFind.Node.NodeKey) bSTNodeParent.RightChild = bSTNodeRightChild;
                            else if (bSTNodeParent.LeftChild.NodeKey == bSTFind.Node.NodeKey) bSTNodeParent.LeftChild = bSTNodeRightChild;
                        }
                        else
                        {
                            if (bSTNodeParent.RightChild == null)  bSTNodeParent.LeftChild = bSTNodeRightChild;
                            else bSTNodeParent.RightChild = bSTNodeRightChild;
                        }

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
                            if (bSTNodeParent.RightChild != null && bSTNodeParent.LeftChild != null)
                            {
                                if (bSTNodeParent.RightChild.NodeKey == bSTFind.Node.NodeKey) bSTNodeParent.RightChild = bSTNodeRightChild;
                                else if (bSTNodeParent.LeftChild.NodeKey == bSTFind.Node.NodeKey) bSTNodeParent.LeftChild = bSTNodeRightChild;
                            }
                            else
                            {
                                if (bSTNodeParent.RightChild == null) bSTNodeParent.LeftChild = bSTNodeRightChild;
                                else bSTNodeParent.RightChild = bSTNodeRightChild;
                            }
                        }
                        else if (bSTFind.Node.RightChild.LeftChild != null)
                        {
                            BSTNode<T> bSTNodeParent = bSTFind.Node.Parent;
                            BSTNode<T> bSTNodeRightChild = bSTFind.Node.RightChild;
                            BSTNode<T> bSTNodeLeftChild = bSTFind.Node.LeftChild;
                            BSTNode<T> newAddNode = bSTNodeRightChild.LeftChild;
                            while (newAddNode.LeftChild != null)
                            {
                                newAddNode = newAddNode.LeftChild;
                            }
                            BSTNode<T> newAddNodeRightChild = null;
                            int keyParent = newAddNode.Parent.NodeKey;
                            if (newAddNode.RightChild != null)
                            {
                                newAddNodeRightChild = newAddNode.RightChild;
                            }
                            newAddNode.Parent = bSTNodeParent;
                            bSTNodeRightChild.Parent = newAddNode;
                            bSTNodeLeftChild.Parent = newAddNode;
                            newAddNode.LeftChild = bSTNodeLeftChild;
                            newAddNode.RightChild = bSTNodeRightChild;
                            
                            if (bSTNodeParent.RightChild != null && bSTNodeParent.LeftChild != null)
                            {
                                if (bSTNodeParent.RightChild.NodeKey == bSTFind.Node.NodeKey) bSTNodeParent.RightChild = newAddNode;
                                else if (bSTNodeParent.LeftChild.NodeKey == bSTFind.Node.NodeKey) bSTNodeParent.LeftChild = newAddNode;
                            }
                            else
                            {
                                if (bSTNodeParent.RightChild == null) bSTNodeParent.LeftChild = newAddNode;
                                else bSTNodeParent.RightChild = newAddNode;
                            }
                            BSTFind<T> bSTFind2 = Seach(bSTNodeParent, keyParent);
                            if (newAddNodeRightChild == null)
                            {
                                bSTFind2.Node.LeftChild = null;
                                bSTFind2.Node.RightChild = null;
                            }
                            else
                            {
                                BSTNode<T> bSTNodeRightChildNew = newAddNodeRightChild;
                                bSTNodeRightChildNew.Parent = bSTFind2.Node;
                                bSTFind2.Node.LeftChild = bSTNodeRightChildNew;
                                bSTFind2.Node.RightChild = null;

                            }
                            
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
            if (Root == null)
            {
                return 0;
            }
            int count = 0;

            void СountRoot (BSTNode<T> node)
            {
                if (node != null) count++;
                if (node.LeftChild != null) СountRoot(node.LeftChild);
                if (node.RightChild != null) СountRoot(node.RightChild);
            }
            СountRoot(Root);
            return count; // количество узлов в дереве
        }
        private BSTFind<T> Seach(BSTNode<T> node, int key)
        {
            BSTFind<T> bSTFind = new BSTFind<T>();
            if (node == null) return bSTFind;
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
        public List<BSTNode> WideAllNodes()
        {
            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            List<BSTNode> list = new List<BSTNode>();
            if (Root == null) return list;

            queue.Enqueue(Root);
            while(queue.Count != 0)
            {
                var node = queue.Dequeue();
                BSTNode bSTNode = new BSTNode(node.NodeKey);
                list.Add(bSTNode);
                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                }
                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                }
            }
            return list;
        }
        public List<BSTNode> DeepAllNodes(int selection)
        {
            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            List<BSTNode> list = new List<BSTNode>();
            if (Root == null) return list;
            if (selection == 2)
            {
                NLR(Root); //pre-order
            }
            if (selection == 0)
            {
                LNR(Root);//in -oreder
            }
            if (selection == 1)
            {
                LRN(Root);//post-order
            }
            void NLR(BSTNode<T> node)
            {
                BSTNode bSTNode = new BSTNode(node.NodeKey);
                list.Add(bSTNode);
                if (node.LeftChild != null)
                {
                    NLR(node.LeftChild);
                }
                if (node.RightChild != null)
                {
                    NLR(node.RightChild);
                }
            }
            void LNR(BSTNode<T> node)
            {
                BSTNode bSTNode = new BSTNode(node.NodeKey);
                if (node.LeftChild != null)
                {
                    LNR(node.LeftChild);
                }
                list.Add(bSTNode);
                if (node.RightChild != null)
                {
                    LNR(node.RightChild);
                }
            }
            void LRN(BSTNode<T> node)
            {
                BSTNode bSTNode = new BSTNode(node.NodeKey);
                if (node.LeftChild != null)
                {
                    LRN(node.LeftChild);
                }            
                if (node.RightChild != null)
                {
                    LRN(node.RightChild);
                }
                list.Add(bSTNode);
            }

            return list;
        }


    }

}

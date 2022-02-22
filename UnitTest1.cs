using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace UnitTestAlgo2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() // проверка поиска FindNodeByKe(33)
        {
            BSTNode<string> bSTNode1 = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(bSTNode1);
            BSTFind<string> bSTFind = bST1.FindNodeByKey(33);

            var expected = 33;
            int result = bSTFind.Node.NodeKey;      

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2() // проверка поиска FindNodeByKe(35)
        {
            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BSTNode<string> bSTNode2 = new BSTNode<string>(35, "35", null);
            bSTNode2.Parent = root;
            root.RightChild = bSTNode2;
            BST<string> bST1 = new BST<string>(root);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(35);

            var expected = 35;
            int result = bSTFind.Node.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod3() // проверка добавления AddKeyValue(31,"") 
        {
            /// дерево 33, 5, 35, 20, 99, 17, 18, 19, 31, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           20                       99
            ///       4   17        31
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);        
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5,"");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b8 = bST1.AddKeyValue(31, "");
            bool b9 = bST1.AddKeyValue(4, "");

            BSTFind<string> bSTFind = bST1.FindNodeByKey(31);

            var expected = 31;
            int result = bSTFind.Node.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho4() // проверка поиска для добавление FindNodeByKe(34), проверяет элемент к которуму надо добавить
        {
            /// дерево 33, 5, 35, 20, 99, 17, 18, 19, 31, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           20             +34        99
            ///       4   17        31                      
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b8 = bST1.AddKeyValue(31, "");
            bool b9 = bST1.AddKeyValue(4, "");

            BSTFind<string> bSTFind = bST1.FindNodeByKey(34);

            var expected = 35;
            var result = bSTFind.Node.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho5() // проверка поиска для добавление FindNodeByKe(34), проверяет добавление в LeftChild
        {
            /// дерево 33, 5, 35, 20, 99, 17, 18, 19, 31, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           20             +34        99
            ///       4   17        31                      
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b8 = bST1.AddKeyValue(31, "");
            bool b9 = bST1.AddKeyValue(4, "");

            BSTFind<string> bSTFind = bST1.FindNodeByKey(34);

            var expected = true;
            var result = bSTFind.ToLeft;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho6() // проверка поиска для добавление 34
        {
            /// дерево 33, 5, 35, 20, 99, 17, 18, 19, 31, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           20             +34        99
            ///       4   17        31                      
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b8 = bST1.AddKeyValue(31, "");
            bool b9 = bST1.AddKeyValue(4, "");
            bool b10 = bST1.AddKeyValue(34, "");

            BSTFind<string> bSTFind = bST1.FindNodeByKey(34);

            var expected = 34;
            var result = bSTFind.Node.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho7() // проверка Count()
        {
            /// дерево 33, 5, 35, 20, 99, 17, 18, 19, 31, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           20             34        99
            ///       4   17        31                      
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b8 = bST1.AddKeyValue(31, "");
            bool b9 = bST1.AddKeyValue(4, "");
            bool b10 = bST1.AddKeyValue(34, "");


            var expected = 12;
            var result = bST1.Count();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho8() // проверка максимального элемента FinMinMax 
        {
            /// дерево 33, 5, 35, 20, 99, 17, 18, 19, 31, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           20             34        99
            ///       4   17        31                      
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b8 = bST1.AddKeyValue(31, "");
            bool b9 = bST1.AddKeyValue(4, "");
            bool b10 = bST1.AddKeyValue(34, "");

            BSTFind<string> bSTFind = bST1.FindNodeByKey(33);
            var expected = 99;
            var result = bST1.FinMinMax(bSTFind.Node,true).NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho9() // проверка минимального элемента FinMinMax 
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 31, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           20             34        99
            ///       4   17        31                      
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b8 = bST1.AddKeyValue(31, "");
            bool b9 = bST1.AddKeyValue(4, "");
            bool b10 = bST1.AddKeyValue(34, "");

            BSTFind<string> bSTFind = bST1.FindNodeByKey(33);
            var expected = 1;
            var result = bST1.FinMinMax(bSTFind.Node, false).NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho10() // проверка удаления  34
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 31, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           20             -34        99
            ///       4    17        31                      
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b8 = bST1.AddKeyValue(31, "");
            bool b9 = bST1.AddKeyValue(4, "");
            bool b10 = bST1.AddKeyValue(34, "");

            bool b11 = bST1.DeleteNodeByKey(34);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(34);
            var expected = false;
            var result = bSTFind.NodeHasKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho11() // проверка удаления  20
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1           -20                     99
            ///       4     17                           
            ///              18
            ///                 19

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b3 = bST1.AddKeyValue(20, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(20);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(17);
            var expected = 5;
            var result = bSTFind.Node.Parent.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho12() // проверка удаления  5
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         -5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///                 

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(5);
            var expected = false;
            var result = bSTFind.NodeHasKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho13() // проверка удаления  5
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         -5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///                 

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(17);
            var expected = 33;
            var result = bSTFind.Node.Parent.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho14() // проверка удаления  5
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         -5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///                 

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(17);
            var expected = 1;
            var result = bSTFind.Node.LeftChild.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho15()  // проверка FindNodeByKey() после удаления  5
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         -5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///                 

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(19);
            var expected = 19;
            var result = bSTFind.Node.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho16()  // проверка FindNodeByKey() после удаления  5
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         -5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///                 

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(4);
            var expected = 4;
            var result = bSTFind.Node.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho17()  //проверка FindNodeByKey() после удаления  33
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///                 

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(33);

            BSTFind<string> bSTFind = bST1.FindNodeByKey(33);
            BSTFind<string> expected = null;
            var result = bSTFind;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho18()  //проверка FindNodeByKey() после удаления  5 и добавление  26 22 24
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///             +22     +26
            ///                 +24

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);
            bool b92 = bST1.AddKeyValue(26, "");
            bool b93 = bST1.AddKeyValue(22, "");
            bool b94 = bST1.AddKeyValue(24, "");


            BSTFind<string> bSTFind = bST1.FindNodeByKey(24);
            var expected = 24;
            var result = bSTFind.Node.NodeKey;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho19()  //проверка FindNodeByKey() после удаления  5 и добавление  26 22 24 и поиск для 27
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///             +22     +26
            ///                 +24

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);
            bool b92 = bST1.AddKeyValue(26, "");
            bool b93 = bST1.AddKeyValue(22, "");
            bool b94 = bST1.AddKeyValue(24, "");


            BSTFind<string> bSTFind = bST1.FindNodeByKey(27);
            var expected = false;
            var result = bSTFind.ToLeft;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho20()  //проверка FindNodeByKey() после удаления  5 и добавление  26 22 24 и поиск для 21
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///             +22     +26
            ///                 +24

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);
            bool b92 = bST1.AddKeyValue(26, "");
            bool b93 = bST1.AddKeyValue(22, "");
            bool b94 = bST1.AddKeyValue(24, "");


            BSTFind<string> bSTFind = bST1.FindNodeByKey(21);
            var expected = true;
            var result = bSTFind.ToLeft;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMetho21()  //проверка FindNodeByKey() после удаления  5 и добавление  26 22 24 и поиск для 21
        {
            /// дерево 33, 5, 35, 1, 20, 99, 17, 18, 19, 4
            /// 
            ///                       33
            ///         5                        35
            ///     1       17                         99
            ///       4       18                           
            ///                19
            ///             +22     +26
            ///                 +24

            BSTNode<string> root = new BSTNode<string>(33, "33", null);
            BST<string> bST1 = new BST<string>(root);
            bool bl = bST1.AddKeyValue(5, "");
            bool b2 = bST1.AddKeyValue(35, "");
            bool b22 = bST1.AddKeyValue(1, "");
            bool b4 = bST1.AddKeyValue(99, "");
            bool b5 = bST1.AddKeyValue(17, "");
            bool b6 = bST1.AddKeyValue(18, "");
            bool b7 = bST1.AddKeyValue(19, "");
            bool b9 = bST1.AddKeyValue(4, "");

            bool b11 = bST1.DeleteNodeByKey(5);
            bool b92 = bST1.AddKeyValue(26, "");
            bool b93 = bST1.AddKeyValue(22, "");
            bool b94 = bST1.AddKeyValue(24, "");


            BSTFind<string> bSTFind = bST1.FindNodeByKey(21);
            var expected = 22;
            var result = bSTFind.Node.NodeKey;

            Assert.AreEqual(expected, result);
        }
    }
}

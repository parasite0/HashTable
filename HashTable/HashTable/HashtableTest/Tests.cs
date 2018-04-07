using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHashtable;
using System.Collections.Generic;

namespace TestHashTable
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        //Добавление трёх элементов, поиск трёх элементов
        public void ThreeElements()
        {
            var hashTable = new Hashtable();
            hashTable.HashTable(3);
            hashTable.PutPair(1, "abc");
            hashTable.PutPair("aaa", 2);
            hashTable.PutPair(3, 000);
            var keys = new object[] { 1, "aaa", 3 };
            var values = new object[] { "abc", 2, 000 };
            for (int i = 0; i < 3; i++)
                Assert.AreEqual(hashTable.GetValueByKey(keys[i]), values[i]);
        }

        [TestMethod]
        //Добавление одного и того же ключа дважды с разными значениями сохраняет последнее добавленное значение
        public void TwoSameKeys()
        {
            var hashTable = new Hashtable();
            hashTable.HashTable(2);
            hashTable.PutPair(5, "abc");
            hashTable.PutPair(5, "cba");
            var key = 5;
            var value = "cba";
            Assert.AreEqual(hashTable.GetValueByKey(key), value);
        }

        [TestMethod]
        //Добавление 10000 элементов в структуру и поиск одного из них
        public void TenThousand()
        {
            var hashTable = new Hashtable();
            int size = 10000;
            hashTable.HashTable(size);
            for (int i = 0; i < size; i++)
                hashTable.PutPair(i, i);
            Assert.AreEqual(hashTable.GetValueByKey(777), 777);
        }

        [TestMethod]
        //Добавление 10000 элементов в структуру и поиск 1000 недобавленных ключей, поиск которых должен вернуть null
        public void NullKeys()
        {
            var hashTable = new Hashtable();
            var size = 10000;
            hashTable.HashTable(size);
            for (int i = 0; i < size; i++)
                hashTable.PutPair(i, i);
            for (int j = size; j < size + 1000; j++)
                Assert.AreEqual(hashTable.GetValueByKey(j), null);
        }
    }
}
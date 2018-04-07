using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHashtable
{
    public class Hashtable
    {
        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэ-таблицы
        public class Data
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        public static List<List<Data>> hashTable;

        public void HashTable(int size)
        {
            hashTable = new List<List<Data>>(size);
            for (int i = 0; i < size; i++)
            {
                hashTable.Add(new List<Data>());
            }
        }
        /// 
        /// Метод складывающий пару ключь-значение в таблицу
        /// 
        /// key">
        /// value">
        public void PutPair(object key, object value)
        {
            var num = Math.Abs(key.GetHashCode()) % hashTable.Count;
            foreach (var a in hashTable[num])
            {
                if (Equals(a.Key, key))
                {
                    a.Value = value;
                    return;
                }
            }
            hashTable[num].Add(new Data { Key = key, Value = value });
        }

        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключь
        /// <returns>Значение, null если ключ отсутствуетreturns>
        public object GetValueByKey(object key)
        {
            var num = Math.Abs(key.GetHashCode()) % hashTable.Count;
            foreach (var a in hashTable[num])
            {
                if (Equals(a.Key, key))
                {
                    return a.Value;
                }
            }
            return null;
        }
    }
}

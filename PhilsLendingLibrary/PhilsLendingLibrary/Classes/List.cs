﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace PhilsLendingLibrary.Classes
{
    public class List<T> : IEnumerable
    {
        private T[] storage = new T[1];
        private int currentIndex = 0;

        public void Add(T book)
        {
            if (currentIndex == storage.Length)
            {
                Array.Resize(ref storage, storage.Length + 1);
            }
            storage[currentIndex] = book;
            currentIndex++;
        }

        public void Remove(T book)
        {
            if (currentIndex == 0)
            {
                Console.WriteLine("No book available");
            }
            int index = 0;
            for (int i = 0; i < storage.Length; i++)
            {
                if (storage[i].Equals(book))
                {
                    index = i;
                }
            }
            for (int i = 0; i < storage.Length; i++)
            {
                if (i < index)
                {
                    storage[i] = storage[i];
                }
                else if (i > index)
                {
                    storage[i - 1] = storage[i];
                }
            }
            Array.Resize(ref storage, storage.Length - 1);
            currentIndex--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                yield return storage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

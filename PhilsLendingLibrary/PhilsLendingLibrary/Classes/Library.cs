using System;
using System.Collections;
using System.Collections.Generic;

namespace PhilsLendingLibrary.Classes
{
    public class Library<T> : IEnumerable
    {
        private T[] storage = new T[1];
        private int currentIndex = 0;

        public void Add(T book)
        {
            if(currentIndex == storage.Length)
            {
                Array.Resize(ref storage, storage.Length + 1);
            }
            storage[currentIndex] = book;
            currentIndex++;
        }

        public void Remove()
        {

        }

        public void Count()
        {

        }

        public Library()
        {
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
            throw new NotImplementedException();
        }
    }
}

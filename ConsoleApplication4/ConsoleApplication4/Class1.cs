using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        
        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
        }

        public int Count
        {
            get
            {
                for (int a = 0; a < _internalStorage.Length; a++)
                {
                    if (Equals(default(X), _internalStorage[a]))
                    {
                        return a;
                    }
                    if ( a == _internalStorage.Length -1)
                    {
                        return a+1;
                    }
                }
                return -1;

            }
        }

        public void Add(X item)
        {
            if (IndexOf(default(X)) == -1)
            {
                int size = _internalStorage.Length;
                X[] _internalStorageTemp = _internalStorage;
                _internalStorage = new X[2 * size];
                for (int a = 0; a < size; a++)
                {
                    _internalStorage[a] = _internalStorageTemp[a];
                }

            }

            for (int a = 0; a < _internalStorage.Length; a++)
            {
                if (Equals(_internalStorage[a], default(X)))
                {
                    _internalStorage[a] = item;
                    break;
                }
            }
        }

        public void Clear()
        {
            for (int a = 0; a < _internalStorage.Length; a++)
            {
                _internalStorage[a] = default(X);
            }
        }

        public bool Contains(X item)
        {
          
            for (int a = 0; a < _internalStorage.Length; a++)
            {
                if (Equals(_internalStorage[a],item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if ((index < _internalStorage.Length ) && (index >= 0))
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            if (Contains(item))
            {
                for (int a = 0; a < _internalStorage.Length; a++)
                {
                    if (Equals(_internalStorage[a], item))
                    {
                        return a;
                    }
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index > _internalStorage.Length - 1 || index < 0 || _internalStorage[index].Equals(default(X)))
            {
                return false;
            }
            else {
                for (int a = index; a < _internalStorage.Length - 1; a++)
                {
                    _internalStorage[a] = _internalStorage[a + 1];
                }
                _internalStorage[_internalStorage.Length - 1] = default(X);
                return true;
            }
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class GenericListEnumerator<X> : IEnumerator<X>
        {
            private GenericList<X> _collection;
            private int indexer;
            private X currentItem;

            public GenericListEnumerator(GenericList<X> collection)
            {
                _collection = collection;
                indexer = -1;
                currentItem = default(X);
            }

            public bool MoveNext()
            {
              
                if (++indexer >= _collection.Count)
                {
                    return false;
                }
                else
                {
                    currentItem = _collection.GetElement(indexer);
                }
                return true;
                // Zove se prije svake iteracije.
                // Vratite true ako treba ući u iteraciju, false ako ne
                // Hint: čuvajte neko globalno stanje po kojem pratite gdje se
                // nalazimo u kolekciji
            }
            public X Current
            {
                get
                { return currentItem;  }
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }

            
            public void Dispose()
            {
                // Ignorirajte
            }
            public void Reset()
            {
                // Ignorirajte
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
        }

        public int Count
        {   
           get
            {
                for (int a = 0; a < _internalStorage.Length; a++)
                {
                    if (_internalStorage[a] == 0)
                    {
                        return a;
                    }
                    
                 }
                return -1;

            }
        }

        public void Add(int item)
        {
            if (IndexOf(0)==-1)
            {
                int size = _internalStorage.Length;
                int[] _internalStorageTemp = _internalStorage;
                _internalStorage = new int[2 * size];
                for (int a = 0; a < size; a++)
                {
                    _internalStorage[a] = _internalStorageTemp[a];
                }

            }

            for (int a = 0; a < _internalStorage.Length; a++)
            {
                if (_internalStorage[a] == 0)
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
                _internalStorage[a] = 0;
            }
        }

        public bool Contains(int item)
        {
            for (int a = 0; a < _internalStorage.Length; a++)
            {
                if (_internalStorage[a] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if((index < _internalStorage.Length - 1) && (index>=0))
            {
                return _internalStorage[index];
            }
            else
             {
                throw new IndexOutOfRangeException();
             }
        }

        public int IndexOf(int item)
        {
            if (Contains(item)) {
                for (int a = 0; a < _internalStorage.Length; a++)
                {
                    if (_internalStorage[a] == item)
                    {
                        return a;
                    }
                }
            }
            return -1;
        }

        public bool Remove(int item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
        if (index > _internalStorage.Length - 1 || index < 0 || _internalStorage[index]==0)
        {
            return false;
        }
        else {
                for (int a = index; a < _internalStorage.Length - 1; a++)
                {
                    _internalStorage[a] = _internalStorage[a + 1];
                }
                _internalStorage[_internalStorage.Length - 1] = 0;
                return true;
        }
    }
    }
}

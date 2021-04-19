using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace TBS
{
    public sealed class ListExecuteObject : IEnumerator, IEnumerable
    {
        private IExecute[] _executeObjext;
        private int _index = -1;


        public void AddExecuteObject(IExecute execute)
        {
            if (_executeObjext == null)
            {
                _executeObjext = new[] { execute };
                return;
            }
            Array.Resize(ref _executeObjext, Length + 1);
            _executeObjext[Length - 1] = execute;
        }

        public IExecute this[int index]
        {
            get => _executeObjext[index];
            private set => _executeObjext[index] = value;
        }

        public int Length => _executeObjext.Length;

        public bool MoveNext()
        {
            if (_index == _executeObjext.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _executeObjext[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

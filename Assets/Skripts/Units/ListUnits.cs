using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace TBS
{
    public sealed class ListUnits : IEnumerator, IEnumerable
    {
        private IUnits[] _units;
        private int _index = -1;
        private bool _checkBoold = false;

        public ListUnits(IUnits[] units)
        {
            foreach (var item in units)
            {
                AddUnits(item);
            }
        }


        public void AddUnits(IUnits execute)
        {
            if (_units == null)
            {
                _units = new[] { execute };
                return;
            }
            Array.Resize(ref _units, Length + 1);
            _units[Length - 1] = execute;
        }

        public void ClearUnits(IUnits unit)
        {
            for (int i = 0; i < _units.Length; i++)
            {
                if (_units[i].GetPosition() == unit.GetPosition())
                {
                    _checkBoold = true;
                }
                if (_checkBoold)
                {
                    if (i <= _units.Length - 1)
                    {
                        _units[i] = _units[i];
                    }                    
                }
            }
            _units[_units.Length - 1] = null;
            Array.Resize(ref _units, Length - 1);
        }

        public IUnits this[int index]
        {
            get => _units[index];
            private set => _units[index] = value;
        }

        public int Length => _units.Length;

        public bool MoveNext()
        {
            if (_index == _units.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _units[_index];

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

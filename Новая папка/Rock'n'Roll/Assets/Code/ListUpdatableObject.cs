using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace RockAndRoll
{
    public sealed class ListUpdatableObject : IEnumerator, IEnumerable
    {
        private IUpdatable[] _interactiveObjects;
        private int _index = -1;
        private InteractiveObject _current;

        public ListUpdatableObject()
        {
            var interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
            for (var i = 0; i < interactiveObjects.Length; i++)
            {
                if (interactiveObjects[i] is IUpdatable interactiveObject)
                {
                    AddUpdatableObject(interactiveObject);
                }
            }
        }

        public void AddUpdatableObject(IUpdatable update)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new[] { update };
                return;
            }
            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = update;
        }

        public IUpdatable this[int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }

        public int Length => _interactiveObjects.Length;

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

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


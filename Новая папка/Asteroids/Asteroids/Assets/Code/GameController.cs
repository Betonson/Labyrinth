using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private ListUpdatableObject _interactiveObjects;
        private InputController _inputController;
        public void Awake()
        {
            _interactiveObjects = new ListUpdatableObject();

            var reference = new Reference();

            _inputController = new InputController(reference.PlayerShip);
            _interactiveObjects.AddUpdatableObject(_inputController);

        }

        public void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];
                if (interactiveObject == null)
                {
                    Debug.Log("Test1");
                    continue;
                }
                interactiveObject.CustomUpdate();
            }
        }
        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    Debug.Log("I did a thing!");
                    Destroy(interactiveObject.gameObject);
                }
            }
        }
    }
}

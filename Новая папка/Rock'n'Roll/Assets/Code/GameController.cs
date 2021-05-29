using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockAndRoll
{
    public sealed class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;
        public void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }

        public void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];
                if (interactiveObject == null)
                {
                    continue;
                }
                if(interactiveObject is IAction )
                {
                    interactiveObject.Action();
                }
            }
        }
    }
}

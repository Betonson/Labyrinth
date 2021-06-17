using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockAndRoll
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private ListUpdatableObject _interactiveObjects;
        private InputController _inputController;
        private CameraController _cameraController;
        private GameMaster _gameMaster;
        public void Awake()
        {
            _gameMaster = FindObjectOfType<GameMaster>();
            _interactiveObjects = new ListUpdatableObject();

            var reference = new Reference();
            _cameraController = new CameraController(reference.PlayerBall.transform, reference.MainCamera.transform);
            _interactiveObjects.AddUpdatableObject(_cameraController);

            _inputController = new InputController(reference.PlayerBall);
            _interactiveObjects.AddUpdatableObject(_inputController);

            foreach (var objct in _interactiveObjects)
            {
                if (objct is BadBonus badBonus)
                {
                    badBonus.BadBonusContact += BadBonusContact;
                    badBonus.BadBonusContact += _gameMaster.DisplayGameOverScreen;
                }
                if (objct is EssentialBonus essentialBonus)
                {
                    essentialBonus.EssentialBonusContact += _gameMaster.SetBonusesLeft;
                }
                if (objct is DoorObserver doorObserver)
                {
                    _gameMaster.EssentialBonusesAmountChange += doorObserver.OnEssentialBonusPickup;
                }
                if (objct is Exit exit)
                {
                    exit.ExitContact += _gameMaster.DisplayVictoryScreen;
                }
            }

        }

        public void BadBonusContact(object value)
        {
            Time.timeScale = 0.0f;
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
                    if (o is BadBonus badBonus)
                    {
                        badBonus.BadBonusContact -= BadBonusContact;
                        badBonus.BadBonusContact -= _gameMaster.DisplayGameOverScreen;
                    }
                    if (o is EssentialBonus essentialBonus)
                    {
                        essentialBonus.EssentialBonusContact -= _gameMaster.SetBonusesLeft;
                    }
                    Debug.Log("I did a thing!");
                    Destroy(interactiveObject.gameObject);
                }
            }
        }
    }
}

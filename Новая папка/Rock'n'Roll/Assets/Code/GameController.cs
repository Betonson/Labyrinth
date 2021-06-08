using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockAndRoll
{
    public sealed class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;
        private GameMaster _gameMaster;
        public void Awake()
        {
            _gameMaster = FindObjectOfType<GameMaster>();
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
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
                    continue;
                }
                if(interactiveObject is IUpdatable)
                {
                    interactiveObject.CustomUpdate();
                }
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

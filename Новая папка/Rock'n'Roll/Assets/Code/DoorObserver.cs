using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockAndRoll
{
    public class DoorObserver : InteractiveObject
    {
        [SerializeField] private GameObject _doorModel;
        [SerializeField] private float _bonusesLeftToUnlock;
        public bool _playerInRange = false;
        private DoorController _doorController;
        private Material _doorMaterial;
        private GameMaster _gameMaster;
        private bool _isLocked = true;

        private void Awake()
        {
            _gameMaster = FindObjectOfType<GameMaster>();
            _doorController = _doorModel.GetComponent<DoorController>();
            _doorMaterial = _doorModel.GetComponent<Renderer>().material;
            _doorMaterial.color = Color.red;
        }
        protected override void OnEnterInteraction()
        {
            _playerInRange = true;
        }

        protected override void OnExitInteraction()
        {
            _playerInRange = false;
        }
        public void OnEssentialBonusPickup()
        {
            if (_bonusesLeftToUnlock >= _gameMaster.essentialBonusesAmount)
            {
                _doorMaterial.color = Color.white;
                _isLocked = false;
            }
        }
        public override void CustomUpdate()
        {
            base.CustomUpdate();

            _doorController.MoveDoor(_playerInRange, _isLocked);
        }
    }
}

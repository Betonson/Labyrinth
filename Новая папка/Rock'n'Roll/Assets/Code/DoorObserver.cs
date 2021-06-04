using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockAndRoll
{
    public class DoorObserver : InteractiveObject
    {
        [SerializeField] private GameObject _doorModel;
        public bool _playerInRange = false;
        private DoorController _doorController;

        private void Awake()
        {
            _doorController = _doorModel.GetComponent<DoorController>();
        }
        protected override void OnEnterInteraction()
        {
            _playerInRange = true;
        }

        protected override void OnExitInteraction()
        {
            _playerInRange = false;
        }
        public override void CustomUpdate()
        {
            base.CustomUpdate();
            _doorController.MoveDoor(_playerInRange);
        }
    }
}

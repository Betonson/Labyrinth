using UnityEngine;

namespace RockAndRoll {
    public class Exit : InteractiveObject
    {
        public delegate void OnExitContact(object value);
        public event OnExitContact ExitContact;

        private GameMaster _gameMaster;

        private void Awake()
        {
            _gameMaster = FindObjectOfType<GameMaster>();
        }
        protected override void OnEnterInteraction()
        {
            if (_gameMaster.essentialBonusesAmount <= 0)
            {
                ExitContact?.Invoke(this);
            }
        }

        protected override void OnExitInteraction()
        {
            
        }
    }
}
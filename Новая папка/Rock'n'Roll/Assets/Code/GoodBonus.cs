using UnityEngine;

namespace RockAndRoll {
    public sealed class GoodBonus : InteractiveObject
    {
        private DisplayBonuses _displayBonuses;
        private Material _material;
        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();
            _material = GetComponent<Renderer>().material;
        }
        protected override void OnEnterInteraction()
        {
            Destroy(gameObject);
        }

        protected override void OnExitInteraction()
        {
            
        }

        public override void CustomUpdate()
        {
            base.CustomUpdate();
        }
    }
}
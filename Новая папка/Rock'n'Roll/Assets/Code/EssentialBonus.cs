using UnityEngine;

namespace RockAndRoll
{
    public sealed class EssentialBonus : InteractiveObject
    {
        private Material _material;
        private void Awake()
        {
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
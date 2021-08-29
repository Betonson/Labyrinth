using UnityEngine;

namespace RockAndRoll {
    public sealed class GoodBonus : InteractiveObject, IFly
    {
        private DisplayBonuses _displayBonuses;
        //private Material _material;
        private float _lengthFly = 0.5f;
        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();
            //_material = GetComponent<Renderer>().material;
        }
        protected override void OnEnterInteraction()
        {
            Destroy(gameObject);
        }

        protected override void OnExitInteraction()
        {
            
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.position.z);
        }

        public override void CustomUpdate()
        {
            base.CustomUpdate();
            Fly();
        }
    }
}
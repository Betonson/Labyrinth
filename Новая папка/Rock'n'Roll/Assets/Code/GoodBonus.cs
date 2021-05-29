using UnityEngine;

namespace RockAndRoll {
    public sealed class GoodBonus : InteractiveObject, IFlicker
    {
        private DisplayBonuses _displayBonuses;
        private Material _material;
        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();
            _material = GetComponent<Renderer>().material;
        }
        protected override void Interaction()
        {
            _displayBonuses.Display(5);
        }

        public void Flicker()
        {
            //_material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
            _material.color = Random.ColorHSV();
            Debug.Log("Flickering");
        }

        public override void Action()
        {
            base.Action();
            Flicker();
        }
    }
}
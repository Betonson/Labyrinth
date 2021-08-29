using System.Collections;
using UnityEngine;

namespace RockAndRoll
{
    public sealed class EssentialBonus : InteractiveObject, IFly
    {
        //private Material _material;
        public delegate void OnEssentialBonusContact(object value);
        public event OnEssentialBonusContact EssentialBonusContact;

        private IEnumerator DestroyThisObject()
        {
            IsInteractable = false;
            yield return new WaitForEndOfFrame();
            Destroy(gameObject);
        }

        private float _lengthFly = 0.5f;
        private void Awake()
        {
            //_material = GetComponent<Renderer>().material;
        }
        protected override void OnEnterInteraction()
        {
            EssentialBonusContact?.Invoke(this);
            StartCoroutine(DestroyThisObject());
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
            if (!IsInteractable) { return; }
            base.CustomUpdate();
            Fly();
        }
    }
}
using UnityEngine;

namespace RockAndRoll
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        {
            if(!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }
        private void Start()
        {
            Action();
        }

        public virtual void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                //renderer.material.color = Random.ColorHSV();
            }
        }
    }
}

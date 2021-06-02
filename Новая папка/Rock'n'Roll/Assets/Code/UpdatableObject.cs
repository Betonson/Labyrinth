using UnityEngine;

namespace RockAndRoll
{
    public abstract class UpdatableObject : MonoBehaviour, IUpdatable
    {
        public abstract void CustomUpdate();
    }
}

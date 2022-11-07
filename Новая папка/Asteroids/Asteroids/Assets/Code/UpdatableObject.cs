using UnityEngine;

namespace Asteroids
{
    public abstract class UpdatableObject : MonoBehaviour, IUpdatable
    {
        public abstract void CustomUpdate();
    }
}

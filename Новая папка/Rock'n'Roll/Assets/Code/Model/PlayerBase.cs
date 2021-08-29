using UnityEngine;

namespace RockAndRoll
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed = 5.0f;

        public abstract void Move(float x, float y, float z);
    }
}

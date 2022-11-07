using UnityEngine;

namespace Asteroids
{
    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;

        public AccelerationMove(Transform transform, Rigidbody2D rigidbody2D, float speed, float acceleration):base(transform, rigidbody2D, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
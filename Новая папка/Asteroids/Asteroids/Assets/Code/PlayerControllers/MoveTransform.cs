using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform: IMove
    {
        private readonly Transform _transform;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _move;
        
        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, Rigidbody2D rigidbody2D, float speed)
        {
            _transform = transform;
            _rigidbody2D = rigidbody2D;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            // _move.Set(horizontal*speed, vertical*speed, 0.0f);
            // _transform.localPosition += _move;
            Vector3 movement = new Vector3(horizontal, vertical, 0.0f);
            _rigidbody2D.AddForce(movement * Speed);
        }
    }
}
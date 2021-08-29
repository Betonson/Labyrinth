
using UnityEngine;

namespace RockAndRoll
{
    public class PlayerBall : PlayerBase
    {
        private Vector3 _moveInput;
        private Vector3 _moveVelocity;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public override void Move(float x, float y, float z)
        {
            _moveInput = new Vector3(x, y, z);
            _moveVelocity = _moveInput * Speed;

            _rigidbody.velocity = _moveVelocity;
        }
    }
}

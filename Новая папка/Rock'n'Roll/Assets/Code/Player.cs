using UnityEngine;

namespace RockAndRoll
{
    public class Player : MonoBehaviour
    {
        private Vector3 _moveInput;
        private Vector3 _moveVelocity;
        public float Speed = 5.0f;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //float moveVertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            //_rigidbody.AddForce(-1 * movement * Speed);

            _moveInput = new Vector3(Input.GetAxisRaw("Horizontal") * -1.0f, 0f, Input.GetAxisRaw("Vertical") * -1.0f);
            _moveVelocity = _moveInput * Speed;

            _rigidbody.velocity = _moveVelocity;
        }
    }
}

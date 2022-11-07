using UnityEngine;

namespace Asteroids
{
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        public IMove MoveTransform;
        public IRotation RotationTransform;
        public PlayerCollisionDetection playerCollisionDetection;

        private void Start()
        {
            MoveTransform = new AccelerationMove(transform, GetComponent<Rigidbody2D>(), _speed, _acceleration);
            RotationTransform = new RotationTransform(transform);
        }
    }
}
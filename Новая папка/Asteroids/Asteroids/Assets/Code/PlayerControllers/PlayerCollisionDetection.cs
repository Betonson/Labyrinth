using System;
using UnityEngine;

namespace Asteroids
{
    public class PlayerCollisionDetection: MonoBehaviour
    {
        private Transform _transform;
        private void Start()
        {
            _transform = gameObject.GetComponent<Transform>();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("UnpassableWall"))
            {
                print("I touched the wall");
                var position = _transform.position;
                var teleportByX = position.x > 28 || position.x < -28;
                var teleportByY = position.y > 16 || position.y < -16;
                _transform.position = new Vector2(teleportByX ? position.x = -position.x : position.x, teleportByY ? position.y = -position.y : position.y);
                
            }
        }
    }
}
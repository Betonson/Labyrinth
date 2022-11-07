using UnityEngine;

namespace Asteroids
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed = 30.0f;
        public float bulletDamage = 5.0f;
        public bool canDamagePlayer = false;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("UnpassableWall"))
            {
                print("I touched the wall");
                Destroy(gameObject);
            }
            print("I make no sense");
            // if (collision.gameObject.CompareTag("Enemy") && !canDamagePlayer)
            // {
            //     DoDamage(collision, "Enemy");
            //     Destroy(gameObject);
            // }
            //
            // if (collision.gameObject.CompareTag("Player") && canDamagePlayer)
            // {
            //     DoDamage(collision, "Player");
            //     Destroy(gameObject);
            // }
        }

        void DoDamage(Collider collision, string tag)
        {
            if (tag == "Enemy")
            {
                // var healthController = collision.gameObject.GetComponent<HealthManager>();
                // healthController.DealDamage(bulletDamage);
            }
            else
            {
                // var healthController = collision.gameObject.GetComponent<PlayerHealthManager>();
                // healthController.DealDamage(bulletDamage);
            }
        }

    }
}
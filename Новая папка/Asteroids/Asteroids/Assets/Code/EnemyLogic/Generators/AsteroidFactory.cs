using UnityEngine;
namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemies/BasicAsteroid"));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}
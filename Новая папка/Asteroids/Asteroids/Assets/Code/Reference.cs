using UnityEngine;

namespace Asteroids
{
    public class Reference
    {
        private PlayerShip _playerShip;
        private Camera _mainCamera;

        public PlayerShip PlayerShip
        {
            get
            {
                if (_playerShip == null)
                {
                    _playerShip = Object.FindObjectOfType<PlayerShip>();
                }

                return _playerShip;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }
}
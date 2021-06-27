using UnityEngine;

namespace RockAndRoll
{
    public class CameraController: IUpdatable
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            //_mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }

        public void CustomUpdate()
        {
            _mainCamera.position = _player.position + _offset;
        }
    }
}
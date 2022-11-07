using UnityEngine;

namespace Asteroids
{
    public class InputController : IUpdatable
    {
        private readonly PlayerShip _playerShip;
        private Camera _camera;
        
        public InputController(PlayerShip playerShip)
        {
            _playerShip = playerShip;
            _camera = Camera.main;
        }

        public void CustomUpdate()
        {
            _playerShip.MoveTransform.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), Time.deltaTime);

            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerShip.transform.position);
            _playerShip.RotationTransform.Rotation(direction);
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(_playerShip.MoveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if(_playerShip.MoveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.RemoveAcceleration();
                }
            }
        }
    }
}
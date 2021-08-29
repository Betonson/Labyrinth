using UnityEngine;

namespace RockAndRoll
{
    public sealed class InputController : IUpdatable
    {
        private readonly PlayerBase _playerBase;

        public InputController(PlayerBase player)
        {
            _playerBase = player;
        }

        public void CustomUpdate()
        {
            _playerBase.Move(Input.GetAxisRaw("Horizontal")*-1, 0.0f, Input.GetAxisRaw("Vertical")*-1);
        }
    }
}


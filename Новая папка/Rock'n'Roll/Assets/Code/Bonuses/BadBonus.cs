using UnityEngine;

namespace RockAndRoll
{
    public sealed class BadBonus : InteractiveObject, IPatrolling
    {
        public delegate void OnBadBonusContact(object value);
        public event OnBadBonusContact BadBonusContact;

        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private GameObject _wayPointsGroup;
        [SerializeField] private float _speed;
        private bool _gamePaused = false;
        private int _destinationPointIndex = 0;

        private void Awake()
        {
            _waypoints = new Transform[_wayPointsGroup.transform.childCount];
            for (int i = 0; i < _wayPointsGroup.transform.childCount; i++)
            {
                _waypoints[i] = _wayPointsGroup.transform.GetChild(i);
            }
        }
        protected override void OnEnterInteraction()
        {
            _gamePaused = true;
            BadBonusContact?.Invoke(this);
        }

        protected override void OnExitInteraction()
        {

        }

        public override void CustomUpdate()
        {
            base.CustomUpdate();
            Patrol();
        }

        public void Patrol()
        {
            if (!_gamePaused)
            {
                if (transform.position != _waypoints[_destinationPointIndex].position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _waypoints[_destinationPointIndex].position, _speed);
                }
                else
                {
                    if (_destinationPointIndex == _waypoints.Length - 1)
                    {
                        _destinationPointIndex = 0;
                    }
                    else
                    {
                        _destinationPointIndex++;
                    }
                }
            }
        }
    }
}
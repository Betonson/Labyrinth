using UnityEngine;

namespace RockAndRoll
{
    public sealed class BadBonus : InteractiveObject, IPatrolling
    {
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private GameObject _wayPointsGroup;
        [SerializeField] private float _speed;
        //private Transform _destinationPoint;
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
            Destroy(gameObject);
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
            if (transform.position != _waypoints[_destinationPointIndex].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _waypoints[_destinationPointIndex].position, _speed);
            }
            else
            {
                if(_destinationPointIndex == _waypoints.Length - 1)
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
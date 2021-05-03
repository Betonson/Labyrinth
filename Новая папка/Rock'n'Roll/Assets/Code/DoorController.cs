using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockAndRoll
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] private GameObject _doorObserver;
        [SerializeField] private Transform _openPosition;
        [SerializeField] private Transform _closedPosition;
        [SerializeField] private float _doorSpeed = 10.0f;

        private void Update()
        {
            var observer = _doorObserver.gameObject.GetComponent<DoorObserver>();
            if (observer._playerInRange == true)
            {
                if (transform.position != _openPosition.position)
                {
                    transform.position -= (transform.position - _openPosition.position) * _doorSpeed * Time.deltaTime;
                }
            }
            if (observer._playerInRange == false)
            {
                if (transform.position != _closedPosition.position)
                {
                    transform.position -= (transform.position - _closedPosition.position) * _doorSpeed * Time.deltaTime;
                }
            }
        }
    }
}

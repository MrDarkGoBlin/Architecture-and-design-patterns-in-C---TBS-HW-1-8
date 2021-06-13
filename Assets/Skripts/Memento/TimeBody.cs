using System.Collections.Generic;
using UnityEngine;


namespace Memento
{
    public sealed class TimeBody : MonoBehaviour
    {
        [SerializeField] private float _recordTime = 5f;
        private TimeMath _timeMath;
        private Rigidbody _rb;
        private bool _isRewinding;

        private void Start()
        {
            
            _rb = GetComponent<Rigidbody>();
            _timeMath = new TimeMath(_recordTime, _rb, transform);
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _timeMath.StartRewind();
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                _timeMath.StopRewind();
            }

            _isRewinding = _timeMath.CheckRewind();
        }

        private void FixedUpdate()
        {
            if (_isRewinding)
            {
                _timeMath.Rewind();
            }
            else
            {
                _timeMath.Record();
            }
        }

        
    }
}


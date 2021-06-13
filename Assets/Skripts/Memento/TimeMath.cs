using System.Collections.Generic;
using UnityEngine;

namespace Memento
{   
    public class TimeMath
    {
        private float _recordTime;
        private List<PointInTime> _pointsInTime;
        private Transform _transform;
        private Rigidbody _rb;
        private bool _isRewinding;

        public TimeMath(float recordTime, Rigidbody rb, Transform transform)
        {
            _recordTime = recordTime;
            _rb = rb;
            _transform = transform;
            _pointsInTime = new List<PointInTime>();
        }
        public void Rewind()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        public void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }

            _pointsInTime.Insert(0, new PointInTime(_transform.position, _transform.rotation, _rb.velocity, _rb.angularVelocity));
        }

        public void StartRewind()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
        }

        public void StopRewind()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
            _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
        }

        public bool CheckRewind() =>  _isRewinding;


    }
}

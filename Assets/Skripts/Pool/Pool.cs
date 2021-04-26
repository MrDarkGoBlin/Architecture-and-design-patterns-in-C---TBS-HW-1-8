using System;
using System.Collections.Generic;
using UnityEngine;

namespace PoolTest
{
    public class Pool
    {
        public Transform _container { get; private set; }
        public Queue<GameObject> _objects;
        public Pool(Transform container)
        {
            _container = container;
            _objects = new Queue<GameObject>();
        }
    }
}

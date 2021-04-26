using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PoolTest
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler _instance;

        [Serializable] public struct ObjectInfo
        {
            public enum ObjectType
            {
                rainDropRad,
                rainDropBlue,
                rainDropGreen,
            }
            public ObjectType _type;
            public GameObject _prefab;
            public int _startCount;
        }

        [SerializeField] private List<ObjectInfo> _objectsInfo;
        private Dictionary<ObjectInfo.ObjectType, Pool> _pools;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            InfoPool();
        }

        private void InfoPool()
        {
            _pools = new Dictionary<ObjectInfo.ObjectType, Pool>();
            var emptyGo = new GameObject();
            foreach (var item in _objectsInfo)
            {
                var conreiner = Instantiate(emptyGo, transform, false);
                conreiner.name = item._type.ToString();

                _pools[item._type] = new Pool(conreiner.transform);

                for (int i = 0; i < item._startCount; i++)
                {
                    var go = InstantiateObject(item._type, conreiner.transform);
                    _pools[item._type]._objects.Enqueue(go);
                }
            }

            Destroy(emptyGo);
        }

        private GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform transform)
        {
            var go = Instantiate(_objectsInfo.Find(x => x._type == type)._prefab, transform);
            go.SetActive(false);
            return go;
        }

        public GameObject GetObject(ObjectInfo.ObjectType type)
        {
            var obj = _pools[type]._objects.Count > 0 ?
                _pools[type]._objects.Dequeue() : InstantiateObject(type, _pools[type]._container);

            obj.SetActive(true);
            return obj; 
        }

        public void DestroyObject(GameObject obj)
        {
            _pools[obj.GetComponent<IPooldObject>()._type]._objects.Enqueue(obj);
            obj.SetActive(false);
        }

    }
}

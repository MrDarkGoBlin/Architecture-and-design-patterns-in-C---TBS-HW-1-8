using UnityEngine;

namespace PoolTest    
{
    public class RainDrops : MonoBehaviour, IPooldObject
    {
        public ObjectPooler.ObjectInfo.ObjectType _type => type;

        [SerializeField]
        private ObjectPooler.ObjectInfo.ObjectType type;
        private Rigidbody _rigidbody;

        private float _lifeTime = 3.0f;
        private float _carrentLifeTime;
        private float _speed = 100;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnCreate(Vector3 position)
        {
            transform.position = position;
            _carrentLifeTime = _lifeTime;            
            _rigidbody.AddForce(MathOfPoolTest.SpeadFors(transform, _speed));
        }
        void Update()
        {            
            if ((_carrentLifeTime = MathOfPoolTest.Timer(_carrentLifeTime)) < 0)
            {
                ObjectPooler._instance.DestroyObject(gameObject);
                
            }
        }
    }
}

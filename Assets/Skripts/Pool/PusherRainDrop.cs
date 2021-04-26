using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PoolTest 
{
    public class PusherRainDrop : MonoBehaviour
    {
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType _objectTypeRad;
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType _objectTypeGrean;
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType _objectTypeBlue;
        [SerializeField] private float timeControl = 0.5f; 
        private float timeControler;

        private void Awake()
        {
            timeControler = timeControl;
        }

        private void Update()
        {
            if ((timeControler = MathOfPoolTest.Timer(timeControler)) <= 0)
            {
                switch (MathOfPoolTest.SwitchRainDrop())
                {
                    case 1:
                        CareateDrop(_objectTypeRad);
                        break; 
                    case 2:
                        CareateDrop(_objectTypeGrean);
                        break;
                    case 3:
                        CareateDrop(_objectTypeBlue);
                        break;
                    default:
                        break;
                }
                
            }
            
        }

        private void CareateDrop(ObjectPooler.ObjectInfo.ObjectType objectType)
        {
            var rainDrop = ObjectPooler._instance.GetObject(objectType);
            rainDrop.GetComponent<RainDrops>().OnCreate(transform.position);
            timeControler = timeControl;
        }
    }
}

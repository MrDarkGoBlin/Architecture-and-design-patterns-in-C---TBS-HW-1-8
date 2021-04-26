using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PoolTest
{
    public class MathOfPoolTest
    {
        public static float Timer(float value)
        {
            float _value = value - Time.deltaTime;
            return _value;
        }

        public static Vector3 SpeadFors(Transform value, float speed)
        {
            Vector3 _value = new Vector3(0, value.position.y * speed, 0);
            return _value;
        }

        public static int SwitchRainDrop()
        {
            System.Random rand = new System.Random();
            int value = rand.Next(1,4);
            return value;
        }
    }
}

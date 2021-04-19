using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal abstract class Units : MonoBehaviour
    {
        public abstract int GetLenghtStep();
        public abstract int GetNextStep();
        public abstract void ReturnStep();
        public abstract void MinusStep();
        public abstract float GetHP();
        public abstract float GetATK();
        public abstract Vector3 GetPosition();
        public abstract void SetPosition(Vector3 newpos);



    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal abstract class Units : MonoBehaviour, IUnits
    {
        public abstract void Inicialisation(ListUnits listUnits);
        public abstract int GetLenghtStep();
        public abstract int GetNextStep();
        public abstract void ReturnStep();
        public abstract void MinusStep();
        public abstract float GetHP();
        public abstract void GetATK(IUnits units);
        public abstract int GetZoneAtack();
        public abstract Vector3 GetPosition();
        public abstract void SetPosition(Vector3 newpos);
        public abstract void SetDamage(float damage, string typeAttack);




    }
}


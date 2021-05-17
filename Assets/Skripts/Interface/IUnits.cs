using UnityEngine;

namespace TBS
{
    public interface IUnits
    {
        void Inicialisation(ListUnits listUnits);
        int GetLenghtStep();
        int GetNextStep();
        void ReturnStep();
        void MinusStep();        
        Vector3 GetPosition();
        void SetPosition(Vector3 newpos);
        float GetHP();
        void GetATK(IUnits units);
        int GetZoneAtack();
        void SetDamage(float damage, string typeAttack);
    }
}

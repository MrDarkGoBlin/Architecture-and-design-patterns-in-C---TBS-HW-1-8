using UnityEngine;

namespace TBS
{
    public interface IUnits
    {
        int GetLenghtStep();
        int GetNextStep();
        void ReturnStep();
        void MinusStep();
        float GetHP();
        float GetATK();
        Vector3 GetPosition();
        void SetPosition(Vector3 newpos);
    }
}

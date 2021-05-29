using UnityEngine;

namespace TBS
{
    public interface IUnits : IHit
    {
        int GetLenghtStep();
        int GetNextStep();
        void ReturnStep();
        void MinusStep();
        float GetHP();
<<<<<<< Updated upstream
        float GetATK();
        Vector3 GetPosition();
        void SetPosition(Vector3 newpos);
=======
        bool Action(Vector3 value);
        bool SetDamage(float damage, AttackType attackType);
        void SwitchActionMod(SwitchMode switchAction);

>>>>>>> Stashed changes
    }
}

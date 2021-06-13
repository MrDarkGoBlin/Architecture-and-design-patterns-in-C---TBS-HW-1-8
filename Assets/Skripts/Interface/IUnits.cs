using UnityEngine;

namespace TBS
{
    public interface IUnits
    {
        void Inicialisation(ListUnits listUnits, TileSpecialZone tileSpecialZone);
        int GetNextStep();
        void ReturnStep();
        void MinusStep();
        Vector3 GetPosition();
        float GetHP();
        bool Action(Vector3 value);
        void SetDamage(float damage, MathOfUnits.AttackType attackType);
        void SwitchActionMod(SwitchModeUnits.SwitchMode switchAction);
    }
}

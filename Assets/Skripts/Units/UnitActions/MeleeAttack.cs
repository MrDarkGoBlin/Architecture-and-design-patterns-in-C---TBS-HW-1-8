﻿namespace TBS
{
    internal class MeleeAttack : IAttack
    {
        public void Attack(IUnits units, float ATK) => units.SetDamage(ATK, MathOfUnits.AttackType.Melle);
    }
}

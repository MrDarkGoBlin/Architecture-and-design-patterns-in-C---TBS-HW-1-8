
namespace TBS
{
    class MagiсAttak : IAttack
    {
        public void Attack(IUnits units, float ATK) => units.SetDamage(ATK, AttackType.Magick);
    }
}

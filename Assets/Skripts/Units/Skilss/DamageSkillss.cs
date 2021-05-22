using UnityEngine;


namespace TBS
{
    public abstract class DamageSkillss : ISkills
    {
        private protected float _attack;
        private protected int _attackZone;
        private protected int _noAttackZone;

        public abstract bool Action(Vector3 value);
        public abstract void CreateZoneAction(Vector3 playerPosition);
    }
}

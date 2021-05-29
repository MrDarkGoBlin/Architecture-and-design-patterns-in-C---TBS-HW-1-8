using UnityEngine;

namespace TBS
{
    class HighHitSkill : DamageSkillss
    {
        private TileSpecialZone _tileSpecialZone; 


        public HighHitSkill(TileSpecialZone tileSpecialZone, float attack, int attackZone, int noAttackZone)
        {
            _tileSpecialZone = tileSpecialZone;        
            _attack = attack * 1.30f;        
            _attackZone = attackZone + 10;        
            _noAttackZone = 0;
    }
        public override bool Action(Vector3 value)
        {
            IUnits units = _tileSpecialZone.Atack(value);
            if (units == null)
            {
                return false;
            }
            return true;
        }
        public override void CreateZoneAction(Vector3 playerPosition)
        {
            _tileSpecialZone.CreateZone(playerPosition, _attackZone, _noAttackZone);
        }
    }
}


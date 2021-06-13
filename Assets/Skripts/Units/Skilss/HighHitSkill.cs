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
            _attackZone = attackZone;        
            _noAttackZone = 0;
    }
        public override bool Action(Vector3 value)
        {
            _tileSpecialZone.Atack(value);
            if (_tileSpecialZone.Atack(value) == null)
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal class PlayerUnit : Units
    {
        private PlayerUnit _playerGuards;


        public override void Inicialisation(ListUnits listUnits, TileSpecialZone tileSpecialZone)
        {
            _attack = new MeleeAttack();
            _tileSpecialZone = tileSpecialZone;
            _skills1 = new HighHitSkill(_tileSpecialZone, _ATK, _zoneAtack, _zoneNoAtack);
            _skills2 = new LowHitSkill(_tileSpecialZone, _ATK, _zoneAtack, _zoneNoAtack);
            _playerGuards = GetComponent<PlayerUnit>();

            ReturnStep();
            _HP = _maxHP;
            _mathOfUnits = new MathOfUnits();
            _listUnits = listUnits;

        }
        
        public override void SetDamage(float damage, AttackType attackType) 
        { 
            _HP = _mathOfUnits.MinusHP(_HP, _DEF, damage, attackType);
            if (_HP == 0)
            {
                Death();
            }
        }

        private void Death()
        {
            _listUnits.ClearUnits(_playerGuards);
            Destroy(this.gameObject);
        }

    }
}


using UnityEngine;


namespace TBS
{
    internal class EnemyGuards : Units
    {
        private EnemyGuards _enemyGuards;
        


        public override void Inicialisation(ListUnits listUnits, TileSpecialZone tileSpecialZone)
        {
            _attack = new MeleeAttack();
            _enemyGuards.GetComponent<EnemyGuards>();

            ReturnStep();
            _mathOfUnits = new MathOfUnits();
            _HP = _maxHP;
            _listUnits = listUnits;
            _tileSpecialZone = tileSpecialZone;
        }

        public override void SetDamage(float damage, MathOfUnits.AttackType typeAttack)
        {
            
            _HP = _mathOfUnits.MinusHP(_HP, _DEF, damage, typeAttack);
            if (_HP == 0)
            {
                Death();
            }
        }

        private void Death()
        {
            _listUnits.ClearUnits(_enemyGuards);
            Destroy(this);
        }
    }
}


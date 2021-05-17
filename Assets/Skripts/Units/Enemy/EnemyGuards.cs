﻿using UnityEngine;


namespace TBS
{
    internal class EnemyGuards : Units
    {
        private EnemyGuards _enemyGuards;
        private MathOfUnits _mathOfUnits;
        private ListUnits _listUnits;
        [SerializeField] private IAttack _attack;

        internal readonly float _maxHP;
        internal readonly int _speadStep;
        internal readonly int _lengthStep;
        internal float _HP;
        internal float _DEF;
        internal float _ATK;
        internal int _nextStep;
        private int _zoneAtack;


        public override void Inicialisation(ListUnits listUnits)
        {
            ReturnStep();
            _HP = _maxHP;
            _mathOfUnits = new MathOfUnits();
            _enemyGuards.GetComponent<EnemyGuards>();
            _listUnits = listUnits;
        }

        public override int GetLenghtStep() => _lengthStep;
        public override int GetNextStep() => _nextStep;
        public override void MinusStep() => _nextStep = _mathOfUnits.MinusOneStep(_nextStep);
        public override void ReturnStep() => _nextStep = _speadStep;
        public override float GetHP() => _HP;
        public override void GetATK(IUnits units) => _attack.Attack(units, _ATK);
        public override int GetZoneAtack() => _zoneAtack;
        public override Vector3 GetPosition() => transform.position;
        public override void SetPosition(Vector3 newpos) => transform.position = newpos;
        public override void SetDamage(float damage, string typeAttack)
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


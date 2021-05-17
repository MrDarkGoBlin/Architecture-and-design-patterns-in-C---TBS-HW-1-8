using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal class PlayerGuards : Units
    {
        private PlayerGuards _playerGuards;
        private MathOfUnits _mathOfUnits;
        private ListUnits _listUnits;
        [SerializeField] private IAttack _attack;

        [SerializeField] private float _maxHP;
        [SerializeField] private int _speadStep;
        [SerializeField] private int _lengthStep;        
        [SerializeField] private float _DEF;
        [SerializeField] private float _ATK;
        [SerializeField] private float _HP;
        [SerializeField] private int _nextStep;
        [SerializeField] private int _zoneAtack;
        [SerializeField] private int _zoneNoAtack;


        public override void Inicialisation(ListUnits listUnits)
        {
            _attack = new MeleeAttack();
            ReturnStep();
            _HP = _maxHP;
            _mathOfUnits = new MathOfUnits();
            _playerGuards = GetComponent<PlayerGuards>();
            _listUnits = listUnits;
        }

        public override int GetLenghtStep() => _lengthStep;
        public override int GetNextStep() => _nextStep;
        public override void MinusStep() => _nextStep = _mathOfUnits.MinusOneStep(_nextStep);
        public override void ReturnStep() => _nextStep = _speadStep;
        public override float GetHP() => _HP;
        public override int GetZoneAtack() => _zoneAtack;
        public override Vector3 GetPosition() => transform.position;
        public override void SetPosition(Vector3 newpos) => transform.position = newpos;

        public override void GetATK(IUnits units) => _attack.Attack(units, _ATK);

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
            _listUnits.ClearUnits(_playerGuards);
            Destroy(this.gameObject);
        }

    }
}


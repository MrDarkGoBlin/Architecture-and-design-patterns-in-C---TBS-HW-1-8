using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal class PlayerGuards : Units
    {
        private MathOfUnits _mathOfUnits;

        [SerializeField] internal float _maxHP;
        [SerializeField] internal int _speadStep;
        [SerializeField] internal int _lengthStep;        
        [SerializeField] internal float _DEF;
        [SerializeField] internal float _ATK;
        internal float _HP;
        [SerializeField] internal int _nextStep; // не определяестя через флоат и дельта тайм, потому что в последствии персонажи будут ходить  по очереди.

        private void Start()
        {
            ReturnStep();
            _HP = _maxHP;
            _mathOfUnits = new MathOfUnits();            
        }

        public override int GetLenghtStep() => _lengthStep;
        public override int GetNextStep() => _nextStep;
        public override void MinusStep() => _nextStep = _mathOfUnits.MinusOneStep(_nextStep);
        public override void ReturnStep() => _nextStep = _speadStep;
        public override float GetHP() => _HP;
        public override float GetATK() => _ATK;
        public override Vector3 GetPosition() => transform.position;
        public override void SetPosition(Vector3 newpos) => transform.position = newpos;


    }
}


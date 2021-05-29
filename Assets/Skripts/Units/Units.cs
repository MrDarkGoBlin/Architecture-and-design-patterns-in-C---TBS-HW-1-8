using System;
using UnityEngine;


namespace TBS
{
    internal abstract class Units : MonoBehaviour, IUnits
    {
<<<<<<< Updated upstream
        public abstract int GetLenghtStep();
        public abstract int GetNextStep();
        public abstract void ReturnStep();
        public abstract void MinusStep();
        public abstract float GetHP();
        public abstract float GetATK();
        public abstract Vector3 GetPosition();
        public abstract void SetPosition(Vector3 newpos);
=======
        private protected MathOfUnits _mathOfUnits;
        private protected ListUnits _listUnits;
        private protected TileSpecialZone _tileSpecialZone;
        private SwitchMode _switchAction;
        private protected IAttack _attack;
        private protected ISkills _skills1;
        private protected ISkills _skills2;

        [SerializeField] private protected float _maxHP;
        [SerializeField] private protected int _speadStep;
        [SerializeField] private protected int _lengthStep;
        [SerializeField] private protected float _DEF;
        [SerializeField] private protected float _ATK;
        [SerializeField] private protected float _HP;
        [SerializeField] private protected int _nextStep;
        [SerializeField] private protected int _zoneAtack;
        [SerializeField] private protected int _zoneNoAtack;
        [SerializeField] private protected bool _checkAction;

        public abstract void Inicialisation(ListUnits listUnits, TileSpecialZone tileSpecialZone);
        public  int GetNextStep() => _nextStep;
        public  void MinusStep() => _nextStep = _mathOfUnits.MinusOneStep(_nextStep);
        public  void ReturnStep() => _nextStep = _speadStep;
        public  float GetHP() => _HP;
        public abstract bool SetDamage(float damage, AttackType attackType);
        public Vector3 GetPosition() => transform.position;
        public bool Action(Vector3 value)
        {
            _checkAction = false;
            switch (_switchAction)
            {
                case SwitchMode.move:
                    Muve(value);
                    break;
                case SwitchMode.attack:
                    Attack(value);
                    break;
                case SwitchMode.skill1:
                    Skill1(value);
                    break;
                case SwitchMode.skill2:
                    Skill2(value);
                    break;
                default:                   
                    break;
            }
            return _checkAction;
        }

        public void SwitchActionMod(SwitchMode switchAction)
        {
            _switchAction = switchAction;
            switch (_switchAction)
            {
                case SwitchMode.move:
                    _tileSpecialZone.CreateZone(transform.position, _lengthStep);
                    break;
                case SwitchMode.attack:
                    _tileSpecialZone.CreateZone(transform.position, _zoneAtack);
                    break;
                case SwitchMode.skill1:
                    _skills2.CreateZoneAction(transform.position);
                    break;
                case SwitchMode.skill2:
                    _skills2.CreateZoneAction(transform.position);
                    break;
                default:
                    break;
            }
            

        }

        public event Action<float> OnHitChange = delegate (float f) { };
        public void Hit(float damage)
        {
            OnHitChange.Invoke(damage);
        }
>>>>>>> Stashed changes


        private void Muve(Vector3 value)
        {
            Vector3 newpos = _tileSpecialZone.Move(transform.position, value);
            if (transform.position != newpos)
            {
                transform.position = newpos;
                ReturnStep();
                _checkAction = true;
            }
        }
        private void Attack(Vector3 value)
        {
            var unit = _tileSpecialZone.Atack(value);
            if (unit != null)
            {
                _attack.Attack(unit, _ATK);
                ReturnStep();
                _checkAction = true;
            }
        }
        private void Skill1(Vector3 value)
        {
            _checkAction = _skills1.Action(value);
            ReturnStep();
        }
        private void Skill2(Vector3 value)
        {
            _checkAction = _skills2.Action(value);
            ReturnStep();
        }
    }
}


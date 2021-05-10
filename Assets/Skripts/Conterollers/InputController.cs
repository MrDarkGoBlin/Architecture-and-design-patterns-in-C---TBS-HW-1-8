using UnityEngine;


namespace TBS
{
    internal class InputController : IExecute
    {
        private TileSpecialZone _tile;
        private IUnits _unit;
        private bool _doing;
        private Vector3 _checkSwitchPosition;
        private SwitchModeUnits.SwitchMode _switchMode;
        private Camera _mainCamera;

        public InputController(TileSpecialZone tile, Camera camera)
        {
            _tile = tile;
            _doing = false;
            _switchMode = SwitchModeUnits.SwitchMode.move;
            _mainCamera = camera;

        }

        public void Execute()
        {
            if (_doing)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    switch (_switchMode)
                    {
                        case SwitchModeUnits.SwitchMode.attack:
                            Attak();                            
                            break;
                        case SwitchModeUnits.SwitchMode.move:
                            Move();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void Move()
        {
            Vector3 clicworld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clicworld.z = 0;
            _checkSwitchPosition = _tile.Move(_unit.GetPosition(), clicworld);
            if (_checkSwitchPosition != _unit.GetPosition())
            {
                _unit.SetPosition(_checkSwitchPosition);
                _unit.ReturnStep();
                SwitchDoing();
            }
        }

        private void Attak()
        {
            Vector3 clicworld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clicworld.z = 0;
            IUnits atackToUnit = _tile.Atack(clicworld);
            if (atackToUnit != null)
            {
                atackToUnit.SetDamage(_unit.GetATK());
                SwitchMove();
                SwitchDoing();
            }
        }
        public void SwitchAtack()
        {
            _switchMode = SwitchModeUnits.SwitchMode.attack;
        }
        public void SwitchMove()
        {
            _switchMode = SwitchModeUnits.SwitchMode.move;
        }
        public bool getDoing() => _doing;
        public void SwitchDoing() => _doing = !_doing;
        public void SetUnit(IUnits newUnit) => _unit = newUnit;
    }
}

    


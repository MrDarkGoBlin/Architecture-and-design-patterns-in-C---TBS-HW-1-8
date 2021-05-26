using UnityEngine;


namespace TBS
{
    internal class InputController : IExecute
    {
        private IUnits _unit;
        private SwitchMode _switchMode;
        private Camera _mainCamera;

        private bool _chekAction;
        private bool _action;



        public InputController( Camera camera)
        {
            _chekAction = false;
            _switchMode = SwitchMode.move;
            _mainCamera = camera;
        }

        public void Execute()
        {
            if (_chekAction)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 clicworld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    clicworld.z = 0;
                    _action = _unit.Action(clicworld);
                    if (_action)
                    {
                        _chekAction = false;
                    }
                    
                }
            }
        }
        
        
        public void SwitchAction(SwitchMode switchMode)
        {
            _switchMode = switchMode;
            _unit.SwitchActionMod(_switchMode);
        }
        public bool getDoing() => _chekAction;
        public void SwitchDoing() => _chekAction = true;
        public void SetUnit(IUnits newUnit) => _unit = newUnit;

        
    }
}

    


using System;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal class InputController : IExecute
    {
        private TileMoveZone _tile;
        private IUnits _unit;
<<<<<<< Updated upstream
        private bool _doing;
        private Vector3 _checkSwitchPosition;

        public InputController(TileMoveZone tile)
        {
            _tile = tile;
            _doing = false;
=======
        private SwitchMode _switchMode;
        private Camera _mainCamera;
        private ListUnits _units;

        private bool _chekAction;
        private bool _action;



        public InputController( Camera camera, ListUnits units)
        {
            _chekAction = false;
            _switchMode = SwitchMode.move;
            _mainCamera = camera;
            _units = units;
            var listenerHitShowDamage = new ListenerHitShowDamage();
            for (int i = 0; i < _units.Length; i++)
            {
                listenerHitShowDamage.Add(_units[i]);
            }
            
>>>>>>> Stashed changes
        }

        public void Execute()
        {
            if (_doing)
            {
                
                if (Input.GetMouseButtonDown(0))
                {
<<<<<<< Updated upstream
                    _checkSwitchPosition = _tile.Move(_unit.GetPosition());
                    if (_checkSwitchPosition != _unit.GetPosition())
=======
                    
                    Vector3 clicworld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    clicworld.z = 0;
                    _action = _unit.Action(clicworld);
                    if (_action)
>>>>>>> Stashed changes
                    {
                        _unit.SetPosition(_checkSwitchPosition);
                        _unit.ReturnStep();
                        SwitchDoing();
                    }
                    
                }                
            }     
        }

        public bool getDoing() => _doing;
        public void SwitchDoing() => _doing = !_doing;
        public void SetUnit(IUnits newUnit) => _unit = newUnit;
    }
    

}


using System;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal class InputController : IExecute
    {
        private TileMoveZone _tile;
        private IUnits _unit;
        private bool _doing;
        private Vector3 _checkSwitchPosition;

        public InputController(TileMoveZone tile)
        {
            _tile = tile;
            _doing = false;
        }

        public void Execute()
        {
            if (_doing)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _checkSwitchPosition = _tile.Move(_unit.GetPosition());
                    if (_checkSwitchPosition != _unit.GetPosition())
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


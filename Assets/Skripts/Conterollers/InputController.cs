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
                    _unit.SetPosition(_tile.Move(_unit.GetPosition()));
                    _unit.ReturnStep();
                    SwitchDoing();
                }
                SwitchDoing();
            }     
        }

        public bool getDoing() => _doing;
        public void SwitchDoing() => _doing = !_doing;
        public void SetUnit(IUnits newUnit) => _unit = newUnit;
    }
    

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal class TimeController : IExecute
    {
        private InputController _inputController;
        private TileMoveZone _tileMoveZone;
        private IUnits[] _listUnits; // впоследствии переделаю в скриптовый массив(для создания диномичности) как с ListExecuteObject (это не оправдание, а скорее напоминание себе)
        private int _checStep;
        private int lastRoundForCycle;

        public TimeController(InputController inputController, IUnits[] listUnits, TileMoveZone tileMoveZone)
        {
            _tileMoveZone = tileMoveZone;
            _inputController = inputController;
            _listUnits = listUnits;
            lastRoundForCycle = 0;
        }
        public void Execute()
        {
            if (!_inputController.getDoing())
            {
                for (int i = lastRoundForCycle; i < _listUnits.Length; i++)
                {                    
                    _checStep = _listUnits[i].GetNextStep();
                    if (_checStep <= 0)
                    {
                        _tileMoveZone.CreateMoveZone(_listUnits[i].GetPosition(), _listUnits[i].GetLenghtStep(), this._listUnits);
                        _inputController.SetUnit(_listUnits[i]);
                        _inputController.SwitchDoing();
                        lastRoundForCycle = i++;
                        return;
                    }
                    else
                    {
                        _listUnits[i].MinusStep();
                    }
                }
                lastRoundForCycle = 0;
            }
        }
    }
}


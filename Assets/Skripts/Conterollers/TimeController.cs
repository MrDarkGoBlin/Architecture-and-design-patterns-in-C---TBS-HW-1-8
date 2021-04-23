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

        public TimeController(InputController inputController, IUnits[] listUnits, TileMoveZone tileMoveZone)
        {
            _tileMoveZone = tileMoveZone;
            _inputController = inputController;
            _listUnits = listUnits;
        }
        public void Execute()
        {
            if (!_inputController.getDoing())
            {
                foreach (var item in _listUnits)
                {
                    _checStep = item.GetNextStep();
                    if (_checStep <= 0)
                    {
                        _tileMoveZone.CreateMoveZone(item.GetPosition(), item.GetLenghtStep());
                        _inputController.SetUnit(item);
                        _inputController.SwitchDoing();
                    }
                    else
                    {
                        item.MinusStep();
                    }        
                }
            }
        }
    }
}


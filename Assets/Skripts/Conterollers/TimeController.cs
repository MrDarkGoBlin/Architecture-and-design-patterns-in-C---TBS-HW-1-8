using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal class TimeController : IExecute
    {
        private InputController _inputController;
        private Units[] _listUnits; // впоследствии переделаю в скриптовый массив(для создания диномичности) как с ListExecuteObject (это не оправдание, а скорее напоминание себе)
        private int _checStep;

        public TimeController(InputController inputController, Units[] listUnits)
        {
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


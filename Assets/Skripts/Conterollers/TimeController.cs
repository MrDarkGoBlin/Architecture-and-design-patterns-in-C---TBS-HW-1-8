using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    internal class TimeController : IExecute
    {
        private InputController _inputController;
        private ListUnits _listUnits;
        private ButtonUI _buttonUI;
        private int _checStep;
        private int lastRoundForCycle;


        

        public TimeController(InputController inputController, ListUnits listUnits, ButtonUI buttonUI)
        {
            _inputController = inputController;
            _listUnits = listUnits;
            lastRoundForCycle = 0;
            _buttonUI = buttonUI;


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
                        _inputController.SetUnit(_listUnits[i]);
                        _inputController.SwitchAction(SwitchMode.move);
                        _inputController.SwitchDoing();
                        _buttonUI.MoveClick();
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


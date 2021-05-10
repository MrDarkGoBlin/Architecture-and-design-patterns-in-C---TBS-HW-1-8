using UnityEngine;

namespace TBS
{
    public class ButtonUI : MonoBehaviour
    {
        private TileSpecialZone _tileSpecialZone;
        private InputController _inputController;
        private ListUnits _units;

        internal void Initialization(InputController inputController, TileSpecialZone tileSpecialZone, ListUnits units) 
        {
            _tileSpecialZone = tileSpecialZone;
            _inputController = inputController;
            _units = units;
        }
        public void MoveClick()
        {
            _tileSpecialZone.SwitchMoveZone();
            _inputController.SwitchMove();
        }
        public void AtackClick()
        {
            _tileSpecialZone.SwitchAttakZone();
            _inputController.SwitchAtack();
        }
    }
}

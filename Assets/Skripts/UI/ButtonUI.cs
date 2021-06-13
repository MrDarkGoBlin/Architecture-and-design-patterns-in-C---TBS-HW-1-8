using UnityEngine;
using UnityEngine.UI;

namespace TBS
{
    public class ButtonUI : MonoBehaviour
    {
        private TileSpecialZone _tileSpecialZone;
        private InputController _inputController;
        private ListUnits _units;
        [SerializeField] private Button _buttonMove;
        [SerializeField] private Button _buttonAttack;
        [SerializeField] private Button _buttonSkill1;
        [SerializeField] private Button _buttonSkill2;

        internal void Initialization(InputController inputController, TileSpecialZone tileSpecialZone, ListUnits units) 
        {
            _tileSpecialZone = tileSpecialZone;
            _inputController = inputController;
            _units = units;
        }
        public void MoveClick()
        {
            _inputController.SwitchAction(SwitchModeUnits.SwitchMode.move);
            OnButton();
            _buttonMove.interactable = false;
        }
        public void AtackClick()
        {
            _inputController.SwitchAction(SwitchModeUnits.SwitchMode.attack);
            OnButton();
            _buttonAttack.interactable = false;
        }

        public void Skil1()
        {

            _inputController.SwitchAction(SwitchModeUnits.SwitchMode.skill1);
            OnButton();
            _buttonSkill1.interactable = false;
        }
        public void Skil2()
        {

            _inputController.SwitchAction(SwitchModeUnits.SwitchMode.skill2);
            OnButton();
            _buttonSkill2.interactable = false;
        }
        private void OnButton()
        {
            _buttonAttack.interactable = true;
            _buttonMove.interactable = true;
            _buttonSkill1.interactable = true;
            _buttonSkill2.interactable = true;
        }
    }
}

using UnityEngine;


namespace TBS
{
    public class UpdateController : MonoBehaviour
    {
        private TileSpecialZone _tileSpecialZone;
        private ListExecuteObject _listExecute;
        private InputController _imputController;
        private TimeController _timeController;
        private ButtonUI _buttonUI;
        private Camera _mainCamera;

        private ListUnits _units;

        private void Start()
        {

            _mainCamera = Camera.main;
            _units = new ListUnits( Object.FindObjectsOfType<Units>());
            _tileSpecialZone = Object.FindObjectOfType<TileSpecialZone>();
            _listExecute = new ListExecuteObject();
            _imputController = new InputController( _tileSpecialZone, _mainCamera);
            _timeController = new TimeController(_imputController, _units, _tileSpecialZone);
            _listExecute.AddExecuteObject(_imputController);
            _listExecute.AddExecuteObject(_timeController);
            _buttonUI = Object.FindObjectOfType<ButtonUI>();
            _buttonUI.Initialization(_imputController, _tileSpecialZone, _units);
            for (int i = 0; i < _units.Length; i++)
            {
                _units[i].Inicialisation(_units);
            }
        }

        private void Update()
        {
            for (int i = 0; i < _listExecute.Length; i++)
            {
                _listExecute[i].Execute();
            }
        }

    }
}


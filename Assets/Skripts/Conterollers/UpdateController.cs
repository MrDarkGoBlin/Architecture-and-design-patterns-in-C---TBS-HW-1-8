using UnityEngine;


namespace TBS
{
    public class UpdateController : MonoBehaviour
    {
        private TileMoveZone _tileDoing;
        private IUnits[] _units;
        private ListExecuteObject _listExecute;
        private InputController _imputController;
        private TimeController _timeController;

        private void Start()
        {
            _units = Object.FindObjectsOfType<Units>();
            _tileDoing = Object.FindObjectOfType<TileMoveZone>();
            _listExecute = new ListExecuteObject();
<<<<<<< Updated upstream
            _imputController = new InputController( _tileDoing);
            _timeController = new TimeController(_imputController, _units, _tileDoing);
=======
            _imputController = new InputController(_mainCamera, _units);
            _buttonUI = Object.FindObjectOfType<ButtonUI>();
            _buttonUI.Initialization(_imputController, _tileSpecialZone, _units);
            _timeController = new TimeController(_imputController, _units, _buttonUI);
>>>>>>> Stashed changes
            _listExecute.AddExecuteObject(_imputController);
            _listExecute.AddExecuteObject(_timeController);
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


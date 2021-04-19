﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TBS
{
    public class UpdateController : MonoBehaviour
    {
        [SerializeField] private TileDoing _tileDoing;
        [SerializeField] private Units[] _units;
        private ListExecuteObject _listExecute;
        private InputController _imputController;
        private TimeController _timeController;

        private void Start()
        {
            _units = Object.FindObjectsOfType<Units>();
            _listExecute = new ListExecuteObject();
            _imputController = new InputController( _tileDoing);
            _timeController = new TimeController(_imputController, _units);
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

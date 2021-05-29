using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Skripts.HW8.State
{
    class InputController : MonoBehaviour
    {
        [SerializeField] private PlayerMove _player;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.SetMoveStop();
            }else if (Input.GetKeyDown(KeyCode.W))
            {
                _player.SetMoveUp();
            }else if (Input.GetKeyDown(KeyCode.S))
            {
                _player.SetMoveDown();
            }else if (Input.GetKeyDown(KeyCode.D))
            {
                _player.SetMoveRight();
            }else if (Input.GetKeyDown(KeyCode.A))
            {
                _player.SetMoveLeft();
            }else 
            _player.Action();

        }
    }
}

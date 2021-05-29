using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Skripts.HW8.State
{
    class PlayerMove : MonoBehaviour
    {
        private Dictionary<Type, IAction> _actionList;
        private IAction _action;

        private void Start()
        {
            InitAction();
            SetDefaultAction();
        }

        private void InitAction()
        {
            _actionList = new Dictionary<Type, IAction>();
            _actionList[typeof(MoveStop)] = new MoveStop();
            _actionList[typeof(MoveUp)] = new MoveUp();
            _actionList[typeof(MoveDown)] = new MoveDown();
            _actionList[typeof(MoveRight)] = new MoveRight();
            _actionList[typeof(MoveLeft)] = new MoveLeft();
        }

        private void SetAction(IAction action)
        {
            _action = action;
            _action.EnterInAction();
        }

        private IAction GetAction<T>() where T : IAction
        {
            var type = typeof(T);
            return _actionList[type];
        }
        private void SetDefaultAction()
        {
            SetMoveStop();
        }
        public void Action()
        {
            _action.Action(transform);
        }

        public void SetMoveStop()
        {
            var dafaultAction = GetAction<MoveStop>();
            SetAction(dafaultAction);
        }
        public void SetMoveUp()
        {
            var dafaultAction = GetAction<MoveUp>();
            SetAction(dafaultAction);
        }
        public void SetMoveDown()
        {
            var dafaultAction = GetAction<MoveDown>();
            SetAction(dafaultAction);
        }
        public void SetMoveRight()
        {
            var dafaultAction = GetAction<MoveRight>();
            SetAction(dafaultAction);
        }
        public void SetMoveLeft()
        {
            var dafaultAction = GetAction<MoveLeft>();
            SetAction(dafaultAction);
        }

    }
}

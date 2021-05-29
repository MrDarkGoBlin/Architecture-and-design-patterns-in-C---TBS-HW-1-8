using UnityEngine;

namespace Assets.Skripts.HW8.State
{
    public interface IAction
    {
        void EnterInAction();
        void Action(Transform transform);
    }
}

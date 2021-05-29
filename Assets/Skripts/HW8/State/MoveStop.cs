using UnityEngine;

namespace Assets.Skripts.HW8.State
{
    internal class MoveStop : IAction
    {
        public void EnterInAction()
        {
            Debug.Log("I'm here, in the shadow");
        }
        public void Action(Transform transform)
        {
            transform.position = new Vector3(0,0,0);
        }
    }
}

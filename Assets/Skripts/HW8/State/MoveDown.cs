using UnityEngine;

namespace Assets.Skripts.HW8.State
{
    internal class MoveDown : IAction
    {
        public void EnterInAction()
        {
            Debug.Log("Будет Сделано");
        }
        public void Action(Transform transform)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (3 * Time.deltaTime), transform.position.z);
        }
    }
}

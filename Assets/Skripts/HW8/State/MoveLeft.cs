using UnityEngine;

namespace Assets.Skripts.HW8.State
{
    internal class MoveLeft : IAction
    {
        public void EnterInAction()
        {
            Debug.Log("Моя Жизнь принедлежит ОРДЕ!!!!!!");
        }
        public void Action(Transform transform)
        {
            transform.position = new Vector3(transform.position.x - (3 * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }
}

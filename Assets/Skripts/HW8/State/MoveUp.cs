using UnityEngine;

namespace Assets.Skripts.HW8.State
{
    internal class MoveUp : IAction
    {
        public void EnterInAction()
        {
            Debug.Log("ЗАДАВИМ ИХ ИНТЕЛЕКТОМ");
        }
        public void Action(Transform transform)
        {
            transform.position = new Vector3( transform.position.x, transform.position.y + (3 * Time.deltaTime), transform.position.z);
        }
    }
}

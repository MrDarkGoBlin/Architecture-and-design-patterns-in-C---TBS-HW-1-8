using UnityEngine;

namespace TBS
{
    public interface ISkills
    {
        bool Action(Vector3 value);
        void CreateZoneAction(Vector3 playerPosition);

    }
}

using UnityEngine;
using UnityEngine.Tilemaps;

namespace TBS
{
    internal interface IFactory
    {
        void CreateSpecialZone(Vector3 playerPosition, int langthStep, ListUnits units);
        void CreateSpecialZone(Vector3 playerPosition, int AttackZone, int NoAttackZone, ListUnits units);
        void DestroyZone();
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;

namespace TBS
{
    public interface IFactory
    {
        void CreateZoneOfMuve(Vector3 playerPosition, int langthStep, ListUnits units);
        void DestroyZoneOfMuve();
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;

namespace TBS
{
    public interface IFactory
    {
        void CreateZoneOfMuve(Vector3 playerPosition, int langthStep, IUnits[] units);
        void DestroyZoneOfMuve();
    }
}

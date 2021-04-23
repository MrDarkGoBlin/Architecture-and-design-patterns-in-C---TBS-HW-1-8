using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace TBS
{
    public class TileMoveZoneFactory
    {
        public void CreateZoneOfMuve(Vector3 playerPosition, int langthStep, IUnits[] units, TileBase greenZone, TileBase radZone, Tilemap moveZone, Tilemap groundZone)
        {
            var playerIntPoint = moveZone.WorldToCell(playerPosition);
            Vector3Int firstPoint = new Vector3Int(playerIntPoint.x - langthStep, playerIntPoint.y - langthStep, 0);
            Vector3Int secondPoint = new Vector3Int(playerIntPoint.x + langthStep, playerIntPoint.y + langthStep, 0);
            Vector3Int point = new Vector3Int();
            for (int i = firstPoint.x; i < secondPoint.x; i++)
            {
                for (int j = firstPoint.y; j < secondPoint.y; j++)
                {
                    moveZone.SetTile(new Vector3Int(i, j, 0), greenZone);
                    foreach (var item in units)
                    {
                        point = moveZone.WorldToCell(item.GetPosition());
                        if (point.x == i && point.y == j)
                        {
                            moveZone.SetTile(new Vector3Int(i, j, 0), radZone);
                        }
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace TBS
{
    public class TileMoveZoneFactory : IFactory
    {
        private TileBase _greenZone;
        private TileBase _radZone;
        private Tilemap _moveZone;
        private Tilemap _groundZone;
        private Vector3Int _firstPoint;
        private  Vector3Int _secondPoint;
        private Vector3Int _point;
        public TileMoveZoneFactory(TileBase greenZone, TileBase radZone, Tilemap moveZone, Tilemap groundZone)
        {
            _greenZone = greenZone;
            _radZone = radZone;
            _moveZone = moveZone;
            _groundZone = groundZone;
        }


        public void CreateZoneOfMuve(Vector3 playerPosition, int langthStep, IUnits[] units)
        {
            var playerIntPoint = _moveZone.WorldToCell(playerPosition);
            _firstPoint = new Vector3Int(playerIntPoint.x - langthStep, playerIntPoint.y - langthStep, 0);
            _secondPoint = new Vector3Int(playerIntPoint.x + langthStep, playerIntPoint.y + langthStep, 0);
            _point = new Vector3Int();
            for (int i = _firstPoint.x; i < _secondPoint.x; i++)
            {
                for (int j = _firstPoint.y; j < _secondPoint.y; j++)
                {
                    if (_groundZone.GetTile(new Vector3Int(i, j, 0)) != null)
                    {
                        _moveZone.SetTile(new Vector3Int(i, j, 0), _greenZone);
                        foreach (var item in units)
                        {

                            _point = _moveZone.WorldToCell(item.GetPosition());
                            if (_point.x == i && _point.y == j)
                            {
                                _moveZone.SetTile(new Vector3Int(i, j, 0), _radZone);
                            }
                        }
                    }
                }
            }
        }

        public void DestroyZoneOfMuve()
        {
            
            for (int i = _firstPoint.x; i < _secondPoint.x; i++)
            {
                for (int j = _firstPoint.y; j < _secondPoint.y; j++)
                {
                        _moveZone.SetTile(new Vector3Int(i, j, 0), null);  
                }
            }
        }
    }
}

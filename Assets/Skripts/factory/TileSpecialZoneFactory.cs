using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace TBS
{
    public class TileSpecialZoneFactory : IFactory
    {
        private TileBase _greenZone;
        private TileBase _radZone;
        private Tilemap _moveZone;
        private Tilemap _groundZone;
        private Vector3Int _firstPoint;
        private  Vector3Int _secondPoint;
        private Vector3Int _point;
        public TileSpecialZoneFactory(TileBase greenZone, TileBase radZone, Tilemap moveZone, Tilemap groundZone)
        {
            _greenZone = greenZone;
            _radZone = radZone;
            _moveZone = moveZone;
            _groundZone = groundZone;
        }


        public void CreateSpecialZone(Vector3 playerPosition, int langthStep, ListUnits units)
        {
            var playerIntPoint = _moveZone.WorldToCell(playerPosition);
            SetPointsZone(langthStep, playerIntPoint);
            _point = new Vector3Int();
            CreateZone(units);
        }


        public void CreateSpecialZone(Vector3 playerPosition, int AttackZone, int NoAttackZone, ListUnits units)
        {
            var playerIntPoint = _moveZone.WorldToCell(playerPosition);
            SetPointsZone(AttackZone, playerIntPoint);
            _point = new Vector3Int();
            CreateZone(units);
            SetPointsZone(NoAttackZone, playerIntPoint);
            DestroyZone();
            SetPointsZone(AttackZone, playerIntPoint);
        }

        public void DestroyZone()
        {

            for (int i = _firstPoint.x; i < _secondPoint.x; i++)
            {
                for (int j = _firstPoint.y; j < _secondPoint.y; j++)
                {
                    _moveZone.SetTile(new Vector3Int(i, j, 0), null);
                }
            }
        }

        private void CreateZone(ListUnits units)
        {
            for (int i = _firstPoint.x; i < _secondPoint.x; i++)
            {
                for (int j = _firstPoint.y; j < _secondPoint.y; j++)
                {
                    if (_groundZone.GetTile(new Vector3Int(i, j, 0)) != null)
                    {
                        _moveZone.SetTile(new Vector3Int(i, j, 0), _greenZone);
                        for (int item = 0; item < units.Length; item++)
                        {

                            _point = _moveZone.WorldToCell(units[item].GetPosition());
                            if (_point.x == i && _point.y == j)
                            {
                                _moveZone.SetTile(new Vector3Int(i, j, 0), _radZone);
                            }
                        }
                    }
                }
            }
        }

        

        private void SetPointsZone(int langthStep, Vector3Int playerIntPoint)
        {
            _firstPoint = new Vector3Int(playerIntPoint.x - langthStep, playerIntPoint.y - langthStep, 0);
            _secondPoint = new Vector3Int(playerIntPoint.x + langthStep, playerIntPoint.y + langthStep, 0);
        }
    }
}

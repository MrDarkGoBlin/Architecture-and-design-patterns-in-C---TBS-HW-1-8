using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace TBS
{
    public class TileMoveZone : MonoBehaviour
    {
        [SerializeField] TileBase _greenZone;
        [SerializeField] TileBase _radZone;
        private Tilemap _moveZone;
        private Tilemap _groundZone;        
        private Camera mainCamera;


        private void Start()
        {
            _moveZone = GetComponent<Tilemap>();
            _groundZone = Object.FindObjectOfType<TileMoveZone>();
            mainCamera = Camera.main;
        }
        public Vector3 Move(Vector3 player)
        {                
            Vector3 clicworld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clicworld.z = 0;                
            Vector3Int clickCell = _moveZone.WorldToCell(clicworld);
            if (_moveZone.GetTile(clickCell) == _greenZone)
            {
                return player = _moveZone.CellToWorld(clickCell);
            }
            return player ;
            
        }

        public void CreateMoveZone(Vector3 playerPosition, int langthStep, IUnits[] units)
        {
            var playerIntPoint = _moveZone.WorldToCell(playerPosition);
            Vector3Int firstPoint = new Vector3Int(playerIntPoint.x - langthStep, playerIntPoint.y - langthStep, 0);
            Vector3Int secondPoint = new Vector3Int(playerIntPoint.x + langthStep, playerIntPoint.y + langthStep, 0);
            Vector3Int point = new Vector3Int();
            for (int i = firstPoint.x; i < secondPoint.x; i++)
            {
                for (int j = firstPoint.y; j < secondPoint.y; j++)
                {
                    _moveZone.SetTile(new Vector3Int(i, j, 0), _greenZone);
                    foreach (var item in units)
                    {
                        point = _moveZone.WorldToCell(item.GetPosition());
                        if (point.x == i && point.y == j)
                        {
                            _moveZone.SetTile(new Vector3Int(i, j, 0), _radZone);
                        }
                    }
                } 
            }
        }
    }
}



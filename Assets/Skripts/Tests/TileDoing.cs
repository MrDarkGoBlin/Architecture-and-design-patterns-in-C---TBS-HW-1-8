using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace TBS
{
    public class TileDoing : MonoBehaviour
    {
        private Tilemap map;
        private Camera mainCamera;


        private void Start()
        {
            map = GetComponent<Tilemap>();
            mainCamera = Camera.main;
        }
        public Vector3 Move(Vector3 Player)
        {                
            Vector3 clicworld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clicworld.z = 0;                
            Vector3Int clickCell = map.WorldToCell(clicworld);
            if (map.GetTile(clickCell) == null)
            {
                return Player;
            }
            return Player = map.CellToWorld(clickCell);
            
        }
    }
}



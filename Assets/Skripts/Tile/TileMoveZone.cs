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
        private IFactory _tileMoveZoneFactory;


        private void Start()
        {
            _moveZone = GetComponent<Tilemap>();
            _groundZone = Object.FindObjectOfType<TileGround>().GetTilemap() ;
            mainCamera = Camera.main;
            _tileMoveZoneFactory = new TileMoveZoneFactory(_greenZone, _radZone, _moveZone, _groundZone);
        }
        public Vector3 Move(Vector3 player)
        {                
            Vector3 clicworld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clicworld.z = 0;                
            Vector3Int clickCell = _moveZone.WorldToCell(clicworld);
            if (_moveZone.GetTile(clickCell) == _greenZone)
            {
                _tileMoveZoneFactory.DestroyZoneOfMuve();
                return player = _moveZone.CellToWorld(clickCell);                
            }
            return player ;
            
        }

        public void CreateMoveZone(Vector3 playerPosition, int langthStep, IUnits[] units)
        {
            _tileMoveZoneFactory.CreateZoneOfMuve(playerPosition, langthStep, units);
        }
    }
}



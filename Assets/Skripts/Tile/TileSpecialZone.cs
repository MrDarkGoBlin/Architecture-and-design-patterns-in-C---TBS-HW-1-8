using UnityEngine;
using UnityEngine.Tilemaps;


namespace TBS
{
    public class TileSpecialZone : MonoBehaviour
    {
        [SerializeField] TileBase _greenZone;
        [SerializeField] TileBase _radZone;
        private Tilemap _moveZone;
        private Tilemap _groundZone;   
        private IFactory _tileSpecialZoneFactory;
        private ListUnits _units;
        private Vector3Int _playerPositionCell;


        public void Initialisation(ListUnits units)
        {
            _units = units;
            _moveZone = GetComponent<Tilemap>();
            _groundZone = Object.FindObjectOfType<TileGround>().GetTilemap();
            _tileSpecialZoneFactory = new TileSpecialZoneFactory(_greenZone, _radZone, _moveZone, _groundZone);
        }
        public Vector3 Move(Vector3 player, Vector3 clicworld)
        {                
                         
            Vector3Int clickCell = _moveZone.WorldToCell(clicworld);
            if (_moveZone.GetTile(clickCell) == _greenZone)
            {
                _tileSpecialZoneFactory.DestroyZone();
                return player = _moveZone.CellToWorld(clickCell);                
            }
            return player ;
            
        }

        internal IUnits Atack(Vector3 clicworld)
        {

            Vector3Int clickCell = _moveZone.WorldToCell(clicworld);
            if (_moveZone.GetTile(clickCell) == _radZone)
            {
                for (int item = 0; item < _units.Length; item++)
                {
                    _playerPositionCell = _moveZone.WorldToCell(_units[item].GetPosition());
                    if (clickCell == _playerPositionCell)
                    {
                        _tileSpecialZoneFactory.DestroyZone();
                        return _units[item];
                    }                    
                }
            }
            return null;
        }


        internal void CreateZone(Vector3 unitPosition, int radiusAttackZone)
        {
            _tileSpecialZoneFactory.DestroyZone();
            _tileSpecialZoneFactory.CreateSpecialZone(unitPosition, radiusAttackZone, _units);
        }
        internal void CreateZone(Vector3 unitPosition, int radiusAttackZone, int radiusNoAttackZone)
        {
            _tileSpecialZoneFactory.DestroyZone();
            _tileSpecialZoneFactory.CreateSpecialZone(unitPosition, radiusAttackZone, radiusNoAttackZone, _units);
        }
        
    }
}



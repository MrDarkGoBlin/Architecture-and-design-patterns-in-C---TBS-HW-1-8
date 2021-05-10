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
        private IFactory _tileMoveZoneFactory;
        private Vector3 _unitPosition;
        private int _unitMoveZone;
        private int _unitAtackZone;
        private ListUnits _units;
        private Vector3Int _playerPositionCell;


        private void Start()
        {
            _moveZone = GetComponent<Tilemap>();
            _groundZone = Object.FindObjectOfType<TileGround>().GetTilemap() ;
            _tileMoveZoneFactory = new TileMoveZoneFactory(_greenZone, _radZone, _moveZone, _groundZone);
        }
        public Vector3 Move(Vector3 player, Vector3 clicworld)
        {                
                         
            Vector3Int clickCell = _moveZone.WorldToCell(clicworld);
            if (_moveZone.GetTile(clickCell) == _greenZone)
            {
                _tileMoveZoneFactory.DestroyZoneOfMuve();
                return player = _moveZone.CellToWorld(clickCell);                
            }
            return player ;
            
        }

        public IUnits Atack(Vector3 clicworld)
        {

            Vector3Int clickCell = _moveZone.WorldToCell(clicworld);
            if (_moveZone.GetTile(clickCell) == _radZone)
            {
                for (int item = 0; item < _units.Length; item++)
                {
                    _playerPositionCell = _moveZone.WorldToCell(_units[item].GetPosition());
                    if (clickCell == _playerPositionCell)
                    {
                        _tileMoveZoneFactory.DestroyZoneOfMuve();
                        return _units[item];
                    }                    
                }
                SwitchMoveZone();
            }
            return null;
        }


        public void CreateMoveZone(Vector3 unitPosition, int unitMoveZone, int unitAtackZone, ListUnits units)
        {
            _unitPosition = unitPosition;
            _unitMoveZone = unitMoveZone;
            _unitAtackZone = unitAtackZone;
            _units = units;
            _tileMoveZoneFactory.CreateZoneOfMuve(_unitPosition, _unitMoveZone, _units);
        }
        

        public void SwitchMoveZone()
        {
            _tileMoveZoneFactory.DestroyZoneOfMuve();
            _tileMoveZoneFactory.CreateZoneOfMuve(_unitPosition, _unitMoveZone, _units);
        }

        public void SwitchAttakZone()
        {
            _tileMoveZoneFactory.DestroyZoneOfMuve();
            _tileMoveZoneFactory.CreateZoneOfMuve(_unitPosition, _unitAtackZone, _units);
        }



    }
}



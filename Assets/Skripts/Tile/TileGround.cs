using UnityEngine;
using UnityEngine.Tilemaps;

namespace TBS
{
    class TileGround : MonoBehaviour
    {
        private Tilemap _tilemap;
        private void Start()
        {
            _tilemap = GetComponent<Tilemap>();
        }

        public Tilemap GetTilemap() => _tilemap;
    }
}

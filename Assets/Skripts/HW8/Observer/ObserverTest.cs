using UnityEngine;

namespace TBS
{
    public sealed class ObserverTest : MonoBehaviour
    {
        private Units _enemy;
        private float _damage;
        private Camera _mainCamera;
        private float _dedicateDistance = 20.0f;

        private void Start()
        {
            _mainCamera = Camera.main;
            var listenerHitShowDamage = new ListenerHitShowDamage();
            listenerHitShowDamage.Add(_enemy);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition),
                    out var hit, _dedicateDistance))
                {
                    if (hit.collider.TryGetComponent<IHit>(out var enemy))
                    {
                        enemy.Hit(_damage);
                    }
                }
            }
        }
    }

}

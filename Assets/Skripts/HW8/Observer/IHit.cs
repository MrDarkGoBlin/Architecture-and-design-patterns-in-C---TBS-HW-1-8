using System;

namespace TBS
{
        public interface IHit
        {
            event Action<float> OnHitChange;
            void Hit(float damage);
        }

}

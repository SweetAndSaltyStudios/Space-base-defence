using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public abstract class Weapon : MonoBehaviour
    {
        protected Transform currentTarget;

        public virtual void Shoot(Transform target)
        {
            currentTarget = target;
        }
    }
}
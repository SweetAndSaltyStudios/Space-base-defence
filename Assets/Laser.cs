using System.Collections;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Laser : Weapon
    {
        private LineRenderer lineRenderer;

        private void Awake()
        {
            lineRenderer = GetComponentInChildren<LineRenderer>();
        }
          
        private void Start()
        {
            lineRenderer.enabled = false;
        }

        public override void Shoot(Transform target)
        {
            StartCoroutine(IShootLaser(target));
        }

        private IEnumerator IShootLaser(Transform target)
        {
            lineRenderer.enabled = true;

            while(currentTarget)
            {
                lineRenderer.SetPosition(1, target.transform.position);

                yield return null;
            }

            lineRenderer.enabled = false;
        }
    }
}
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class EnemyShip : Ship
    {
        private Transform target;
        private Rigidbody rb;
        private float moveSpeed = 20;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();            
        }

        private void FixedUpdate()
        {
            if(target == null)
            {
                target = FindObjectOfType<SpaceStation>().transform;
                return;
            }

            var direction = target.position - transform.position;

            var newRotation = Quaternion.LookRotation(direction);

            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, Time.fixedDeltaTime);

            rb.velocity = direction.normalized * moveSpeed * Time.fixedDeltaTime;
         
        }
    }
}

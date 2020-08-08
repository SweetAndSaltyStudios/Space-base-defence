using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class SpaceStation : MonoBehaviour
    {
        private Rigidbody rb;
        private Weapon weapon;

        private readonly float rotationSpeed = 6f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            weapon = GetComponentInChildren<Weapon>();
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            weapon.Shoot(other.transform);
        }
    }
}
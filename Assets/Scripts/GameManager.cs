using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class GameManager : MonoBehaviour
    {
        [Header("Prefabs")]
        public SpaceStation SpaceStationPrefab;
        public EnemyShip EnemyShipPrefab;

        private void Start()
        {
            SpawnPrefabInstance(SpaceStationPrefab);
        }

        private T SpawnPrefabInstance<T>(T prefab, Vector3 spawnPosition = new Vector3(), Quaternion spawnRotation = new Quaternion(), Transform parent = null) where T : Component
        {
            var newPrefabInstance = Instantiate(prefab, spawnPosition, spawnRotation, parent);
            newPrefabInstance.name = prefab.name;
            return newPrefabInstance;
        }

        public void SetTimeScale()
        {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }
    }
}
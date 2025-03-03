using Data;
using Data.SO;
using UnityEngine;

namespace Controllers
{
    public class ShootingController : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;

        public void Shoot(Weapon Weapon)
        {

            MissleController prefab = Weapon.MisslePrefab;
            if (prefab == null || spawnPoint == null)
            {
                Debug.LogError("Spawn point or misslePrefab not set!");
                return; 
            }

            var missle = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            missle.Init();
        }
    }
}

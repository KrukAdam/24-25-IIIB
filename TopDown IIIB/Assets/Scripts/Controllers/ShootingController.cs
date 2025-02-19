using UnityEngine;

namespace Controllers
{
    public class ShootingController : MonoBehaviour
    {
        [SerializeField] private MissleController misslePrefab;
        [SerializeField] private Transform spawnPoint;

        public void Shoot()
        {
            if (misslePrefab == null || spawnPoint == null)
            {
                Debug.LogError("Spawn point or misslePrefab not set!");
                return; 
            }

            var missle = Instantiate(misslePrefab, spawnPoint.position, spawnPoint.rotation);
            missle.Init();
        }
    }
}

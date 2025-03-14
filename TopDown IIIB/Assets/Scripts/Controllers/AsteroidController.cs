using UnityEngine;

namespace Controllers
{
    public class AsteroidController : MonoBehaviour
    {
        [SerializeField] private int Health = 1;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health--;
            if (Health <= 0 ) {
                Debug.Log("Asteroid destroyed");
            }
        }
    }
}
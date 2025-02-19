using UnityEngine;
namespace Controllers
{
    public class MissleController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [Tooltip("Force applied to the missile for movement.")]
        public float force = 10f;

        [Tooltip("Duration in seconds before the missile destroys itself.")]
        public float lifetime = 30f;

        [SerializeField]    private Rigidbody2D rb;

        private void OnCollisionEnter2D(Collision2D collision)
        {

            Destroy(gameObject);
            Debug.Log("hit");
        }

        public void Init()
        {

            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component is missing from the missile.");
                return;
            }

            // Kierunek to lokalny "przód" obiektu (transform.right w 2D)
            Vector2 direction = transform.right;

            // Ustaw rotacjê, jeœli to konieczne
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Zastosuj si³ê w kierunku
            rb.AddForce(direction * force, ForceMode2D.Impulse);

            // Zniszcz pocisk po okreœlonym czasie
            Destroy(gameObject, lifetime);
        }
    }

}
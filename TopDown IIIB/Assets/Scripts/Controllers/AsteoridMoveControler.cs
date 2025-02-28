using System;
using UnityEngine;
namespace Controllers
{
    public class AsteoridMoveControler : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        public Vector3 rotationSpeed = new Vector3(0, 0, 100);
        public float force = 10f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitMove();
        }
        private void Update()
        {
            InitRotation();
        }

        private void InitRotation()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }

        private void InitMove()
        {

            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component is missing from the missile.");
                return;
            }

            // Kierunek to lokalny "prz�d" obiektu (transform.right w 2D)
            Vector2 direction = transform.right;

            // Ustaw rotacj�, je�li to konieczne
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Zastosuj si�� w kierunku
            rb.AddForce(direction * force, ForceMode2D.Impulse);

            // Zniszcz pocisk po okre�lonym czasie
            //Destroy(gameObject, lifetime);
        }
    }

}

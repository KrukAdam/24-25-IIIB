using UnityEngine;

namespace Controllers
{
    public class WhiteHeroMoveController : MonoBehaviour
    {
        [SerializeField] private WhiteHeroInputController whiteHeroInputController;
        [SerializeField] private Rigidbody2D rb; 
        [SerializeField] private float rotationSpeed = 5f; // Pr�dko�� obracania obiektu
        [SerializeField] private float moveSpeed = 5f; // Pr�dko�� poruszania si� obiektu
        [SerializeField] private float boostSpeed = 7f;



        // Update is called once per frame
        void Update()
        {
            Rotate();
            Move();
        }


        private void Rotate()
        {

            // Pobierz pozycj� kursora na ekranie
            Vector3 mousePosition = Input.mousePosition;

            // Przekszta�� pozycj� kursora z ekranu na �wiat
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Ustaw wysoko�� (Z) obiektu zgodnie z jego aktualn� pozycj�, aby dzia�a�o w przestrzeni 2D
            targetPosition.z = transform.position.z;

            // Oblicz kierunek do kursora
            Vector3 direction = targetPosition - transform.position;

            // Oblicz k�t obrotu w przestrzeni 2D
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Zrotuj obiekt w kierunku kursora
            Quaternion targetRotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        }



        private void Move()
        {

            // Pobierz wej�cie z klawiatury
            float horizontalInput = whiteHeroInputController.Horizontal;
            float verticalInput = whiteHeroInputController.Vertical;

            // Oblicz kierunek ruchu
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

            var speed = whiteHeroInputController.Boost ? boostSpeed : moveSpeed;
            // Porusz obiektem w zadanym kierunku
            rb.linearVelocity = movement * speed;
        }
    }
}       
using UnityEngine;

namespace Controllers
{
    public class WhiteHeroMoveController : MonoBehaviour
    {
        [SerializeField] private WhiteHeroInputController whiteHeroInputController;
        [SerializeField] private Rigidbody2D rb; 
        [SerializeField] private float rotationSpeed = 5f; // Prêdkoœæ obracania obiektu
        [SerializeField] private float moveSpeed = 5f; // Prêdkoœæ poruszania siê obiektu
        [SerializeField] private float boostSpeed = 7f;



        // Update is called once per frame
        void Update()
        {
            Rotate();
            Move();
        }


        private void Rotate()
        {
            // Pobierz pozycjê kursora i ustaw odpowiedni¹ wartoœæ Z (odleg³oœæ od kamery)
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

            // Przekszta³æ pozycjê kursora na wspó³rzêdne œwiata
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            targetPosition.z = transform.position.z;

            // Oblicz kierunek od obiektu do kursora
            Vector3 direction = targetPosition - transform.position;

            // Oblicz k¹t w stopniach, gdzie 0° wskazuje w prawo
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Skoryguj k¹t o 90 stopni, aby przód (góra) pasowa³ do kierunku kursora
            angle -= 90f;

            // Ustaw obrót obiektu tylko w osi Z
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }





        private void Move()
        {

            // Pobierz wejœcie z klawiatury
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
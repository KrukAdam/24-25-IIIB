using UnityEngine;

namespace Controllers
{
    public class WhiteHeroMoveController : MonoBehaviour
    {
        [SerializeField] private WhiteHeroInputController whiteHeroInputController;
        [SerializeField] private float rotationSpeed = 5f; // Prêdkoœæ obracania obiektu
        [SerializeField] private float moveSpeed = 5f; // Prêdkoœæ poruszania siê obiektu

        // Update is called once per frame
        void Update()
        {
            Rotate();
            Move();
        }

        private void Rotate()
        {

            // Pobierz pozycjê kursora na ekranie
            Vector3 mousePosition = Input.mousePosition;

            // Przekszta³æ pozycjê kursora z ekranu na œwiat
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Ustaw wysokoœæ (Z) obiektu zgodnie z jego aktualn¹ pozycj¹, aby dzia³a³o w przestrzeni 2D
            targetPosition.z = transform.position.z;

            // Oblicz kierunek do kursora
            Vector3 direction = targetPosition - transform.position;

            // Oblicz k¹t obrotu w przestrzeni 2D
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Zrotuj obiekt w kierunku kursora
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        private void Move()
        {

            // Pobierz wejœcie z klawiatury
            float horizontalInput = whiteHeroInputController.Horizontal;
            float verticalInput = whiteHeroInputController.Vertical;

            // Oblicz kierunek ruchu
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

            // Porusz obiektem w zadanym kierunku
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }
}       
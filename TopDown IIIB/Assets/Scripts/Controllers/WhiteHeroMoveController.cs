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
            // Pobierz pozycj� kursora i ustaw odpowiedni� warto�� Z (odleg�o�� od kamery)
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

            // Przekszta�� pozycj� kursora na wsp�rz�dne �wiata
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            targetPosition.z = transform.position.z;

            // Oblicz kierunek od obiektu do kursora
            Vector3 direction = targetPosition - transform.position;

            // Oblicz k�t w stopniach, gdzie 0� wskazuje w prawo
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Skoryguj k�t o 90 stopni, aby prz�d (g�ra) pasowa� do kierunku kursora
            angle -= 90f;

            // Ustaw obr�t obiektu tylko w osi Z
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
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
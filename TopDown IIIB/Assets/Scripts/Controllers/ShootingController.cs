using UnityEngine;

namespace Controllers
{
    public class ShootingController : MonoBehaviour
    {
        //[SerializeField] private GameObject projectilePrefab; // Prefab pocisku
        //[SerializeField] private Transform shootPoint; // Punkt, z kt�rego wystrzeliwany jest pocisk
        //[SerializeField] private float projectileSpeed = 10f; // Pr�dko�� pocisku

        // Update is called once per frame
        //void Update()
        //{
        //    if (Input.GetButtonDown("Fire1")) // Fire1 domy�lnie przypisany do lewego przycisku myszy
        //    {
        //        Shoot();
        //    }
        //}

        public void Shoot()
        {
            //// Stw�rz pocisk w punkcie wystrza�u
            //GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

            //// Nadaj pociskowi pr�dko�� w kierunku, w kt�rym jest obr�cony
            //Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            //if (rb != null)
            //{
            //    rb.linearVelocity = shootPoint.right * projectileSpeed;
            //}


            Debug.Log("shoot!");
        }
    }
}
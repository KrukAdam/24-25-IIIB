using System;
using UnityEngine;

namespace Controllers


{
    public class WhiteHeroInputController : MonoBehaviour
    {
        
        public float Horizontal { get; private set; }
        public float Vertical {get; private set; }

        [SerializeField] private ShootingController shootingController;



        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Fire1 button pressed");
                shootingController.Shoot();
            }

            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");

        }
    }
}
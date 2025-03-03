using System;
using UnityEngine;

namespace Controllers


{
    public class WhiteHeroInputController : MonoBehaviour
    {
        
        public float Horizontal { get; private set; }
        public float Vertical {get; private set; }
        public bool Boost {get; private set; }

        [SerializeField] private WhiteHeroWeaponController weaponController;



        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Fire1 button pressed");
                weaponController.Shoot();
            }
            
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            Boost = Input.GetAxis("ShiftBoost") > 0;

        }
    }
}
using Controllers;
using Data.SO;
using Data;
using UnityEngine;
using System.Linq;
using System;

namespace Controller {
    public class EnemyWeaponControroller : MonoBehaviour
{
        [SerializeField] private ShootingController shootingController;
        [SerializeField] private WeaponSO weaponSo;
        [SerializeField] private WeaponType weaponType;
        [SerializeField] float weaponSpeed = 2;
        [SerializeField] private float CurrentTime;
        private void Update()
        {
           if (CurrentTime <= 0)
            {
                CurrentTime = weaponSpeed;
                Shoot();
            }
            else
            {
                CurrentTime -= Time.deltaTime;
            }
        }


        public void Shoot()
        {
            var weaponData = weaponSo.GetWeapon(weaponType);
            if (weaponData == null)
            {
                weaponData = weaponSo.Weapons.FirstOrDefault();
                Debug.LogError("Oh no!");
            }

            shootingController.Shoot(weaponData);
        }
        
    }

 }

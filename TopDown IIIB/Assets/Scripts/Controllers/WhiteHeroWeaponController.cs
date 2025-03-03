using Controllers;
using Data;
using Data.SO;
using System.Linq;
using UnityEngine;

public class WhiteHeroWeaponController : MonoBehaviour
{
    [SerializeField] private ShootingController shootingController;
    [SerializeField] private WeaponSO weaponSo;
    [SerializeField] private WeaponType weaponType;
    
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
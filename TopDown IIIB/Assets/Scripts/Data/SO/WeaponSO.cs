using Data;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.SO
{

    [CreateAssetMenu(fileName = "weapons", menuName = "game/weapon")]
    public class WeaponSO : ScriptableObject
    {
        public List<Weapon> Weapons = new ();

        public Weapon GetWeapon(WeaponType type)
        {
            return Weapons.FirstOrDefault(w => w.WeaponType == type);
        }
    }
}

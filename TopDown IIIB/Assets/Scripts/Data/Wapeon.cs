using Architecture;
using Controllers;
using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class Weapon : Model
    {
        [field: SerializeField] public MissleController MisslePrefab { get; private set; }
        [field: SerializeField] public WeaponType WeaponType { get; private set; }
        [field: SerializeField] public int Ammo { get; private set; }
        [field: SerializeField] public int CurrentAmmo { get; private set; }


    }
}